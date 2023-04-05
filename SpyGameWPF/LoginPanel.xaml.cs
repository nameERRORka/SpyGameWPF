using SpyGameWPF.BLOCKS;
using SpyGameWPF.DATABASE;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace SpyGameWPF
{
    public partial class LoginPanel : Window
    {         
        public LoginPanel( MainWindow MWIND)
        {
            InitializeComponent();
        }

        private void ExitGame_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void JoinInto_Click(object sender, RoutedEventArgs e)
        {
            
        }
        public ushort secretKey = 0x0088;
        private void LoginProcess(object sender, RoutedEventArgs e)
        {
            string PassHash = Password.Password;


            using (var context = new DBCont())
            {
                var LoginAcc = new Account()
                {
                    Username = Login.Text,
                    Password = EncodeDecrypt(PassHash, secretKey)
                };

                if (context.Accounts.Any(o => o.Username == LoginAcc.Username) && context.Accounts.Any(o => o.Password == LoginAcc.Password))
                {
                    var res = context.Accounts.Where(i => i = Login.Text)
                    MainWindow MWIND = Owner as MainWindow;
                    MWIND.PlayerRename(this);
                    MWIND.Show();
                    this.Close();
                }
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            
            string PassHash = Password.Password;

            using (var context = new DBCont())
            {
                var RegAccount = new Account()
                {
                    Username = Login.Text,
                    Password = EncodeDecrypt(PassHash, secretKey)
                };

                if (!context.Accounts.Any(o => o.Username == Login.Text))
                {
                    context.Accounts.Add(RegAccount);
                    Debug.WriteLine($"CREATED ACC : {RegAccount.Username}\nPassword : {RegAccount.Password}");
                }
                context.SaveChanges();
            }
        }

        public static string EncodeDecrypt(string str, ushort secretKey)
        {
            var ch = str.ToArray(); 
            string newStr = "";
            foreach (var c in ch)
                newStr += TopSecret(c, secretKey);
            return newStr;
        }

        public static char TopSecret(char character, ushort secretKey)
        {
            character = (char)(character ^ secretKey);
            return character;
        }
    }
}

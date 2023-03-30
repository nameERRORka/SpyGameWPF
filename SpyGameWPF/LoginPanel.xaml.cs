using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

        public void LoginProcess(MainWindow MWIND)
        {
            MWIND.PlayerName.Content = Login.Text;
        }

        private void LoginProcess(object sender, RoutedEventArgs e)
        {
            MainWindow MWIND = Owner as MainWindow;
            MWIND.PlayerRename(this);
            MWIND.Show();
            this.Close();
        }
    }
}

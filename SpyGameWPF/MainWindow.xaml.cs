using SpyGameWPF.BLOCKS;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
/*
█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████ 
█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████ 
█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░░░███░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█
█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀▄▀░░███░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█
█░░▄▀░░░░░░░░░░█░░▄▀░░░░░░░░░░█░░▄▀░░░░░░▄▀░░█░░▄▀░░░░░░░░▄▀░░███░░▄▀░░░░░░░░░░█░░░░░░▄▀░░░░░░█░░▄▀░░░░░░▄▀░░█░░▄▀░░░░░░▄▀░░█
█░░▄▀░░█████████░░▄▀░░█████████░░▄▀░░██░░▄▀░░█░░▄▀░░████░░▄▀░░███░░▄▀░░█████████████░░▄▀░░█████░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█
█░░▄▀░░░░░░░░░░█░░▄▀░░█████████░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░░░▄▀░░███░░▄▀░░░░░░░░░░█████░░▄▀░░█████░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░▄▀░░█
█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░█████████░░▄▀░░██░░▄▀░░█░░▄▀▄▀▄▀▄▀▄▀▄▀░░███░░▄▀▄▀▄▀▄▀▄▀░░█████░░▄▀░░█████░░▄▀░░██░░▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█
█░░▄▀░░░░░░░░░░█░░▄▀░░█████████░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░▄▀░░░░███░░▄▀░░░░░░░░░░█████░░▄▀░░█████░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░░░░░█
█░░▄▀░░█████████░░▄▀░░█████████░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█████░░▄▀░░█████████████░░▄▀░░█████░░▄▀░░██░░▄▀░░█░░▄▀░░█████████
█░░▄▀░░█████████░░▄▀░░░░░░░░░░█░░▄▀░░░░░░▄▀░░█░░▄▀░░██░░▄▀░░░░░░█░░▄▀░░░░░░░░░░█████░░▄▀░░█████░░▄▀░░░░░░▄▀░░█░░▄▀░░█████████
█░░▄▀░░█████████░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█████░░▄▀░░█████░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░█████████
█░░░░░░█████████░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░██░░░░░░░░░░█░░░░░░░░░░░░░░█████░░░░░░█████░░░░░░░░░░░░░░█░░░░░░█████████
█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████ 
█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
██████████████████████████████████████████████████▄─▄▄─█─▄▄▄─█▄─▄▄▀█▄─▄▄─█▄─█─▄██████████████████████████████████████████████
███████████████████████████████████████████████████─▄███─███▀██─██─██─▄█▀██▄▀▄███████████████████████████████████████████████
██████████████████████████████████████████████████▄▄▄███▄▄▄▄▄█▄▄▄▄██▄▄▄▄▄███▄████████████████████████████████████████████████
█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
 */
namespace SpyGameWPF
{
    public partial class MainWindow : Window
    {

        public PreInit INIT = new PreInit();
        public Profiler PDB = new Profiler();
        public GameLogger GLOG = new GameLogger();
        public PlayerTurn PTRN = new PlayerTurn();        
        public int boolean = 0;

        public enum Direction { LEFT, RIGHT, UP, DOWN }
        public enum PlayerTurnSelect { JAIL, SEARCH, MOVE }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTN_EXIT_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MoverLeft_BTN(object sender, RoutedEventArgs e)
        {
            Button BTN = sender as Button;
            string Line = BTN.Name.Substring(4, 1);
            int EDITEDLINE = Convert.ToInt32(BTN.Name.Substring(4, 1)) - 1;

            PTRN.TurnMove(this, PDB.CharsEdited, EDITEDLINE, Direction.LEFT, PlayerTurnSelect.MOVE, Line);
            PTRN.Print(PDB.CharsEdited, this);
            INIT.InitDB(this);
            INIT.CRNMHighlight(this);
        }
        private void MoverRight_BTN(object sender, RoutedEventArgs e)
        {
            Button BTN = sender as Button;
            string Line = BTN.Name.Substring(4, 1);
            int EDITEDLINE = Convert.ToInt32(BTN.Name.Substring(4, 1)) - 1;

            PTRN.TurnMove(this, PDB.CharsEdited, EDITEDLINE, Direction.RIGHT, PlayerTurnSelect.MOVE, Line);
            PTRN.Print(PDB.CharsEdited, this);
            INIT.InitDB(this);
            INIT.CRNMHighlight(this);
        }
        private void MoverUp_BTN(object sender, RoutedEventArgs e)
        {
            Button BTN = sender as Button;
            string Line = BTN.Name.Substring(3, 1);
            int EDITEDLINE = Convert.ToInt32(BTN.Name.Substring(3, 1)) - 1;

            PTRN.TurnMove(this, PDB.CharsEdited, EDITEDLINE, Direction.UP, PlayerTurnSelect.MOVE, Line);
            PTRN.Print(PDB.CharsEdited, this);
            INIT.InitDB(this);
            INIT.CRNMHighlight(this);
        }
        private void MoverDown_BTN(object sender, RoutedEventArgs e)
        {
            Button BTN = sender as Button;
            string Line = BTN.Name.Substring(3, 1);
            int EDITEDLINE = Convert.ToInt32(BTN.Name.Substring(3, 1)) - 1;

            PTRN.TurnMove(this, PDB.CharsEdited, EDITEDLINE, Direction.DOWN, PlayerTurnSelect.MOVE, Line);
            PTRN.Print(PDB.CharsEdited, this);
            INIT.InitDB(this);
            INIT.CRNMHighlight(this);
        }

        private void ChangeCard_Click_1(object sender, RoutedEventArgs e)
        {
            PDB.RndPlayerChar(this);
            INIT.CRNMHighlight(this);
        }

        private void HOSTGAME_Click(object sender, RoutedEventArgs e)
        {
            PDB.RndPlayerChar(this);
            INIT.CRNMHighlight(this);
        }

        public void GAMEWINDOW_Loaded_1(object sender, RoutedEventArgs e)
        {
            INIT.PreInitialization(this);
            INIT.PreInitDB(this);
            PDB.ChrEditable(this);
            LoginPanel LPanel = new LoginPanel(this);
            this.Hide();
            LPanel.Owner = this;
            LPanel.ShowDialog();
        }

        public void onCellPress(object sender, RoutedEventArgs e)
        {
            if (PlayerTurnSearch.IsChecked == true)
            {
                boolean = 0;
                PTRN.TurnSearch(this, sender, PlayerTurnSelect.SEARCH, Direction.LEFT);
            }
            else if (PlayerTurnJail.IsChecked == true)
            {
                PTRN.TurnJail(this, sender, PlayerTurnSelect.JAIL, Direction.LEFT);
            }
        }

        public void PlayerRename(LoginPanel LPan, string Username)
        {
            PlayerName.Content = Username;
        }
    }
}

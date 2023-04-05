using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
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
namespace SpyGameWPF.BLOCKS
{
    public class PreInit
    {
        public Button[,] BTN = null;
        public string[,] KEY = null;

        public void PreInitialization(MainWindow GameWindow)
        {
            //LEFT PANEL
            //BTN EXIT
            GameWindow.BTN_EXIT.Content = "Выход";
            GameWindow.BTN_EXIT.FontSize = 20;
            GameWindow.BTN_EXIT.FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light Condensed");
            GameWindow.BTN_EXIT.BorderBrush = System.Windows.Media.Brushes.Transparent;
            GameWindow.BTN_EXIT.BorderThickness = new Thickness(0);
            GameWindow.BTN_EXIT.Background = Brushes.DimGray;
            GameWindow.BTN_EXIT.Foreground = Brushes.Black;
            //BTN HOST
            GameWindow.HOSTGAME.Content = "Создать игру";
            GameWindow.HOSTGAME.FontSize = 20;
            GameWindow.HOSTGAME.FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light Condensed");
            GameWindow.HOSTGAME.BorderBrush = System.Windows.Media.Brushes.Transparent;
            GameWindow.HOSTGAME.BorderThickness = new Thickness(0);
            GameWindow.HOSTGAME.Background = Brushes.DimGray;
            GameWindow.HOSTGAME.Foreground = Brushes.Black;
            //BTN CONNECT
            GameWindow.JOINGAME.Content = "Подключиться к игре";
            GameWindow.JOINGAME.FontSize = 20;
            GameWindow.JOINGAME.FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light Condensed");
            GameWindow.JOINGAME.BorderBrush = System.Windows.Media.Brushes.Transparent;
            GameWindow.JOINGAME.BorderThickness = new Thickness(0);
            GameWindow.JOINGAME.Background = Brushes.DimGray;
            GameWindow.JOINGAME.Foreground = Brushes.Black;
            //GAMENAME
            GameWindow.GAMENAME.Content = "НУАР\nШпионские игры";
            GameWindow.GAMENAME.FontSize = 20;
            GameWindow.GAMENAME.FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light Condensed");
            GameWindow.GAMENAME.Foreground = Brushes.White;
            GameWindow.GAMENAME.HorizontalAlignment = HorizontalAlignment.Right;
            //GAMEPANEL
            //RIGHTPANEL
            GameWindow.GameLogsOutput.Text = "";
            //PLAYER TURN PANEL
            GameWindow.PlayerTurnSearch.Content = "Допросить подозреваемого";
            GameWindow.PlayerTurnSearch.FontSize = 15;
            GameWindow.PlayerTurnSearch.Foreground = Brushes.White;
            GameWindow.PlayerTurnSearch.FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light Condensed");
            GameWindow.PlayerTurnJail.Content = "Посадить шпионюгу";
            GameWindow.PlayerTurnJail.FontSize = 15;
            GameWindow.PlayerTurnJail.Foreground = Brushes.White;
            GameWindow.PlayerTurnJail.FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Light Condensed");
        }

        public void PreInitDB(MainWindow MWIND)
        {
            BTN = new[,] {
            {MWIND.CELL1, MWIND.CELL2, MWIND.CELL3, MWIND.CELL4, MWIND.CELL5},
            {MWIND.CELL6, MWIND.CELL7, MWIND.CELL8, MWIND.CELL9, MWIND.CELL10},
            {MWIND.CELL11, MWIND.CELL12,MWIND.CELL13, MWIND.CELL14, MWIND.CELL15},
            {MWIND.CELL16, MWIND.CELL17, MWIND.CELL18, MWIND.CELL19, MWIND.CELL20},
            {MWIND.CELL21, MWIND.CELL22, MWIND.CELL23, MWIND.CELL24, MWIND.CELL25}
            };

            for (int i = 0; i < BTN.GetLength(0); i++)
            {
                for (int j = 0; j < BTN.GetLength(1); j++)
                {
                    BTN[i, j].Content = MWIND.PDB.Characters[i, j];
                    BTN[i, j].FontSize = 15;
                    BTN[i, j].VerticalContentAlignment = VerticalAlignment.Bottom;
                    BTN[i, j].HorizontalContentAlignment = HorizontalAlignment.Right;
                    BTN[i, j].Background = Brushes.Gray;
                    BTN[i, j].FontFamily = new System.Windows.Media.FontFamily("Bahnschrift Condensed");

                    KEY = MWIND.PDB.Characters;
                }
            }
        }

        public void InitDB(MainWindow MWIND)
        {
            for (int i = 0; i < BTN.GetLength(0); i++)
            {
                for (int j = 0; j < BTN.GetLength(1); j++)
                {
                    BTN[i, j].Content = MWIND.PDB.CharsEdited[i, j];

                    KEY = MWIND.PDB.CharsEdited;
                }
            }
        }
        public void CRNMHighlight(MainWindow MWIND)
        {
            for (int i = 0; i < BTN.GetLength(0); i++)
            {
                for (int j = 0; j < BTN.GetLength(1); j++)
                {
                    if (MWIND.PlayerCharName.Content.ToString() == KEY[i, j])
                    {
                        BTN[i, j].Background = Brushes.PaleGreen;
                        BTN[i, j].Foreground = Brushes.Black;
                    }
                    else if (BTN[i, j].Content.ToString() != "Мёртв")
                    {
                        BTN[i, j].Background = Brushes.Gray;
                        BTN[i, j].Foreground = Brushes.Black;
                    }
                    else if (BTN[i, j].Content.ToString() == "Мёртв")
                    {
                        BTN[i, j].Background = Brushes.DarkRed;
                        BTN[i, j].Foreground = Brushes.White;
                    }
                }
            }
        }
    }
}

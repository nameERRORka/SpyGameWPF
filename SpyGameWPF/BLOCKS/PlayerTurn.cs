using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Forms;
using System.Diagnostics;
using MessageBox = System.Windows.Forms.MessageBox;
using Button = System.Windows.Controls.Button;
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
    public class PlayerTurn
    {
        public int COSTYL = 0;
        string ENEMY = "Иван";
        public void ChangeCard(MainWindow FRM1, object sender)
        {
            Button BTN = sender as Button;
            if (BTN.Content.ToString() != "Мёртв")
            {
                FRM1.PDB.RndPlayerChar(FRM1);
                FRM1.INIT.CRNMHighlight(FRM1);
            }
        }
        public void TurnSearch(MainWindow FRM1, object send, MainWindow.PlayerTurnSelect PTSLCT, MainWindow.Direction DIRS)
        {
            Button BTN = send as Button;
            
            int l = 0, r = 0;
            int SMX = 3, SMY = 3;
            string[,] FINDER = new string[SMX, SMY];
            string[,] SelectedMass = new string[SMX, SMY];
            int SelectedMassX = 0, SelectedMassY = 0;
            for (int i = 0; i < FRM1.PDB.CharsEdited.GetLength(0); i++)
            {
                for (int j = 0; j < FRM1.PDB.CharsEdited.GetLength(1); j++)
                {
                    if (BTN.Content.ToString() == FRM1.PDB.CharsEdited[i, j])
                    {
                        SelectedMassX = i;
                        SelectedMassY = j;
                        break;
                    }
                }
            }

            for (int a = SelectedMassX - 1; a <= SelectedMassX + 1; a++)
            {
                for (int b = SelectedMassY - 1; b <= SelectedMassY + 1; b++)
                {
                    if (a < 0 || a > 4)
                    {
                        SMX--;
                    }
                    else if (b < 0 || b > 4)
                    {
                        SMY--;
                    }
                    else
                    {
                        SelectedMass[l, r] = FRM1.PDB.CharsEdited[a, b];
                        r++;
                    }
                }
                l++; r = 0;
            }
            FINDER = SelectedMass;

            for (int i = 0; i < FINDER.GetLength(0); i++)
            {
                for (int j = 0; j < FINDER.GetLength(1); j++)
                {
                    if (FINDER[i, j] == FRM1.PlayerCharName.Content.ToString())
                    {
                        foreach (string s in FINDER)
                        {
                            if (s == ENEMY)
                            {
                                FRM1.boolean = 1;
                                MessageBox.Show("В поле допроса обнаружен шпион!!!", "Результаты допроса", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                FRM1.GLOG.Logger(FRM1, DIRS, PTSLCT, BTN.Content.ToString(), null);
                            }
                            else if (COSTYL == 0)
                            {
                                FRM1.GLOG.Logger(FRM1, DIRS, PTSLCT, BTN.Content.ToString(), null);
                                COSTYL++;
                            }
                        }
                    }
                }
            }
        }

        public void TurnJail(MainWindow FRM1, object send, MainWindow.PlayerTurnSelect PTSLCT, MainWindow.Direction DIRS)
        {
            Button BTN = send as Button;
            int l = 0, r = 0;
            int SMX = 3, SMY = 3;
            string[,] FINDER = new string[SMX, SMY];
            string[,] SelectedMass = new string[SMX, SMY];
            int SelectedMassX = 0, SelectedMassY = 0;
            for (int i = 0; i < FRM1.PDB.CharsEdited.GetLength(0); i++)
            {
                for (int j = 0; j < FRM1.PDB.CharsEdited.GetLength(1); j++)
                {
                    if (BTN.Content.ToString() == FRM1.PDB.CharsEdited[i, j])
                    {
                        SelectedMassX = i;
                        SelectedMassY = j;
                        break;
                    }
                }
            }

            for (int a = SelectedMassX - 1; a <= SelectedMassX + 1; a++)
            {
                for (int b = SelectedMassY - 1; b <= SelectedMassY + 1; b++)
                {
                    if (a < 0 || a > 4)
                    {
                        SMX--;
                    }
                    else if (b < 0 || b > 4)
                    {
                        SMY--;
                    }
                    else
                    {
                        SelectedMass[l, r] = FRM1.PDB.CharsEdited[a, b];
                        r++;
                    }
                }
                l++; r = 0;
            }

            FINDER = SelectedMass;

            for (int i = 0; i < FINDER.GetLength(0); i++)
            {
                for (int j = 0; j < FINDER.GetLength(1); j++)
                {
                    if (FINDER[i, j] == FRM1.PlayerCharName.Content.ToString())
                    {
                        foreach (string s in FINDER)
                        {
                            if (s == ENEMY && BTN.Content.ToString() == s)
                            {
                                string WhoIsJailed = BTN.Content.ToString();
                                BTN.Content = "Мёртв";
                                FRM1.PDB.CharsEdited[SelectedMassX, SelectedMassY] = "Мёртв";
                                FRM1.INIT.CRNMHighlight(FRM1);

                                DialogResult result;
                                result = MessageBox.Show("Вы посадили шпиона!!!", "Результаты захвата", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                if (result == DialogResult.OK)
                                {
                                    FRM1.GLOG.Logger(FRM1, DIRS, PTSLCT, WhoIsJailed, null);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void TurnMove(MainWindow FRM1, string[,] arr, int RCidx, MainWindow.Direction DIRS, MainWindow.PlayerTurnSelect PTSLCT, string LINE)
        {
            arr = FRM1.PDB.CharsEdited;
            if (arr == null || RCidx < 0) return;
            string temp;
            switch (DIRS)
            {
                case MainWindow.Direction.UP:
                    temp = arr[0, RCidx];
                    for (int i = 1; i < arr.GetLength(0); i++)
                        arr[i - 1, RCidx] = arr[i, RCidx];
                    arr[arr.GetLength(0) - 1, RCidx] = temp;

                    FRM1.GLOG.Logger(FRM1, DIRS, PTSLCT, "", LINE);

                    break;

                case MainWindow.Direction.DOWN:
                    temp = arr[arr.GetLength(0) - 1, RCidx];
                    for (int i = arr.GetLength(0) - 1; i > 0; i--)
                        arr[i, RCidx] = arr[i - 1, RCidx];
                    arr[0, RCidx] = temp;

                    FRM1.GLOG.Logger(FRM1, DIRS, PTSLCT, "", LINE);

                    break;

                case MainWindow.Direction.LEFT:
                    temp = arr[RCidx, 0];
                    for (int i = 1; i < arr.GetLength(1); i++)
                        arr[RCidx, i - 1] = arr[RCidx, i];
                    arr[RCidx, arr.GetLength(1) - 1] = temp;

                    FRM1.GLOG.Logger(FRM1, DIRS, PTSLCT, "", LINE);

                    break;

                case MainWindow.Direction.RIGHT:
                    temp = arr[RCidx, arr.GetLength(1) - 1];
                    for (int i = arr.GetLength(1) - 1; i > 0; i--)
                        arr[RCidx, i] = arr[RCidx, i - 1];
                    arr[RCidx, 0] = temp;

                    FRM1.GLOG.Logger(FRM1, DIRS, PTSLCT, "", LINE);

                    break;
            }
        }
        public void Print(string[,] arr, MainWindow FRM1)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    FRM1.PDB.CharsEdited[i, j] = arr[i, j];
                    FRM1.INIT.CRNMHighlight(FRM1);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyGameWPF.BLOCKS
{
    public class GameLogger
    {
        public void Logger(MainWindow FRM1, MainWindow.Direction DIRECT, MainWindow.PlayerTurnSelect PTSLCT, string CharName, string LINE)
        {
            switch (PTSLCT)
            {
                case MainWindow.PlayerTurnSelect.SEARCH:
                    if (FRM1.boolean == 0)
                    {
                        FRM1.GameLogsOutput.Text += "Игрок " + FRM1.PlayerName.Content + " допросил " + CharName + " и шпионов не нашел." + Environment.NewLine;
                    } else if (FRM1.boolean > 0)
                    {
                        FRM1.GameLogsOutput.Text += "Игрок " + FRM1.PlayerName.Content + " допросил " + CharName + " и нашел шпиона!" + Environment.NewLine;
                    }
                    break;

                case MainWindow.PlayerTurnSelect.JAIL:
                    FRM1.GameLogsOutput.Text += "Игрок " + FRM1.PlayerName.Content + " посадил " + CharName + Environment.NewLine;
                    break;

                case MainWindow.PlayerTurnSelect.MOVE:
                    FRM1.GameLogsOutput.Text += "Игрок " + FRM1.PlayerName.Content + " сдвинул " + LINE + " ряд" + Environment.NewLine;
                    break;
            }
        }
    }
}

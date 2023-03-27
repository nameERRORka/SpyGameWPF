using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyGameWPF.BLOCKS
{
    public class Profiler
    {
        //Первичный массив
        public string[,] Characters = new string[,] {   {"Виктор", "Игорь", "Александр", "Сергей", "Максим"},
                                                        {"Наталья", "Людмила", "Евгения","Ольга","Виктория"},
                                                        {"Константин","Антон","Никита","Роман","Андрей"},
                                                        {"Милана","Елена","Степан","Юрий","Станислав"},
                                                        {"Иван","Зоя","Зина","Люся","Яков" } };

        //Игровой массив
        public string[,] CharsEdited = new string[,] { };

        public void ChrEditable(MainWindow MWIND)
        {
            CharsEdited = Characters; //Присвоение предстартовое
        }

        public void RndPlayerChar(MainWindow MWIND) //Рандомайзер для игрока
        {
            Random rnd = new Random();

            int col = rnd.Next(0, CharsEdited.GetLength(0));
            int row = rnd.Next(0, CharsEdited.GetLength(1));
            if (CharsEdited[col, row] != "Мёртв")
            {
                MWIND.PlayerCharName.Content = CharsEdited[col, row];
            }
        }
    }
}

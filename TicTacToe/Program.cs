using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void ShowField(int[,] mass2)
        {
            for (int i = 0; i < mass2.GetLength(0); i++)
            {
                for (int j = 0; j < mass2.GetLength(1); j++)
                {
                    if (mass2[i, j] == 1)
                    Console.Write("x");
                    else
                        if (mass2[i, j] == 2)
                        Console.Write("o");
                        else
                        Console.Write("_");
                }
                Console.WriteLine();
            }
        }

        static bool SetValue(int[,] mass2, int row, int col, int value)
        {
            if (row >= 0 && row < mass2.GetLength(0) && col >= 0 && col < mass2.GetLength(1) && (value == 1 || value == 2) && mass2[row, col] == 0)
            {
                mass2[row, col] = value;
                return true;
            }
            return false;
        }

        static void ChangeTicTac(ref int a)
        {
            if (a == 1) a = 2;
            else a = 1;
        }

        static bool IsWin(int[,] mass2, int tictac)
        {
            int count_main_diagon = 0, count_other_diagon = 0;

            for (int j = 0; j < mass2.GetLength(1); j++)
            {
                if (mass2[j, j] == tictac) count_main_diagon++;
                if (mass2[j, mass2.GetLength(1) - j - 1] == tictac) count_other_diagon++;

                int count_row = 0, count_col = 0;
                for (int i = 0; i < mass2.GetLength(0); i++)
                {
                    if (mass2[j, i] == tictac) count_row++;
                    if (mass2[i, j] == tictac) count_col++;
                }
                if (count_row == mass2.GetLength(0)) return true;
                if (count_col == mass2.GetLength(1)) return true;
            }

            if (count_main_diagon == mass2.GetLength(1)) return true;
            if (count_other_diagon == mass2.GetLength(1)) return true;
            return false;
        }

        static void Main(string[] args)
        {
            int[,] field = new int[3, 3];
            int ticTac = 1;
            ShowField(field);
            while (true)
            {
                Console.WriteLine("Введите координаты хода");
                string[] temp = Console.ReadLine().Split();
                int row = Convert.ToInt32(temp[0]);
                int col = Convert.ToInt32(temp[1]);
                if (SetValue(field, row, col, ticTac))
                {
                    ShowField(field);
                    if (IsWin(field, ticTac))
                    {
                        Console.WriteLine("Вы победили");
                        break;
                    }
                    ChangeTicTac(ref ticTac);

                }
                else
                {
                    Console.WriteLine("так нельзя");
                }
            }
        }
    }
}

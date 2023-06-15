using System;
using SimpleAutoChess;

namespace SimpleAutoChess
{
    public class Display
    {
        public void ShowBoard(IPosition position, IUnit unit)
        {
            string[,] matrix = new string[4, 8];
            var height = matrix.GetLength(0);
            var width = matrix.GetLength(1);

            //place units
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 2 && j == 3)
                    {
                        matrix[i, j] = "[unit]";
                    }
                    else if (i == 6 && j == 8)
                    {
                        matrix[i, j] = "[unit]";
                    }
                    else
                    {
                        matrix[i, j] = "[    ]";
                    }
                }
            }
            //Print Board
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

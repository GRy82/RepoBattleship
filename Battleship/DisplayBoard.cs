using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public static class DisplayBoard
    {
        public static void DisplaySingleBoard(int[,] boardCoordinates)
        {
            WriteColumnHeader();
            WriteRemaining(boardCoordinates);
        }

        private static void WriteColumnHeader()
        {
            Console.Write("\n  ");
            for (int i = 1; i <= 20; i++)
            {
                Console.Write("  ");
                if (i < 10)
                {
                    Console.Write("0" + i + " ");
                    
                }
                else
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine("\n");
        }

        private static void WriteRemaining(int[,] boardCoordinates)
        {
            for (int i = 0; i < 20; i++)
            {
                Console.Write(Convert.ToChar(i + 65) + " ");
                for (int j = 0; j < 20; j++)
                {
                    Console.Write("[");
                    if (boardCoordinates[i,j] == 0) {
                        Console.Write("   ");
                    }
                    else {
                        Console.Write(" X ");
                    }
                    Console.Write("]");
                }
                Console.WriteLine("\n");
            }
        }

        private static string ConvertCoordinate(int row, int column)
        {
            string stringVersion = "";
            int rowCoordinate = row + 65;
            char rowChar = Convert.ToChar(rowCoordinate);
            stringVersion += Convert.ToString(rowChar);
            if (column < 10)
            {
               stringVersion += ":0" + Convert.ToString(column);
            }
            else
            {
                stringVersion += ":" + Convert.ToString(column);
            }
            return stringVersion;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] ownedBoard = new int[21, 21];
            int[,] opponentBoard = new int[21, 21];
            for (int i = 1; i < 21; i++)
            {
                ownedBoard[0, i] = i;
                opponentBoard[0, i] = i;
                ownedBoard[i, 0] = i + 64;
                opponentBoard[i, 0] = i + 64;
            }
            //fill in all other 
            for (int j = 1; j < 21; j++)
            {
                for (int k = 1; k < 21; k++)
                {
                    ownedBoard[j, k] = 79;
                    opponentBoard[j, k] = 79;
                }
            }
            for (int j = 0; j < 21; j++)
            {
                for (int k = 0; k < 21; k++)
                {
                    if (j != 0)
                    {
                        char character = Convert.ToChar(ownedBoard[j, k]);
                        string space = Convert.ToString(character);
                        Console.Write(" " + space);
                    }
                    else
                    {
                        if (ownedBoard[j, k] < 10){
                            Console.Write("0" + ownedBoard[j, k]);
                        }
                        else {
                            Console.Write(ownedBoard[j, k]);
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
            Game battleship = new Game();
            battleship.Run();
        }
    }
}

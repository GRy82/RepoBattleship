using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class BattleConsole
    {
        public char emptySpace = 'O'; //This is a ascii code 79
        public int[,] ownedBoard;
        public int[,] opponentBoard;
        public List<Ship> ownedShips;
        public BattleConsole(List<Ship> ownedShips)
        {
            this.ownedShips = ownedShips;
            ownedBoard = GenerateEmptyBoard();
            opponentBoard = GenerateEmptyBoard();
        }

        public int[,] GenerateEmptyBoard()
        {
            int[,] board = new int[20, 20];//[row,column]
 
            //fill in all other 
            for (int i = 0; i < 20; i++)//row
            {
                for (int j = 0; j < 20; j++)//column.
                {
                    board[i, j] = 0;
                }
            }
            return board;
        }

    }
}

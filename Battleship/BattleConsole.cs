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
            int[,] board = new int[20, 20];
            //Fill in the top row from index 1-21 with 1-21.
            //Fill in the Left-most column with Ascii values of letters A-T from index 1-21
            for (int i = 1; i < 21; i++){
                board[0, i] = i + 48; 
                board[i, 0] = i + 64;
            }
            //fill in all other 
            for (int j = 1; j < 21; j++)
            {
                for (int k = 1; k < 21; k++)
                {
                    board[j, k] = 79;
                }
            }
            return board;
        }

    }
}

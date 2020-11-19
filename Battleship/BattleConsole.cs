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
        public int[,] ownedBoard = new int[21, 21];
        public int[,] opponentBoard = new int[21, 21];
        public List<Ship> ownedShips;
        public BattleConsole(List<Ship> ownedShips)
        {
            this.ownedShips = ownedShips;
        }

        public void GenerateEmptyBoards()
        {
            //Fill in the top row from index 1-21 with 1-21.
            //Fill in the Left-most column with Ascii values of letters A-T from index 1-21
            for (int i = 1; i < 22; i++){
                ownedBoard[0, i] = i; 
                opponentBoard[0, i] = i;
                ownedBoard[i, 0] = i + 64;
                opponentBoard[i, 0] = i + 64;
            }
            //fill in all other 
            for (int j = 1; j < 22; j++)
            {
                for (int k = 1; k < 22; k++)
                {
                    ownedBoard[j, k] = 79;
                    opponentBoard[j, k] = 79;
                }
            }
        }

    }
}

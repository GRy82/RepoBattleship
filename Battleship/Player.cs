using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Player
    {
        
        public string name;
        public BattleConsole battleConsole;
        public List<string> destroyedShips;
        

        public Player()
        {

        }


         //--------------------------Board Setting Methods------------------------//
        //-----------------------------------------------------------------------//
        public virtual void SetBoard()
        {

        }


        private bool FirstCoordinateValidation(int rowNum, int columnNum, int length)
        {
            int validDirectionCount = 0;
            if (CheckUp(rowNum, columnNum, length)) {
                validDirectionCount++;
            }
            if (CheckDown(rowNum, columnNum, length)) {
                validDirectionCount++;
            }
            if (CheckRight(rowNum, columnNum, length)) {
                validDirectionCount++;
            }
            if (CheckLeft(rowNum, columnNum, length)) {
                validDirectionCount++;
            }
            if(validDirectionCount > 0) {
                return true;
            }
            return false;
        }

        private bool CheckUp(int rowNum, int columnNum, int length)
        {
            if (rowNum - (length - 1) < 0) { //Check for out of bounds proposition.
                return false;
            }
            for(int i = rowNum; i >= rowNum - (length - 1); i--)
            {
                if (battleConsole.ownedBoard[i, columnNum] == 1) {
                    return false;
                }
            }
            return true;
        }

        private bool CheckDown(int rowNum, int columnNum, int length)
        {
            if (rowNum + (length - 1) > 19) { //Check for out of bounds proposition.
                return false;
            }
            for (int i = rowNum; i <= rowNum + (length - 1); i++)
            {
                if (battleConsole.ownedBoard[i, columnNum] == 1) {
                    return false;
                }
            }
            return true;
        }


        private bool CheckRight(int rowNum, int columnNum, int length)
        {
            if (columnNum + (length - 1) > 19) { //Check for out of bounds proposition.
                return false;
            }
            for (int i = columnNum; i <= columnNum + (length - 1); i++)
            {
                if (battleConsole.ownedBoard[rowNum, i] == 1) {
                    return false;
                }
            }
            return true;
        }

        private bool CheckLeft(int rowNum, int columnNum, int length)
        {
            if (columnNum - (length - 1) < 0) { //Check for out of bounds proposition.
                return false;
            }
            for (int i = columnNum; i >= columnNum - (length - 1); i--)
            {
                if (battleConsole.ownedBoard[rowNum, i] == 1) {
                    return false;
                }
            }
            return true;
        }


     //-----------------------------------------------------------------------//
    //-----------------------------------------------------------------------//





}
}

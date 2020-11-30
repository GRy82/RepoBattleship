using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    abstract public class Player
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
            foreach (Ship ship in battleConsole.ownedShips)
            {
                int[] firstCoordinate = GetFirstCoord(ship.name, ship.length);
                int orientation = GetOrientation(firstCoordinate, ship.length); //1 is up, 2 is down, 3 is left, 4 is right.
                RegisterCoordinates(firstCoordinate, orientation, ship.length);
            }
        }

        public abstract int[] GetFirstCoord(string name, int shipLength);

        protected bool FirstCoordinateValidation(int rowNum, int columnNum, int length)
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

        protected bool CheckUp(int rowNum, int columnNum, int length)
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

        protected bool CheckDown(int rowNum, int columnNum, int length)
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


        protected bool CheckRight(int rowNum, int columnNum, int length)
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

        protected bool CheckLeft(int rowNum, int columnNum, int length)
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


        protected int GetOrientation(int[] firstCoordinate, int shipLength)
        {
            bool isValidOrientation = false;
            int numericSelection;
            do
            {
                numericSelection = GetCorrespondingOrientationNum(firstCoordinate);
                switch (numericSelection)
                {
                    case 1:
                        isValidOrientation = CheckUp(firstCoordinate[0], firstCoordinate[1], shipLength);
                        break;
                    case 2:
                        isValidOrientation = CheckDown(firstCoordinate[0], firstCoordinate[1], shipLength);
                        break;
                    case 3:
                        isValidOrientation = CheckLeft(firstCoordinate[0], firstCoordinate[1], shipLength);
                        break;
                    case 4:
                        isValidOrientation = CheckRight(firstCoordinate[0], firstCoordinate[1], shipLength);
                        break;
                }
            } while (!isValidOrientation);

            return numericSelection;
        }

        public abstract int GetCorrespondingOrientationNum(int[] firstCoordinate);


        protected void RegisterCoordinates(int[] firstCoordinate, int orientation, int shipLength)
        {
            int incrementer = 1;
            int counter;
            int terminatingIndex;
            if (orientation == 1 || orientation == 3)
            {
                incrementer = -1;
            }

            if (orientation == 1 || orientation == 2)
            {
                counter = firstCoordinate[1];
                terminatingIndex = firstCoordinate[1] + shipLength * incrementer;
                while (counter != terminatingIndex)
                {
                    battleConsole.ownedBoard[firstCoordinate[0], counter] = 1; //equals 1 means portion of a ship is present.
                    counter += incrementer;
                }
            }
            else
            {
                counter = firstCoordinate[0];
                terminatingIndex = firstCoordinate[0] + shipLength * incrementer;
                while (counter != terminatingIndex)
                {
                    battleConsole.ownedBoard[counter, firstCoordinate[1]] = 1; //equals 1 means portion of a ship is present.
                    counter += incrementer;
                }
            }
        }



        //-----------------------------------------------------------------------//
        //-----------------------------------------------------------------------//


    }
}

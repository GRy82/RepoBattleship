using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    abstract class Player
    {
        
        public string name;
        public BattleConsole battleConsole;
        public List<string> destroyedShips;
        

        public Player()
        {

        }

        public abstract void OptionsMenu();
        public abstract void SelectTargetCoord();

        public abstract void SetBoard();

        public abstract Coordinates GetStartingCoordinate();
        public abstract int GetOrientation(Coordinates coords, Ship ship);
       

        public void AssignAnchorPointsToShip(int orientation, Coordinates startingCoordinates, Ship ship)
        {
            ship.edgeOne.Row = startingCoordinates.Row;
            ship.edgeOne.Column = startingCoordinates.Column;
            battleConsole.ownedBoard[(int)ship.edgeOne.Row - 64, ship.edgeOne.Column + 1] = 35;
            int increment = SetIncrement(orientation);// orientation is a number 1-4, representing { "Up", "Down", "Left", "Right" };   
            for (int i = (int)ship.edgeOne.Row, j = ship.edgeOne.Column; i < (int)ship.edgeTwo.Row && j < ship.edgeTwo.Column; i += increment, j += increment)
            {
                if (orientation == 1 || orientation == 2)
                {//Vertically aligned  
                    ship.coordsList.Add(new Coordinates(Convert.ToChar(i), ship.edgeOne.Column));
                    battleConsole.ownedBoard[i - 64, ship.edgeOne.Column] = 35;
                }
                else
                {//Horizontally aligned.
                    ship.coordsList.Add(new Coordinates(ship.edgeOne.Row, j));
                    battleConsole.ownedBoard[(int)ship.edgeOne.Row - 64, j + 1] = 35;
                }
            }
        }

        public int SetIncrement(int optionSelected)
        {
            int increment;
            if (optionSelected == 1 || optionSelected == 3)
            { //if 'up' or 'left' selected, 'i' in future for-loop will be decremented
                increment = -1;
            }
            else
            {//if 'down' or 'right' selected, 'i' in future for-loop will be incremented
                increment = 1;
            }
            return increment;
        }

        public bool CheckInterference(Coordinates startingCoords, int optionSelected, Ship ship)
        {
            List<int> numericalCoords = new List<int> { (startingCoords.Row - 65 + 1), startingCoords.Column + 1 }; //-65 to align with numbers, + 1 to set it to second row(1st row is a table header)
            List<int> prospectiveCoords = numericalCoords;
            int increment = SetIncrement(optionSelected);
            if (optionSelected == 1 || optionSelected == 2)
            { //if 'up' or 'down', search through different rows at same column.
                for (int i = numericalCoords[0]; i < (numericalCoords[0] + ship.length * increment); i += increment)
                {
                    prospectiveCoords[0] = i;
                    if (!Coordinates.CheckCoord(battleConsole, Coordinates.ConvertCoord(prospectiveCoords)))
                    {
                        return false;
                    }
                }
            }
            else
            {//if 'left' or 'right', search through different columns at the given row.
                for (int i = numericalCoords[1]; i < (numericalCoords[1] + ship.length * increment); i += increment)
                {
                    prospectiveCoords[1] = i;
                    if (!Coordinates.CheckCoord(battleConsole, Coordinates.ConvertCoord(prospectiveCoords)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckFit(Coordinates startingCoords, int numberRepresentedOrientation, Ship ship)// orientation is a number 1-4, representing { "Up", "Down", "Left", "Right" };
        {
            if (numberRepresentedOrientation == 1 && (Convert.ToInt32(startingCoords.Row) - ship.length) < 64)
            {
                return false;
            }
            if (numberRepresentedOrientation == 2 && (Convert.ToInt32(startingCoords.Row) + ship.length) > 85)
            {
                return false;
            }
            if (numberRepresentedOrientation == 3 && (startingCoords.Column - ship.length) < 0)
            {
                return false;
            }
            if (numberRepresentedOrientation == 4 && (startingCoords.Column + ship.length) > 21)
            {
                return false;
            }
            return true;
        }

    }
}

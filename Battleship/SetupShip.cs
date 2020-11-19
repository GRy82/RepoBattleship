using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProblemSolving1;

namespace Battleship
{
    class SetupShip
    {
        BattleConsole battleConsole;

        public SetupShip(BattleConsole battleConsole)
        {
            this.battleConsole = battleConsole;
         
        }

        public struct coordinate
        {
            public char row;
            public int column;
        }

        ConsoleOptionsInterface orientationMenu;
        public void SetShip(Ship ship)
        {
            Console.WriteLine("Choose a space for one end of your " + ship.name + " of size " + ship.length + ". (eg. B:13)");
            coordinate coords = GetStartingCoordinate();
            Console.WriteLine("Choose an orientation");
            string orientationSelection = GetOrientation(coords, ship);
            AssignAnchorPointsToShip(ship, orientationSelection, coords);
        }

        void AssignAnchorPointsToShip(Ship ship, string orientation, coordinate startingCoordinates)
        {

        }

        coordinate GetStartingCoordinate()
        {
            string userInput;
            coordinate coords;
            do {
                do {
                    userInput = Console.ReadLine();
                } while (!ValidCoord(userInput));
                coords = ConvertCoord(userInput);
            } while (!AvailableCoord(coords));
            return coords;   
        }

        string GetOrientation(coordinate coords, Ship ship)
        {
            List<string> orientationOptions = new List<string> { "Up", "Down", "Left", "Right" };
            orientationMenu = new ConsoleOptionsInterface(orientationOptions, false, false);
            int optionSelected;
            do
            {
                optionSelected = orientationMenu.Launch();
            } while (!ValidPlacement(coords, optionSelected, ship));

            return orientationOptions[optionSelected-1];//optionSelected is the number option entered. That - 1 is the index of the word chosen in the list.
        }


        bool ValidCoord(string userInput)
        {
            int colonCounter = 0;
            foreach (char character in userInput) {
                if(character == 58) {
                    colonCounter++;
                }
            }
            if (colonCounter != 1) {
                return false;
            }
            string[] coordPieces = userInput.Split(':');
            if (coordPieces[0].Length != 1 && (coordPieces[1].Length < 1 || coordPieces[1].Length > 2)) {
                return false;
            }
            coordPieces[0] = coordPieces[0].ToUpper();
            char coordPieceChar = Convert.ToChar(coordPieces[0]);
            if (coordPieceChar > 90 || coordPieceChar < 65) {
                return false;
            }
            foreach (char character in coordPieces[1]) {
                if (character < 48 || character > 57) {
                    return false;
                }
            }
            return true;
        }

        coordinate ConvertCoord(string coord)
        {
            coordinate coords;
            string[] splitString = coord.Split(':');
            coords.column = int.Parse(splitString[1]);
            coords.row = Convert.ToChar(splitString[0]);
            return coords;
        }

        coordinate ConvertCoord(List<int> numericalCoords)
        {
            coordinate coords;
            coords.column = numericalCoords[1];
            coords.row = Convert.ToChar(numericalCoords[0]);
            return coords;
        }

        bool AvailableCoord(coordinate coords)
        {
            if (battleConsole.ownedBoard[coords.row, coords.column] != 79)
            {
                Console.WriteLine("\nShip cannot be placed there.");
                return false;
            }
            return true;
        }

        bool ValidPlacement(coordinate coords, int optionSelected, Ship ship)
        {
            int increment;
            List<int> numericalCoords = new List<int> { (coords.row - 65 + 1), coords.column }; //-65 to align with numbers, + 1 to set it to second row(1st row is a table header)
            List<int> prospectiveCoords = numericalCoords;
            if (optionSelected == 1 || optionSelected == 3)
            { //if 'up' or 'left' selected, 'i' in future for-loop will be decremented
                increment = -1;
            }
            else
            {//if 'down' or 'right' selected, 'i' in future for-loop will be incremented
                increment = 1;
            }
            if (optionSelected == 1 || optionSelected == 2)
            { //if 'up' or 'down', search through different rows at same column.
                for (int i = numericalCoords[0]; i < (numericalCoords[0] + ship.length * increment); i += increment)
                {
                    prospectiveCoords[0] = i;
                    if (!AvailableCoord(ConvertCoord(prospectiveCoords)))
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
                    if (!AvailableCoord(ConvertCoord(prospectiveCoords)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

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
            coordinate coords = GetCoordinate();
            Console.WriteLine("Choose an orientation");
            List<string> orientationOptions = new List<string> { "Up", "Down", "Left", "Right" };
            orientationMenu = new ConsoleOptionsInterface(orientationOptions, false, false);
            int optionSelected;
            do
            {
                optionSelected = orientationMenu.Launch();
            } while (!ValidPlacement(coords, optionSelected, ship));
        }

        coordinate GetCoordinate()
        {
            string userInput;
            coordinate coords;
            do {
                do {
                    userInput = Console.ReadLine();
                } while (!ValidCoord(userInput));
                coords = ConvertCoord(userInput);
            } while (!AvailableCoord(coords));
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

        bool AvailableCoord(coordinate coords)
        {
            if (battleConsole.ownedBoard[coords.row, coords.column] != 79)
            {
                Console.WriteLine("\nShip cannot be placed there.");
                return false;
            }
            return true;
        }

        bool ValidPlacement(List<int> coords, int optionSelected, Ship ship)
        {
            int increment;
            List<int> prospectiveCoords = new List<int> { coords[0], coords[1] };
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
                for (int i = coords[0]; i < (coords[0] + ship.length * increment); i += increment)
                {
                    prospectiveCoords[0] = i;
                    if (!ValidCoord(prospectiveCoords))
                    {
                        return false;
                    }
                }
            }
            else
            {//if 'left' or 'right', search through different columns at the given row.
                for (int i = coords[1]; i < (coords[1] + ship.length * increment); i += increment)
                {
                    prospectiveCoords[1] = i;
                    if (!ValidCoord(prospectiveCoords))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

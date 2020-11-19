﻿using System;
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

        ConsoleOptionsInterface orientationMenu;
        public void SetShip(Ship ship, Human human)
        {
            Console.WriteLine("Choose a space for one end of your " + ship.name + " of size " + ship.length + ". (eg. B:13)");
            Coordinates coords = GetStartingCoordinate(human);
            Console.WriteLine("Choose an orientation");
            int orientationSelection = GetOrientation(coords, ship);
            AssignAnchorPointsToShip(ship, orientationSelection, coords);
        }

        public void SetShip(Ship ship, Computer computer)
        {
            Coordinates startingCoords = GetStartingCoordinate(computer);
        }


        void AssignAnchorPointsToShip(Ship ship, int orientation, Coordinates startingCoordinates)
        {
            ship.edgeOne.Row = startingCoordinates.Row;
            ship.edgeOne.Column = startingCoordinates.Column;
            int increment = SetIncrement(orientation);// orientation is a number 1-4, representing { "Up", "Down", "Left", "Right" };   
            for (int i = (int)ship.edgeOne.Row, j = ship.edgeOne.Column; i < (int)ship.edgeTwo.Row && j < ship.edgeTwo.Column; i+=increment, j+= increment)
            {
                if (orientation == 1 || orientation == 2) {//Vertically aligned
                    
                    ship.coordsList.Add(new Coordinates(Convert.ToChar(i), ship.edgeOne.Column));
                }
                else {//Horizontally aligned.
                    ship.coordsList.Add(new Coordinates(ship.edgeOne.Row, j));
                }
            }
        }

        Coordinates GetStartingCoordinate(Human human)
        {
            Coordinates coords;
            string userInput;
            do {
                do {
                    userInput = Console.ReadLine();
                } while (!Coordinates.ValidCoord(userInput));
                coords = Coordinates.ConvertCoord(userInput);
            } while (!AvailableCoord(coords));
            return coords;   
        }

        Coordinates GetStartingCoordinate(Computer computer)
        {
            string stringCoord;
            do
            {
                int numericRow = RandNumGen.GenerateRand(1, 21);
                int numericColumn = RandNumGen.GenerateRand(1, 21);
                stringCoord = Convert.ToChar(numericRow + 64) + ":" + numericColumn;
            } while (!Coordinates.ValidCoord(stringCoord));
            return Coordinates.ConvertCoord(stringCoord);
        }

        int GetOrientation(Coordinates coords, Ship ship)
        {
            List<string> orientationOptions = new List<string> { "Up", "Down", "Left", "Right" };
            orientationMenu = new ConsoleOptionsInterface(orientationOptions, false, false);
            int optionSelected;
            do
            {
                optionSelected = orientationMenu.Launch();
            } while (!ValidPlacement(coords, optionSelected, ship));

            return optionSelected;
        }


        bool AvailableCoord(Coordinates coords)
        {
            if (battleConsole.ownedBoard[coords.Row, coords.Column] != 79)
            {
                Console.WriteLine("\nShip cannot be placed there.");
                return false;
            }
            return true;
        }

        int SetIncrement(int optionSelected)
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

        bool ValidPlacement(Coordinates coords, int optionSelected, Ship ship)
        {
            List<int> numericalCoords = new List<int> { (coords.Row - 65 + 1), coords.Column }; //-65 to align with numbers, + 1 to set it to second row(1st row is a table header)
            List<int> prospectiveCoords = numericalCoords;
            int increment = SetIncrement(optionSelected);
            if (optionSelected == 1 || optionSelected == 2)
            { //if 'up' or 'down', search through different rows at same column.
                for (int i = numericalCoords[0]; i < (numericalCoords[0] + ship.length * increment); i += increment)
                {
                    prospectiveCoords[0] = i;
                    if (!AvailableCoord(Coordinates.ConvertCoord(prospectiveCoords)))
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
                    if (!AvailableCoord(Coordinates.ConvertCoord(prospectiveCoords)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

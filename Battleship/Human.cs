﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProblemSolving1;

namespace Battleship
{
    class Human : Player
    {   
        public Human(string name, BattleConsole battleConsole)
        {
            this.name = name;
            this.battleConsole = battleConsole;
         
        }

        public override void SetBoard()
        {
            foreach (Ship ship in battleConsole.ownedShips)
            {
                Display.DisplaySingleBoard(battleConsole.ownedBoard);
                int[] firstCoordinate = GetFirstCoord(ship.name, ship.length);
                int orientation = GetOrientation(firstCoordinate, ship.length); //1 is up, 2 is down, 3 is left, 4 is right.
                RegisterCoordinates(firstCoordinate, orientation, ship.length);
            }
        }

        public override int GetCorrespondingOrientationNum(int[] firstCoordinate)//gets user input
        {
            Console.WriteLine("\nPlease enter which direction to place your ship from the starting coordinate " + ConvertCoordinate(firstCoordinate) + ", that you entered: ");
            List<string> orientationOptions = new List<string> { "Up", "Down", "Left", "Right" };
            ConsoleOptionsInterface orientationMenu = new ConsoleOptionsInterface(orientationOptions, false, false);
            int numericSelection = orientationMenu.Launch();
            return numericSelection;
        }


         //-------------------------Obtain Valid First Coordinate-------------------//
        //-------------------------------------------------------------------------//
        public override int[] GetFirstCoord(string shipName, int shipLength)
        {
            int[] firstCoordinate = new int[2];
            string input;
            do
            {
                input = GetFirstCoordInput(shipName, shipLength); 
                firstCoordinate = ConvertCoordinate(input); //Returned ints are converted to 0-19 matrix indeces.
            } while (!FirstCoordinateValidation(firstCoordinate[0], firstCoordinate[1], shipLength));//ensure there is at least one valid orientation for the ship available.
            return firstCoordinate;
        }

        private string GetFirstCoordInput(string shipName, int shipLength)
        {
            string input;
            Console.Write("Please enter a coordinate(eg. A:1) where you will place one end of your " + shipName + ", which is " + shipLength + " spaces long: ");
            do
            {
                input = Console.ReadLine();
            } while (!ValidateCoordinateInput(input)); //Guarantees letter:number with letter uppercase and number 1-20.

            return input;
        }

        private bool ValidateCoordinateInput(string input)
        {
            int colonCounter = 0;
            foreach(char character in input)
            {
                if (character == ':') {
                    colonCounter++;
                }
            }
            if (colonCounter != 1) {
                Console.Write("Entry must contain one colon(':'). Re-enter the coordinate: ");
                return false;
            }
            string[] splitStringArray = input.Split(':');
            if (splitStringArray[0].Length != 1 || (splitStringArray[1].Length < 1 && splitStringArray[1].Length > 2)) {
                Console.Write("Re-enter your coordinate without spaces, with an uppercase letter, a colon, and a number(eg. A:1): ");
                return false;
            }
            if ((int)splitStringArray[0][0] < 65 || (int)splitStringArray[0][0] > 90) {
                Console.Write("Re-enter your coordinate without spaces, with an uppercase letter, a colon, and a number(eg. A:1): ");
                return false;
            }
            foreach (char character in splitStringArray[1]) {
                if ((int)character < 48 || (int)character > 57) {
                    Console.Write("Re-enter your coordinate without spaces, with an uppercase letter, a colon, and a number(eg. A:1): ");
                    return false;
                }
            }
            if(Convert.ToInt32(splitStringArray[1]) < 1 || Convert.ToInt32(splitStringArray[1]) > 20) {
                Console.Write("The numbered column you choose must between from 1-20. Please enter an acceptable coordinate: ");
                return false;
            }
            return true;
        }

         //----------------------------------Coordinate Conversion Methods------------------------------------//
        //---------------------------------------------------------------------------------------------------//

        private int[] ConvertCoordinate(string input)//convert user input letter:1-20 to 0-19:0-19, eg. A:1 = 0:0;
        {
            string[] coordinatesStringArray = input.Split(':');
            int[] numericCoordinates = new int[2];
            numericCoordinates[0] = Convert.ToInt32(Convert.ToChar(coordinatesStringArray[0][0])) - 65; 
            numericCoordinates[1] = Convert.ToInt32(coordinatesStringArray[1]) - 1;
            return numericCoordinates;
        }

        private string ConvertCoordinate(int[] input)//Convert indeces of matrix to user-friendly readable coordinates, eg. 2, 4 = C:5.
        {
            string stringVersion = "";
            int rowCoordinate = input[0] + 65;
            char rowChar = Convert.ToChar(rowCoordinate);
            stringVersion += Convert.ToString(rowChar) + ":" + Convert.ToString(input[1] + 1);
            return stringVersion;
        }

        //------------------------------------Turn-based Fighting Methods------------------------------------//
        //---------------------------------------------------------------------------------------------------//

        public override int[] TakeTurn()
        {
            Display.DisplayDestroyedShips(destroyedShips, this.name);
            Display.DisplaySingleBoard(battleConsole.ownedBoard);
            Console.WriteLine("Press 'enter' when ready to attack: ");
            string nothingToEnter = Console.ReadLine();
            Display.DisplaySingleBoard(battleConsole.opponentBoard);
            int[] attackCoordinates = GetAttackCoordinates();
            return attackCoordinates;
        }

        private int[] GetAttackCoordinates()
        {
            string input;
            Console.Write("Enter coordinates to fire a missile to(eg. A:1): ");
            do
            {
                input = Console.ReadLine();
            } while (!ValidateCoordinateInput(input));
            int[] attackCoordinates = ConvertCoordinate(input);
            return attackCoordinates;
        }
    }
}

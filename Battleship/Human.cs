using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProblemSolving1;

namespace Battleship
{
    class Human : Player
    {
        ConsoleOptionsInterface turnMenu;
        
        public Human(string name, BattleConsole battleConsole)
        {
            this.name = name;
            this.battleConsole = battleConsole;
         
        }

        public override void SetBoard()
        {
            GetFirstCoord();
            GetFirstCoordinate();
        }

        private int[] getFirstCoord()
        {
            string input;
            Console.Write("Please enter a coordinate(eg. A:1) where you will place one end of your " + ship.name + ", which is " + ship.length + " spaces long: ");
            do
            {
                input = Console.ReadLine();
            } while (!ValidateCoordinateInput(input));
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
                Console.Write("Re-enter your coordinate without spaces, with a letter, a colon, and a number(eg. A:1): ");
                return false;
            }
            if ((int)splitStringArray[0][0] < 65 || (int)splitStringArray[0][0] > 90) {
                Console.Write("Re-enter your coordinate without spaces, with a letter, a colon, and a number(eg. A:1): ");
                return false;
            }
            foreach (char character in splitStringArray[1]) {
                if ((int)character < 48 || (int)character > 57) {
                    Console.Write("Re-enter your coordinate without spaces, with a letter, a colon, and a number(eg. A:1): ");
                    return false;
                }
            }
            if(Convert.ToInt32(splitStringArray[1]) < 1 || Convert.ToInt32(splitStringArray[1]) > 20) {
                Console.Write("The numbered column you choose must between from 1-20. Please enter an acceptable coordinate: ");
                return false;
            }
            return true;
        }


    }
}

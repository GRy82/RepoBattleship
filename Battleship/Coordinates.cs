using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Coordinates
    {
        private char row;
        private int column;

        public char Row { get { return row; } set { row = value; } }
        public int Column { get { return column; } set { column = value; } }

        public Coordinates(char row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public static bool ValidCoord(string userInput)//Just validates input, not coordinates themselves.
        {
            int colonCounter = 0;
            foreach (char character in userInput)//count ':' in string
            {
                if (character == 58)
                {
                    colonCounter++;
                }
            }
            if (colonCounter != 1)//must have 1 colon.
            {
                return false;
            }
            string[] coordPieces = userInput.Split(':');
            if (coordPieces[0].Length != 1 || coordPieces[1].Length < 1 || coordPieces[1].Length > 2)//must be 1 letter of 1-2-digit#
            {
                return false;
            }
            coordPieces[0] = coordPieces[0].ToUpper();
            char coordPieceChar = Convert.ToChar(coordPieces[0]);
            if (coordPieceChar > 84 || coordPieceChar < 65) //Must be letter A-T
            {
                return false;
            }
            foreach (char character in coordPieces[1])
            {
                if (character < 48 || character > 57)//Must be number
                {
                    return false;
                }
            }
            if (int.Parse(coordPieces[1]) > 20) {//Must be number <= 20
                return false;
            }
            return true;
        }

        public static Coordinates ConvertCoord(string coord)//Converts string input to char and int as the input stated in the string
        {
            string[] splitString = coord.Split(':');
            Coordinates coords = new Coordinates(Convert.ToChar(splitString[0]), int.Parse(splitString[1]));
            return coords;
        }

        public static Coordinates ConvertCoord(List<int> numericalCoords)
        {
            Coordinates coords = new Coordinates(Convert.ToChar(numericalCoords[0]), numericalCoords[1]);
            return coords;
        }

        public static bool CheckCoord(BattleConsole battleConsole, Coordinates coords) //returns true if empty, false if filled.
        {
            if (battleConsole.ownedBoard[((int)coords.Row) + 1, coords.Column + 1] != 79)
            {
                Console.WriteLine("\nShip cannot be placed there.");
                return false;
            }
            return true;
        }
    }
}

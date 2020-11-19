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

        public static bool ValidCoord(string userInput)
        {
            int colonCounter = 0;
            foreach (char character in userInput)
            {
                if (character == 58)
                {
                    colonCounter++;
                }
            }
            if (colonCounter != 1)
            {
                return false;
            }
            string[] coordPieces = userInput.Split(':');
            if (coordPieces[0].Length != 1 && (coordPieces[1].Length < 1 || coordPieces[1].Length > 2))
            {
                return false;
            }
            coordPieces[0] = coordPieces[0].ToUpper();
            char coordPieceChar = Convert.ToChar(coordPieces[0]);
            if (coordPieceChar > 90 || coordPieceChar < 65)
            {
                return false;
            }
            foreach (char character in coordPieces[1])
            {
                if (character < 48 || character > 57)
                {
                    return false;
                }
            }
            return true;
        }

        public static Coordinates ConvertCoord(string coord)
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
            if (battleConsole.ownedBoard[coords.Row, coords.Column] != 79)
            {
                Console.WriteLine("\nShip cannot be placed there.");
                return false;
            }
            return true;
        }
    }
}

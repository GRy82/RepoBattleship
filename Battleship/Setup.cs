using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    static class Setup
    {
        public static List<Player> LoadObjects(int optionSelected)
        {
            List<Ship> playerOneShips = new List<Ship> { new Ship("Destroyer", 2), new Ship("Submarine", 3), new Ship("Battleship", 4), new Ship("Aircraft Carrier", 5) };

            List<Ship> playerTwoShips = new List<Ship> { new Ship("Destroyer", 2), new Ship("Submarine", 3), new Ship("Battleship", 4), new Ship("Aircraft Carrier", 5) };

            BattleConsole battleConsoleOne = new BattleConsole(playerOneShips);
            BattleConsole battleConsoleTwo = new BattleConsole(playerTwoShips);
            battleConsoleOne.GenerateEmptyBoards();
            battleConsoleTwo.GenerateEmptyBoards();
            List<BattleConsole> battleConsolesList = new List<BattleConsole> { battleConsoleOne, battleConsoleTwo };

            List<Player> playersList = LoadPlayers(optionSelected, battleConsolesList);
            return playersList;

        }

        private List<Player> LoadPlayers(int optionSelected, List<BattleConsole> battleConsolesList)
        {
            Player playerOne;
            Player playerTwo;
            string nameOne;
            string nameTwo;
            if (optionSelected == 1 || optionSelected == 2)
            {
                nameOne = ChooseName(1);
                playerOne = new Human(nameOne, battleConsolesList[0]);
                if (optionSelected == 2)
                {
                    nameTwo = ChooseName(2);
                    playerTwo = new Human(nameTwo, battleConsolesList[1]);
                }
                else
                {
                    nameTwo = "Computer";
                    playerTwo = new Computer(nameTwo, battleConsolesList[1]);
                }
            }
            else
            {
                nameOne = "Computer1";
                nameTwo = "Computer2";
                playerOne = new Computer(nameOne, battleConsolesList[0]);
                playerTwo = new Computer(nameTwo, battleConsolesList[1]);
            }
            List<Player> playersList = new List<Player> { playerOne, playerTwo };
            return playersList;
        }

        string ChooseName(int playerNumber)
        {
            string nameInput;
            Console.Write("Please enter your name, player" + playerNumber + ": ");
            do
            {
                nameInput = Console.ReadLine();
            } while (!ValidateName(nameInput));
            return nameInput;
        }


        bool ValidateName(string nameInput)
        {
            if (nameInput.Length < 1 || nameInput.Length > 20)
            {
                Console.WriteLine("\nName should be between 1 and 20 alphabetical characters.");
                return false;
            }
            foreach (char character in nameInput)
            {
                if (character < 65 || character > 122 || (character > 90 && character < 97))
                {
                    Console.WriteLine("\nName should be alphabetical only.");
                    return false;
                }
            }
            return true;
        }
    }
}

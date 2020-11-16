using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProblemSolving1;

namespace Battleship
{
    class Game
    {
        Player playerOne;
        Player playerTwo;

        public void Run()
        {
            List<string> startOptions = new List<string> {"Play single player", "Play multiplayer"};
            ConsoleOptionsInterface startMenu = new ConsoleOptionsInterface(startOptions, true, false);
            bool runGame = true;
            while(runGame == true)
            {
                int optionSelected = startMenu.Launch();//If optionSelected == 3, program automatically terminated.
                LoadObjects(optionSelected);
            }

        }

        public void LoadObjects(int optionSelected)
        {
            Ship destroyerOne = new Ship("Destroyer", 2);
            Ship submarineOne = new Ship("Submarine", 3);
            Ship battleshipOne = new Ship("Battleship", 4);
            Ship aircraftCarrierOne = new Ship("Aircraft Carrier", 5);
            List<Ship> playerOneShips = new List<Ship> { destroyerOne, submarineOne, battleshipOne, aircraftCarrierOne };

            Ship destroyerTwo = new Ship("Destroyer", 2);
            Ship submarineTwo = new Ship("Submarine", 3);
            Ship battleshipTwo = new Ship("Battleship", 4);
            Ship aircraftCarrierTwo = new Ship("Aircraft Carrier", 5);
            List<Ship> playerTwoShips = new List<Ship> { destroyerTwo, submarineTwo, battleshipTwo, aircraftCarrierTwo };

            BattleConsole battleConsoleOne = new BattleConsole(playerOneShips);
            BattleConsole battleConsoleTwo = new BattleConsole(playerTwoShips);

            string playerOneName = ChooseName();

        }

        string ChooseName()
        {
            string nameInput;
            Console.Write("Please enter your name, player" + i + ": ");
            do
            {
                nameInput = Console.ReadLine();
            } while (!ValidateName(nameInput));
            return nameInput;
        }
        

        bool ValidateName(string nameInput)
        {
            if (nameInput.Length < 1 || nameInput.Length > 20) {
                Console.WriteLine("\nName should be between 1 and 20 alphabetical characters.");
                return false;
            }
            foreach (char character in nameInput)
            {
                if (character < 65 || character > 122 || (character > 90 && character < 97)) {
                    Console.WriteLine("\nName should be alphabetical only.");
                    return false;
                }
            }
            return true;
        }
    }
}

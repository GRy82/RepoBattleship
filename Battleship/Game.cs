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
        List<Player> playersList;
        Player playerOne;
        Player playerTwo;

        public Game()
        {

        }

        public void Run()
        {
            List<string> startOptions = new List<string> {"Play single player", "Play multiplayer", "Spectator Mode(Comp vs Comp)"};
            ConsoleOptionsInterface startMenu = new ConsoleOptionsInterface(startOptions, true, false);      
            bool runGame = true;
            while(runGame == true)
            {
                int optionSelected = startMenu.Launch();//If optionSelected == 4, program automatically terminated.
                playersList = Setup.LoadObjects(optionSelected);
                playerOne = playersList[0];
                playerTwo = playersList[1];
                playerOne.SetBoard();
                playerTwo.SetBoard();
                TurnCycle();

            }

        }

        public void TurnCycle()
        {
            string thisTurn = playerOne.name;
            string lastTurn = playerTwo.name;
            do
            {
                if (lastTurn == playerOne.name) {
                    thisTurn = playerTwo.name;
                    playerTwo.OptionsMenu();
                    lastTurn = playerTwo.name;
                }
                else {
                    thisTurn = playerOne.name;
                    playerOne.OptionsMenu();
                    lastTurn = playerTwo.name;
                }
            } while (playerOne.destroyedShips.Count < 4 && playerTwo.destroyedShips.Count < 4);
        }
        
    }
}

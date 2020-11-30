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
                playersList = Setup.LoadBattleConsoles(optionSelected);
                playerOne = playersList[0];
                playerTwo = playersList[1];
                playerOne.SetBoard();
                playerTwo.SetBoard();
                TurnCycle(RandNumGen.GenerateRand(0,2));
            }
        }

  
        public void TurnCycle(int randomStart)
        {
            Player attacker = playerTwo;
            Player victim = playerOne;
            if (randomStart == 0) {
                attacker = playerOne;
                victim = playerTwo;
            }

            int[] attackCoordinates = new int[2];
            do
            {
                attacker.TakeTurn(); 
                AssessAttack(attackCoordinates, attacker, victim);
                
            } while (playerOne.destroyedShips.Count < 4 && playerTwo.destroyedShips.Count < 4);
        }
        
        private void AssessAttack(int[] attackCoords, Player attacker, Player victim)
        {
            if (victim.battleConsole.ownedBoard[attackCoords[0], attackCoords[1]] == 1)
            {
                Console.WriteLine("\n" + attacker.name + "'s attack was successful! " + victim.name + "'s ship has been hit!");
                attacker.battleConsole.opponentBoard[attackCoords[0], attackCoords[1]] = 2;
                victim.battleConsole.opponentBoard[attackCoords[0], attackCoords[1]] = 2;
            }
            else
            {
                Console.WriteLine("\n" + attacker.name + "'s missile plunges into the water. " + victim.name + " was unharmed this turn.");
            }
        }
    }
}

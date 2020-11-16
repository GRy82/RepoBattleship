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

        public void Run()
        {
            List<string> startOptions = new List<string> {"Play single player", "Play multiplayer", "Spectator Mode(Comp vs Comp)"};
            ConsoleOptionsInterface startMenu = new ConsoleOptionsInterface(startOptions, true, false);
            Setup setup = new Setup;
            bool runGame = true;
            while(runGame == true)
            {
                int optionSelected = startMenu.Launch();//If optionSelected == 4, program automatically terminated.
                playersList = setup.LoadObjects(optionSelected);
            }

        }

        
    }
}

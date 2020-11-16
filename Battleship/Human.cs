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

        public override void OptionsMenu()
        {
            List<string> turnOptions = new List<string> { "View Your Board", "View Opponent's Board", "Fire a Missile" };
            turnMenu = new ConsoleOptionsInterface(turnOptions, false, false);
            int optionSelected = turnMenu.Launch();
            
        }
        public override void SelectTargetCoord()
        {
            
        }

        public void DisplayOwnBoard()
        {

        }

        public void DisplayOpponentBoard()
        {

        }

        public void FireMissile()
        {

        }

    }
}

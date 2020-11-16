using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Human : Player
    {
        public Human(string name, BattleConsole battleConsole)
        {
            this.name = name;
            this.battleConsole = battleConsole;
         
    }

        public override int OptionsMenu()
        {

        }
        public override void SelectTargetCoord()
        {
            
        }

    }
}

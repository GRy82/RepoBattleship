using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Human : Player
    {
        public Human(string name, BattleConsole battleConsole, List<string> destroyedShips)
        {
            this.name = name;
            this.battleConsole = battleConsole;
            this.destroyedShips = destroyedShips;
         
    }

        public override void SelectTargetCoord()
        {
            
        }

    }
}

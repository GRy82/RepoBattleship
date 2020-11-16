using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Computer : Player
    {

        public Computer(BattleConsole battleConsole, List<string> destroyedShips)
        {
            this.name = "Computer";
            this.battleConsole = battleConsole;
            this.destroyedShips = destroyedShips;
        }
        public override void SelectTargetCoord()
        {

        }
    }
}

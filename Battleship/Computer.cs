using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Computer : Player
    {

        public Computer(string name, BattleConsole battleConsole)
        {
            this.name = name;
            this.battleConsole = battleConsole;
        }

        public override void SetBoard()
        {
            throw new NotImplementedException();
        }
    }
}

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
            SetupShip setupShip = new SetupShip(battleConsole);
            foreach (Ship ship in battleConsole.ownedShips)
            {
                setupShip.SetShip(ship, this);
            }
            Console.WriteLine(name + "'s ships have been placed on their board");
        }
        public override void OptionsMenu()
        {
            
        }
        public override void SelectTargetCoord()
        {

        }
    }
}

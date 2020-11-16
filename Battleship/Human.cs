using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Human : Player
    {
        public Human(string name, BattleConsole battleConsole, List<Ship> ownedShips, List<string> destroyedShips, int[,] ownedBoard, int[,] opponentBoard)
        {
            this.name = name;
            this.battleConsole = battleConsole;
            this.ownedShips = ownedShips;//This could maybe go in the BattleConsole class and be conceived via the above declaration.
            this.destroyedShips = destroyedShips;
            this.ownedBoard = ownedBoard;
            this.opponentBoard = opponentBoard;
    }

        public override void SelectTargetCoord()
        {
            
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class BattleConsole
    {
        public int[,] ownedBoard = new int[20, 20];
        public int[,] opponentBoard = new int[20, 20];
        List<Ship> ownedShips;
        public BattleConsole(List<Ship> ownedShips)
        {
            this.ownedShips = ownedShips;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    abstract class Player
    {
        
        public string name;
        public BattleConsole battleConsole;
        public List<Ship> ownedShips;//This could maybe go in the BattleConsole class and be conceived via the above declaration.
        public List<string> destroyedShips;
        public int[,] ownedBoard = new int[20, 20];
        public int[,] opponentBoard = new int[20, 20];

        public Player()
        {

        }

        public abstract void SelectTargetCoord();
       
    }
}

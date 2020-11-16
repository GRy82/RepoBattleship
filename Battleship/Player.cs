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
        public List<string> destroyedShips;
        

        public Player()
        {

        }

        public abstract void OptionsMenu();
        public abstract void SelectTargetCoord();

        public abstract void SetBoard();
       
    }
}

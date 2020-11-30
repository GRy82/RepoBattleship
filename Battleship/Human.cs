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

        public override void SetBoard()
        {
            GetFirstCoordinate();
        }



    }
}

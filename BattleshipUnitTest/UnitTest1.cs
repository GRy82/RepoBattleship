using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Battleship;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SetBoardComputer_ShipPlacements_AreComplete()
        {
            List<Ship> playerOneShips = new List<Ship> { new Ship("Destroyer", 2), new Ship("Submarine", 3), new Ship("Battleship", 4), new Ship("Aircraft Carrier", 5) };
            BattleConsole battleConsoleOne = new BattleConsole(playerOneShips);
            Player playerOne = new Computer("Computer", battleConsoleOne);
            playerOne.SetBoard();
            DisplayBoard.DisplaySingleBoard(playerOne.battleConsole.ownedBoard);
            Console.ReadLine();
        }

        [TestMethod]
        public void SetBoardComputer_ShipPlacements_AreValid()
        {

        }
    }
}

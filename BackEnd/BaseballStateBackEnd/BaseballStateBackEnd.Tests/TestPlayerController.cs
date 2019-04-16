using BaseballStateBackEnd.Controllers;
using BaseballStateBackEnd.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballStateBackEnd.Tests
{
    [TestClass]
    public class TestPlayerController
    {

        [TestMethod]
        public void GetAllPlayersTest()
        {
            int TestPlayersCount = 8;
            var controller = new PlayerController();

            var result = controller.Get() as List<Player>;
            Assert.AreNotEqual(0, result.Count);
            Assert.AreEqual(TestPlayersCount, result.Count);

        }
    }
}

using BaseballStateBackEnd.controller;
using BaseballStateBackEnd.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BaseballStateBackEnd.Tests
{
    [TestClass]
    public class TestPlayerController
    {

        [TestMethod]
        public void GetAllPlayersTest()
        {
            int TestPlayersCount = 2;
            var controller = new PlayerController();

            var result = controller.Get() as List<Player>;
            Assert.AreNotEqual(0, result.Count);
            Assert.AreEqual(TestPlayersCount, result.Count);

        }

        [TestMethod]
        public void GetPlayerByIdTest()
        {
            int TestPlayerId = 2;
            var controller = new PlayerController();

            Player playerResult = controller.Get(TestPlayerId);
            Assert.AreEqual("Miguel Cabrera", playerResult.PlayerName);
            Assert.AreNotEqual(null, playerResult);
        }

        [TestMethod]
        public void AddAndDeletePlayerTest()
        {
            Player player = new Player(0, "Test Player", "Test Description", "1", "CF", false, 1.0, 1.0, 1,1,1,1.0,1.0,1.0);
            var controller = new PlayerController
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            int InitialDBRowsCount = controller.Get().Count; //get number of rows in the db before add operation

            var addResult = controller.Post(player); //add Player to database

            List<Player> players = controller.Get(); //get rows from DB as a List of Players
            int RowsCountAfterAdd = players.Count; //get number of rows after add
            Player AddedPlayer = players.Find(el => el.PlayerName == player.PlayerName); //get db record of player that was just added

            Assert.AreEqual(InitialDBRowsCount + 1, RowsCountAfterAdd); //rows after add should be initial rows + 1
            Assert.AreEqual(AddedPlayer.Number, player.Number); //checking to see if db row and initial player object have same number attribute

            var deleteResult = controller.Delete(AddedPlayer.ID); //Delete Player from DB

            int RowsCountAfterDelete = controller.Get().Count; //Count rows after the player was deleted

            Assert.AreEqual(RowsCountAfterDelete, InitialDBRowsCount); //rows after delete should be the same as initial row count

        }

        [TestMethod]
        public void UpdatePlayerTest()
        {
            var controller = new PlayerController
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            List < Player > players = controller.Get(); //Get list of Players from DB
            Player modifyPlayer = players[0]; //take the first player from the list
            int playerHits = modifyPlayer.Hits; //save hits number

            modifyPlayer.Hits += 10; //increment players hits by 10

            controller.Update(modifyPlayer); //call controller update function with modified player data

            int newHits = controller.Get()[0].Hits; //call controller get function to find players hits(should be the updated value)

            Assert.AreEqual(newHits, playerHits + 10);
        }
    }
}

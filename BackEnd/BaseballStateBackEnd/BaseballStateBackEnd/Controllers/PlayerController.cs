using BaseballStateBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaseballStateBackEnd.Helpers;
using System.Web.Http.Description;

namespace BaseballStateBackEnd.Controllers
{
    public class PlayerController : ApiController
    {
        public List<Player> Players;


        //GET: api/Player
        [ResponseType(typeof(List<Player>))]
        public List<Player> Get()
        {
            DBHelper helper = new DBHelper();
            List<Player> Players = new List<Player>();

            Players.Add(new Player(1, "Mike Trout", "goat", "24", null, false, 0.0, 0.0, 0, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0));
            Players.Add(new Player(2, "Barry Bonds", "goat", "24", null, false, 0.0, 0.0, 0, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0));
            Players.Add(new Player(3, "Max Scherzer", "goat", "24", null, false, 0.0, 0.0, 0, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0));
            Players.Add(new Player(4, "Justin Verlander", "goat", "24", null, false, 0.0, 0.0, 0, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0));
            Players.Add(new Player(5, "Steve Johnson", "goat", "24", null, false, 0.0, 0.0, 0, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0));



            // return helper.GetAllPlayersFromSP();
            return Players;
        }

        //GET: api/Player/1
        public IHttpActionResult Get(int id)
        {
            List<Player> Players = new List<Player>();

            Players.Add(new Player(1, "Mike Trout", "goat", "24", null, false, 0.0, 0.0, 0, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0));
            Players.Add(new Player(2, "Barry Bonds", "goat", "24", null, false, 0.0, 0.0, 0, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0));
            Players.Add(new Player(3, "Max Scherzer", "goat", "24", null, false, 0.0, 0.0, 0, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0));
            Players.Add(new Player(4, "Justin Verlander", "goat", "24", null, false, 0.0, 0.0, 0, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0));
            Players.Add(new Player(5, "Steve Johnson", "goat", "24", null, false, 0.0, 0.0, 0, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0));
            //try
            //{
            //    var player = Players.Find(el => el.ID == id);
            //    if ( player == null)
            //    {

            //    }
            //    return player;
            //}
            //catch
            //{
            //    return null;
            //}

            var product = Players.FirstOrDefault((p) => p.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);

        }
    }
}

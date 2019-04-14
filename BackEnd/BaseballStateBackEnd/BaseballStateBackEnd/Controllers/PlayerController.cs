using BaseballStateBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaseballStateBackEnd.Helpers;

namespace BaseballStateBackEnd.Controllers
{
    public class PlayerController : ApiController
    {

        public List<Player> GetAllPlayers()
        {
            DBHelper helper = new DBHelper();

            return helper.GetAllPlayersFromSP();
        }
    }
}

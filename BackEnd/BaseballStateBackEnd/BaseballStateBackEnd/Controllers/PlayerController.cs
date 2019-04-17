using BaseballStateBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaseballStateBackEnd.Helpers;
using System.Web.Http.Description;

namespace BaseballStateBackEnd.controller
{
    public class PlayerController : ApiController
    {
        //Players.Add(new Player(1, "Mike Trout", "goat", "24", null, false, 0.0, 0.0, 0, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0));
        //Players.Add(new Player(2, "Barry Bonds", "goat", "24", null, false, 0.0, 0.0, 0, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0));
        //Players.Add(new Player(3, "Max Scherzer", "goat", "24", null, false, 0.0, 0.0, 0, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0));
        //Players.Add(new Player(4, "Justin Verlander", "goat", "24", null, false, 0.0, 0.0, 0, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0));
        //Players.Add(new Player(5, "Steve Johnson", "goat", "24", null, false, 0.0, 0.0, 0, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0));

        //GET: api/Player
        [ResponseType(typeof(List<Player>))]
        public List<Player> Get()
        {
            DBHelper helper = new DBHelper();
            List<Player> Players = new List<Player>();

            Players = helper.GetAllPlayersFromSP();
            
            // return helper.GetAllPlayersFromSP();
            return Players;
        }

        //GET: api/Player/1
        public Player Get(int id)
        {
            Player player = new Player();

            try
            {
                DBHelper helper = new DBHelper();
                player = helper.GetPlayerFromSP(id);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            return player;
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] Player player)
        {
            DBHelper helper = new DBHelper();
            try
            {
                int rowsAffected = helper.AddPlayerViaSP(player);
                if ( rowsAffected == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new
                        {
                            player = player,
                            rowsAffected = rowsAffected
                        });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new
                    {
                        player = player,
                        rowsAffected = rowsAffected
                    });
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new
                    {
                        player = player,
                        rowsAffected = 0,
                        errorMessage = e
                    });
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int playerId)
        {
            DBHelper helper = new DBHelper();
            try
            {
                int rowsAffected = helper.DeletePlayerViaSP(playerId);
                if (rowsAffected == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new
                        {
                            playerId = playerId,
                            rowsAffected = rowsAffected
                        });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new
                    {
                        playerId = playerId,
                        rowsAffected = rowsAffected
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new
                    {
                        playerId = playerId,
                        rowsAffected = 0,
                        errorMessage = e
                    });
            }
        }

        [HttpPost]
        public HttpResponseMessage Update([FromBody] Player player)
        {
            DBHelper helper = new DBHelper();
            try
            {
                int rowsAffected = helper.ModifyPlayerViaSP(player);
                if (rowsAffected == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        new
                        {
                            player = player,
                            rowsAffected = rowsAffected
                        });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new
                    {
                        player = player,
                        rowsAffected = rowsAffected
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new
                    {
                        player = player,
                        rowsAffected = 0,
                        errorMessage = e
                    });
            }
        }
    }
}

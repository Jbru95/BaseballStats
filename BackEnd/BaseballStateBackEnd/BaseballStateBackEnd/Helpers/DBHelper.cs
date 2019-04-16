using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BaseballStateBackEnd.Models;
using System.Data.SqlClient;

namespace BaseballStateBackEnd.Helpers
{
    public class DBHelper
    {
        private string ConnectionString = "Data Source=DESKTOP-RP5U7K6\\SQLEXPRESS;" +
                        "Initial Catalog= ProjectDatabase;" +
                        "Integrated Security=SSPI;";

        public DBHelper()
        {
        }

        public List<Player> GetAllPlayersFromSP()
        {
            List<Player> playersList = new List<Player>();

            SqlConnection conn = null;
            SqlDataReader rdr = null;

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = ConnectionString;
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_GetAllPlayers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // cmd.Parameters.Add(new SqlParameter("@Id", 2)); Use this to add parameters to call SP with

                rdr = cmd.ExecuteReader();
                while (rdr.Read()) {
                    Player player = new Player();
                    player.ID = (int)rdr[0];
                    player.PlayerName = rdr[1].ToString();
                    player.PlayerDescription = rdr[2].ToString();
                    player.Number = rdr[3].ToString();
                    player.Position = rdr[4].ToString();
                    player.IsPitcher = (bool)rdr[5];
                    player.WAR = (double)rdr[6];
                    player.Average = (double)rdr[7];
                    player.Hits = (int)rdr[8];
                    player.HomeRuns = (int)rdr[9];
                    player.Walks = (int)rdr[10];
                    player.OBP = (double)rdr[11];
                    player.Slug = (double)rdr[12];
                    player.OPS = (double)rdr[13];
                    player.ERA = (double)rdr[14];
                    //player.OppAVG = (double)rdr[15];
                    //player.KsPerNine = (double)rdr[16];
                    //player.WalksPerNine = (double)rdr[17];
                    //player.HomerunsPerNine = (double)rdr[18];
                    //player.Whip = (double)rdr[19];
                    //playersList.Add(new Player((int)rdr[0], rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), (bool)rdr[5],
                    //    (double)rdr[6], (double)rdr[7], (int)rdr[8], (int)rdr[9],
                    //    (int)rdr[10], (double)rdr[11], (double)rdr[12], (double)rdr[13], (double)rdr[14], (double)rdr[15], (double)rdr[16],
                    //    (double)rdr[17], (double)rdr[18], (double)rdr[19])
                    //);
                    playersList.Add(player);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                rdr.Close();
                conn.Close();
            }
            return playersList;
        }

        Player GetPlayerFromSP()
        {
            return null;
        }

        List<Player> GetAllPlayersFromQuery()
        {
            return null;
        }

        Player GetPlayerFromQuery()
        {
            return null;
        }
    }
}
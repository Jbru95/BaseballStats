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
                while (rdr.Read())
                {
                    Player player = new Player();
                    player.ID = (int)rdr[0];
                    player.PlayerName = rdr[1].ToString();
                    player.PlayerDescription = rdr[2].ToString();
                    player.Number = rdr[3].ToString();
                    player.Position = rdr[4].ToString();
                    player.WAR = (double)rdr[5];
                    player.Average = (double)rdr[6];
                    player.Hits = (int)rdr[7];
                    player.HomeRuns = (int)rdr[8];
                    player.Walks = (int)rdr[9];
                    player.OBP = (double)rdr[10];
                    player.Slug = (double)rdr[11];
                    player.OPS = (double)rdr[12];

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

        public Player GetPlayerFromSP(int playerId)
        {
            Player player = new Player();
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_GetPlayerById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", playerId)); // Use this to add parameters to call SP with

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        try
                        {
                            rdr.Read();
                            player.ID = (int)rdr[0];
                            player.PlayerName = rdr[1].ToString();
                            player.PlayerDescription = rdr[2].ToString();
                            player.Number = rdr[3].ToString();
                            player.Position = rdr[4].ToString();
                            player.WAR = (double)rdr[5];
                            player.Average = (double)rdr[6];
                            player.Hits = (int)rdr[7];
                            player.HomeRuns = (int)rdr[8];
                            player.Walks = (int)rdr[9];
                            player.OBP = (double)rdr[10];
                            player.Slug = (double)rdr[11];
                            player.OPS = (double)rdr[12];
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Failed to get Player Object by Id: " + playerId.ToString());
                            return null;
                        }

                    }
                    conn.Close();
                }
            }
            return player;
        }

        public int AddPlayerViaSP(Player player)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_AddPlayer", conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@PlayerName", player.PlayerName)); // Use this to add parameters to call SP with
                        cmd.Parameters.Add(new SqlParameter("@Description", player.PlayerDescription));
                        cmd.Parameters.Add(new SqlParameter("@Number", player.Number));
                        cmd.Parameters.Add(new SqlParameter("@Position", player.Position));
                        cmd.Parameters.Add(new SqlParameter("@WAR", player.WAR));
                        cmd.Parameters.Add(new SqlParameter("@Average", player.Average));
                        cmd.Parameters.Add(new SqlParameter("@Hits", player.Hits));
                        cmd.Parameters.Add(new SqlParameter("@Homeruns", player.HomeRuns));
                        cmd.Parameters.Add(new SqlParameter("@Walks", player.Walks));
                        cmd.Parameters.Add(new SqlParameter("@OBP", player.OBP));
                        cmd.Parameters.Add(new SqlParameter("@Slug", player.Slug));
                        cmd.Parameters.Add(new SqlParameter("@OPS", player.OPS));

                        rowsAffected = cmd.ExecuteNonQuery(); //Execute Stored Procedure with added Parameters
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                conn.Close();
            }
            return rowsAffected;
        }

        public int DeletePlayerViaSP(int playerId)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_DeletePlayer", conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@ID", playerId));

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                conn.Close();
            }
            return rowsAffected;
        }
    }
}
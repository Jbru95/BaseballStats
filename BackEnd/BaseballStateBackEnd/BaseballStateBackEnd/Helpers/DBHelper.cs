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
        private string ConnectionString = "Data Source=DESKTOP-RP5U7K6;" +
                        "Initial Catalog= ProjectDatabase;" +
                        "Integrated Security=SSPI;";

        public DBHelper()
        {
        }


        public List<Player> GetAllPlayersFromSP()
        {
            List<Player> playersList = null;

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
                    playersList.Add(new Player((int)rdr["ID"], rdr["PlayerName"].ToString(), rdr["PlayerDescription"].ToString(), rdr["Number"].ToString(), rdr["Position"].ToString(), (bool)rdr["IsPitcher"],
                        (double)rdr["WAR"], (double)rdr["Average"], (int)rdr["Hits"], (int)rdr["Homeruns"],
                        (int)rdr["Walks"], (double)rdr["OBP"], (double)rdr["Slug"], (double)rdr["OPS"], (double)rdr["ERA"], (double)rdr["OppAVG"], (double)rdr["KsPerNine"],
                        (double)rdr["WalksPerNine"], (double)rdr["HomerunsPerNine"], (double)rdr["whip"])
                    );
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
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
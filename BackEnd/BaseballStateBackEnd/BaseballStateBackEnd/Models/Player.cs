using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BaseballStateBackEnd.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string PlayerName { get; set; } //Pitchers and Hitters will have both of these
        public string PlayerDescription { get; set; }
        public string Number { get; set; }
        public string Position { get; set; }
        public double WAR { get; set; }

        public double Average { get; set; } //Hitter Stats
        public int Hits { get; set; }
        public int HomeRuns { get; set; }
        public int Walks { get; set; }
        public double OBP { get; set; }
        public double Slug { get; set; }
        public double OPS { get; set; }


        public Player()
        {

        }

        public Player(int id, string playerName, string playerDescription, string number, string position, bool isPitcher, double war, double average, int hits, int homeruns, int walks, double obp, double slug, double ops)
        {
            ID = id;
            PlayerName = playerName;
            PlayerDescription = playerDescription;
            Number = number;
            Position = position;
            WAR = war;
            Average = average;
            Hits = hits;
            HomeRuns = homeruns;
            Walks = walks;
            OBP = obp;
            Slug = slug;
            OPS = ops;
        }

        public Player(DataRow row)
        {
            ID = (int)row[0];
            PlayerName = row[1].ToString();
            PlayerDescription = row[2].ToString();
            Number = row[3].ToString();
            Position = row[4].ToString();

            WAR = (double)row[5];
            Average = (double)row[6];
            Hits = (int)row[7];
            HomeRuns = (int)row[8];
            Walks = (int)row[9];
            OBP = (double)row[10];
            Slug = (double)row[11];
            OPS = (double)row[12];

        }
    }
}
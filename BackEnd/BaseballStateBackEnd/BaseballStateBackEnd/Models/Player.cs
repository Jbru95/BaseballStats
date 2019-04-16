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
        public bool IsPitcher { get; set; }
        public double WAR { get; set; }

        public double Average { get; set; } //Hitter Stats
        public int Hits { get; set; }
        public int HomeRuns { get; set; }
        public int Walks { get; set; }
        public double OBP { get; set; }
        public double Slug { get; set; }
        public double OPS { get; set; }

        public double ERA { get; set; } //Pitcher Stats
        public double OppAVG { get; set; }
        public int Strikeouts { get; set; }
        public double KsPerNine { get; set; }
        public double WalksPerNine { get; set; }
        public double HomerunsPerNine { get; set; }
        public double Whip { get; set; }

        public Player()
        {

        }

        public Player(int id, string playerName, string playerDescription, string number, string position, bool isPitcher, double war, double average, int hits, int homeruns, int walks, double obp, double slug, double ops,
            double era, double oppavg, double kspernine, double walkspernine, double homerunspernine, double whip)
        {
            ID = id;
            PlayerName = playerName;
            PlayerDescription = playerDescription;
            Number = number;
            Position = position;
            IsPitcher = isPitcher;
            WAR = war;
            Average = average;
            Hits = hits;
            HomeRuns = homeruns;
            Walks = walks;
            OBP = obp;
            Slug = slug;
            OPS = ops;
            ERA = era;
            OppAVG = oppavg;
            KsPerNine = kspernine;
            WalksPerNine = walkspernine;
            HomerunsPerNine = homerunspernine;
            Whip = whip;
        }

        public Player(DataRow row)
        {
            ID = (int)row[0];
            PlayerName = row[1].ToString();
            PlayerDescription = row[2].ToString();
            Number = row[3].ToString();
            Position = row[4].ToString();
            IsPitcher = (bool)row[5];
            WAR = (double)row[6];
            Average = (double)row[7];
            Hits = (int)row[8];
            HomeRuns = (int)row[9];
            Walks = (int)row[10];
            OBP = (double)row[11];
            Slug = (double)row[12];
            OPS = (double)row[13];
            ERA = (double)row[14];
            OppAVG = (double)row[15];
            KsPerNine = (double)row[16];
            WalksPerNine = (double)row[17];
            HomerunsPerNine = (double)row[18];
            Whip = (double)row[19];
        }
    }
}
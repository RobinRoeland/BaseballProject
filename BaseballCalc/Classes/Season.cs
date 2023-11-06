using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballCalc.Classes
{
    public class Season
    {
        public int Id { get; set; }
        public int GamesPlayed { get; set; }

        //Batting
        public int PlateAppearences { get; set; }
        public int HStrikeOuts { get; set; }
        public int Hits { get; set; }
        public int Singles { get; set; }
        public int Doubles { get; set; }
        public int Triples { get; set; }
        public int HomeRuns { get; set; }
        public int BaseOnBalls { get; set; }
        public int HitByPitch { get; set; }
        public int SacrificeFlies { get; set; }
        public int SacrificeHits { get; set; }
        public int TotalBases { get; set; }

        //Running
        public int CaughtStealing { get; set; }
        public int StolenBases { get; set; }
        public int Runs { get; set; }

        //Fielding
        public int Errors { get; set; }
        public int DoublePlays { get; set; }
        public int TriplePlays { get; set; }
        public int PassedBalls { get; set; }

        //Pitching
        public int PStrikeOuts { get; set; }
    }
}

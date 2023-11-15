using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballCalc.Classes
{
    public class Season
    {
        public Season(int id, int year, int playerKey, int gamesPlayed, int plateAppearences, int hStrikeOuts, int hits, int singles, int doubles, int triples, int homeRuns, int baseOnBalls, int hitByPitch, int sacrificeFlies, int sacrificeHits, int caughtStealing, int stolenBases, int runs, int errors, int doublePlays, int triplePlays, int passedBalls, int pStrikeOuts)
        {
            Id = id;
            Year = year;
            PlayerKey = playerKey;
            GamesPlayed = gamesPlayed;
            PlateAppearences = plateAppearences;
            HStrikeOuts = hStrikeOuts;
            Hits = hits;
            Singles = singles;
            Doubles = doubles;
            Triples = triples;
            HomeRuns = homeRuns;
            BaseOnBalls = baseOnBalls;
            HitByPitch = hitByPitch;
            SacrificeFlies = sacrificeFlies;
            SacrificeHits = sacrificeHits;
            CaughtStealing = caughtStealing;
            StolenBases = stolenBases;
            Runs = runs;
            Errors = errors;
            DoublePlays = doublePlays;
            TriplePlays = triplePlays;
            PassedBalls = passedBalls;
            PStrikeOuts = pStrikeOuts;
        }

        public int Id { get; set; }
        [Required]
        public int PlayerKey { get; set; }
        [Required]
        public int GamesPlayed { get; set; }
        [Required]
        public int Year { get; set; }
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

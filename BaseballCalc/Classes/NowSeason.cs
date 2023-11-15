using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballCalc.Classes
{
    public class NowSeason : Season
    {
        public NowSeason(Speler player, Season season)
            : base(season.Id, season.Year, season.PlayerKey, season.GamesPlayed, season.PlateAppearences, season.HStrikeOuts, season.Hits, season.Singles, season.Doubles, season.Triples, season.HomeRuns, season.BaseOnBalls, season.HitByPitch, season.SacrificeFlies, season.SacrificeHits, season.CaughtStealing, season.StolenBases, season.Runs, season.Errors, season.DoublePlays, season.TriplePlays, season.PassedBalls, season.PStrikeOuts)
        {
            Player = player;
            AtBats = season.PlateAppearences - (season.BaseOnBalls + season.HitByPitch + season.SacrificeFlies + season.SacrificeHits); //, interference, or obstruction
            BA = Math.Round((double)season.Hits / AtBats, 2);
        }

        public Speler Player { get; set; }
        public double BA { get; set; }
        public int AtBats { get; set; }
    }
}

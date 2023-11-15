using BaseballCalc.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BaseballCalc
{
    /// <summary>
    /// Interaction logic for StatsView.xaml
    /// </summary>
    public partial class StatsView : Window
    {
        public StatsView(Season season)
        {
            InitializeComponent();
            fillpage(season);
        }

        private void fillpage(Season season)
        {
            float atbats = season.PlateAppearences - (season.BaseOnBalls + season.HitByPitch + season.SacrificeFlies + season.SacrificeHits); //, interference, or obstruction
            float totalbases = season.Singles + 2 * season.Doubles + 3 * season.Triples + 4 * season.HomeRuns;
            float sluggingavg = totalbases / atbats;
            totalAVG.Content = Math.Round((totalbases + season.BaseOnBalls + season.StolenBases) / (season.PlateAppearences + season.CaughtStealing), 2);
            slugAVG.Content = Math.Round(sluggingavg, 2);
            BA.Content = Math.Round(season.Hits / atbats, 2);
            AB.Content = atbats;
            Hits.Content = season.Hits;
            Strikeouts.Content = season.HStrikeOuts;
            BB.Content = season.BaseOnBalls;
            Hitbypitch.Content = season.HitByPitch;
            walktostrikeout.Content = Math.Round((double)(season.BaseOnBalls / season.HStrikeOuts), 2);

            Totalbases.Content = totalbases;
            singles.Content = season.Singles;
            doubles.Content = season.Doubles;
            triples.Content = season.Triples;
            homeruns.Content = season.HomeRuns;
            float obp = (season.Hits + season.BaseOnBalls + season.HitByPitch) / (atbats + season.BaseOnBalls + season.HitByPitch + season.SacrificeFlies);
            OBP.Content = Math.Round(obp, 2);
            OPS.Content = Math.Round(obp + sluggingavg, 2);
            Stolenbases.Content = season.StolenBases;
            caughtstealing.Content = season.CaughtStealing;

            PStrikeouts.Content = season.PStrikeOuts;
        }
    }
}

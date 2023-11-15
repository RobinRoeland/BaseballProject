using BaseballCalc.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace BaseballCalc
{
    /// <summary>
    /// Interaction logic for HandleSeason.xaml
    /// </summary>
    public partial class HandleSeason : Window
    {
        private StatsPage pPage;
        private MyDbContext dbcontext;
        private int seasonid;

        public HandleSeason(MyDbContext dbContext, StatsPage parentpage, int id = -1)
        {
            dbcontext = dbContext;
            pPage = parentpage;

            if (id > -1)
                seasonid = id;

            InitializeComponent();

            Year.DisplayDateEnd = DateTime.Now;
        }

        public void fillInForm(Season season)
        {
            Year.DisplayDate = new DateTime().AddYears(season.Year);
            Gplayed.Text = season.GamesPlayed.ToString();
            PApps.Text = season.PlateAppearences.ToString();
            HStrikeout.Text = season.HStrikeOuts.ToString();
            HHits.Text = season.Hits.ToString();
            HSingles.Text = season.Singles.ToString();
            HDoubles.Text = season.Doubles.ToString();
            HTriples.Text = season.Triples.ToString();
            HHomeruns.Text = season.HomeRuns.ToString();
            HBaseOnBalls.Text = season.BaseOnBalls.ToString();
            HHitByPitch.Text = season.HitByPitch.ToString();
            HSacFlies.Text = season.SacrificeFlies.ToString();
            HSacHits.Text = season.SacrificeHits.ToString();
            CaughtStealing.Text = season.CaughtStealing.ToString();
            StolenBases.Text = season.StolenBases.ToString();
            Runs.Text = season.Runs.ToString();
            Errors.Text = season.Errors.ToString();
            DoublePlays.Text = season.DoublePlays.ToString();
            TriplePlays.Text = season.TriplePlays.ToString();
            PassedBalls.Text = season.PassedBalls.ToString();
            PStrikeouts.Text = season.PStrikeOuts.ToString();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            bool finished = false;
            if (Gplayed.Text.Length > 0 && Year.DisplayDate.Year.ToString().Length > 0 && PApps.Text.Length > 0 && HStrikeout.Text.Length > 0 && HHits.Text.Length > 0 && HSingles.Text.Length > 0 &&
                   HDoubles.Text.Length > 0 && HTriples.Text.Length > 0 && HHomeruns.Text.Length > 0 && HBaseOnBalls.Text.Length > 0 && HHitByPitch.Text.Length > 0 &&
                   HSacFlies.Text.Length > 0 && HSacHits.Text.Length > 0 && CaughtStealing.Text.Length > 0 && StolenBases.Text.Length > 0 &&
                   Runs.Text.Length > 0 && Errors.Text.Length > 0 && DoublePlays.Text.Length > 0 && TriplePlays.Text.Length > 0 && PassedBalls.Text.Length > 0 && PStrikeouts.Text.Length > 0)
            {
                if (seasonid <= 0)
                {
                    int seasonid;
                    try
                    {
                        seasonid = dbcontext.Season.ToList().OrderBy(season => season.Id).Last().Id + 1;
                    }
                    catch (Exception)
                    {
                        seasonid = 1;
                    }
                    
                    Season season = new Season(
                        seasonid,
                        Year.DisplayDate.Year,
                        ((Speler)((ComboBoxItem)pPage.PlayerList.SelectedItem).FindResource(((ComboBoxItem)pPage.PlayerList.SelectedItem).Content)).Id,
                        int.Parse(Gplayed.Text),
                        int.Parse(PApps.Text),
                        int.Parse(HStrikeout.Text),
                        int.Parse(HHits.Text),
                        int.Parse(HSingles.Text),
                        int.Parse(HDoubles.Text),
                        int.Parse(HTriples.Text),
                        int.Parse(HHomeruns.Text),
                        int.Parse(HBaseOnBalls.Text),
                        int.Parse(HHitByPitch.Text),
                        int.Parse(HSacFlies.Text),
                        int.Parse(HSacHits.Text),
                        int.Parse(CaughtStealing.Text),
                        int.Parse(StolenBases.Text),
                        int.Parse(Runs.Text),
                        int.Parse(Errors.Text),
                        int.Parse(DoublePlays.Text),
                        int.Parse(TriplePlays.Text),
                        int.Parse(PassedBalls.Text),
                        int.Parse(PStrikeouts.Text)
                    );
                    dbcontext.Season.Add(season);
                }
                else
                {
                    Season season = dbcontext.Season.Where(season => season.Id == seasonid).First();
                    season.Year = Year.DisplayDate.Year;
                    season.GamesPlayed = int.Parse(Gplayed.Text);
                    season.PlateAppearences = int.Parse(PApps.Text);
                    season.HStrikeOuts = int.Parse(HStrikeout.Text);
                    season.Hits = int.Parse(HHits.Text);
                    season.Singles = int.Parse(HSingles.Text);
                    season.Doubles = int.Parse(HDoubles.Text);
                    season.Triples = int.Parse(HTriples.Text);
                    season.HomeRuns = int.Parse(HHomeruns.Text);
                    season.BaseOnBalls = int.Parse(HBaseOnBalls.Text);
                    season.HitByPitch = int.Parse(HHitByPitch.Text);
                    season.SacrificeFlies = int.Parse(HSacFlies.Text);
                    season.SacrificeHits = int.Parse(HSacHits.Text);
                    season.CaughtStealing = int.Parse(CaughtStealing.Text);
                    season.StolenBases = int.Parse(StolenBases.Text);
                    season.Runs = int.Parse(Runs.Text);
                    season.Errors = int.Parse(Errors.Text);
                    season.DoublePlays = int.Parse(DoublePlays.Text);
                    season.TriplePlays = int.Parse(TriplePlays.Text);
                    season.PassedBalls = int.Parse(PassedBalls.Text);
                    season.PStrikeOuts = int.Parse(PStrikeouts.Text);
                    dbcontext.Season.Update(season);
                }
                finished = true;
            }
            else
                MessageBox.Show("Fill everything in!");


            if (finished)
            {
                dbcontext.SaveChanges();
                pPage.getseasons();
                this.Close();
                MessageBox.Show("Changes have been made!");
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Year_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {
            Year.DisplayMode = CalendarMode.Decade;
        }
    }
}

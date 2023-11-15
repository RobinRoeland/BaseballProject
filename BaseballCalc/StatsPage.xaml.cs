using BaseballCalc.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace BaseballCalc
{
    /// <summary>
    /// Interaction logic for StatsPage.xaml
    /// </summary>
    public partial class StatsPage : Window
    {
        private MainWindow m_pwindow;
        private MyDbContext dbcontext;

        public StatsPage(MainWindow pwindow, MyDbContext dbContext)
        {
            m_pwindow = pwindow;
            dbcontext = dbContext;

            InitializeComponent();

            FillTeamList();
            getLeagueCurrentStats();
        }

        private void FillTeamList()
        {
            TeamList.Items.Clear();

            List<Team> teams = dbcontext.Team.Where(team => team.Naam.StartsWith(TeamSearch.Text)).ToList();
            foreach (Team team in teams)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = team.Naam;
                item.Resources.Add(team.Naam, team);

                TeamList.Items.Add(item);
            }
        }

        #region window buttons
        private void Closebtn_Click(object sender, RoutedEventArgs e)
        {
            m_pwindow.Close();
            this.Close();
        }

        private void Minimisebtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MiniMaxibtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void Titlebar_Drag(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }

                this.DragMove();
            }
        }
        #endregion

        private void Homepage_Click(object sender, MouseButtonEventArgs e)
        {
            m_pwindow.Left = this.Left;
            m_pwindow.Top = this.Top;
            m_pwindow.WindowState = this.WindowState;
            m_pwindow.cb.SelectedIndex = this.cb.SelectedIndex;
            m_pwindow.Show();
            this.Close();
        }

        #region Color Changer
        private void Cb_OnMouseEnter(object sender, MouseEventArgs e)
        {
            cb.IsDropDownOpen = true;
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)cb.SelectedItem;
            if (typeItem.Content != null)
            {
                string? value = typeItem.Content.ToString();
                switch (value)
                {
                    case "Blue":
                        Title.Foreground = new SolidColorBrush(Color.FromRgb(81, 154, 255));
                        Titlebar.Background = new SolidColorBrush(Color.FromRgb(38, 38, 141));
                        Closebtn.Background = new SolidColorBrush(Color.FromRgb(48, 73, 152));
                        MiniMaxibtn.Background = new SolidColorBrush(Color.FromRgb(48, 73, 152));
                        Minimizebtn.Background = new SolidColorBrush(Color.FromRgb(48, 73, 152));
                        break;

                    case "Gray":
                        Title.Foreground = new SolidColorBrush(Color.FromRgb(120, 120, 120));
                        Titlebar.Background = new SolidColorBrush(Color.FromRgb(64, 64, 64));
                        Closebtn.Background = new SolidColorBrush(Color.FromRgb(81, 81, 81));
                        MiniMaxibtn.Background = new SolidColorBrush(Color.FromRgb(81, 81, 81));
                        Minimizebtn.Background = new SolidColorBrush(Color.FromRgb(81, 81, 81));
                        break;
                }
                cbselecter.IsSelected = true;
            }
        }
        #endregion

        private void PlayerSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            getplayers();
        }

        private void TeamSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillTeamList();
        }

        private void TeamList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TeamList.SelectedItem != null)
                getplayers();

            addcombobx.Visibility = Visibility.Hidden;
            addbtn.Visibility = Visibility.Visible;
        }

        public void getplayers()
        {

            PlayerList.Items.Clear();
            ComboBoxItem cbitem = (ComboBoxItem)TeamList.SelectedItem;
            List<Speler> spelers = dbcontext.Speler.Where(player => 
            player.TeamKey == ((Team)cbitem.FindResource(cbitem.Content)).Id &&
            player.Naam.StartsWith(PlayerSearch.Text)).ToList();
            foreach (Speler speler in spelers)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = speler.Naam;
                item.Resources.Add(speler.Naam, speler);

                PlayerList.Items.Add(item);
            }

            EditCb.Visibility = Visibility.Hidden;
        }

        public void getLeagueCurrentStats()
        {
            LeagueStats.ItemsSource = null;
            LeagueStats.Items.Clear();
            LeagueStats.Columns.Clear();
            LeagueStats.CanUserResizeRows = false;
            LeagueStats.AutoGenerateColumns = false;
            LeagueStats.SelectionUnit = DataGridSelectionUnit.FullRow;

            List<Season> seasons = dbcontext.Season.Where(season => season.Year == DateTime.Now.Year).ToList();

            List<NowSeason> nowseasons = new List<NowSeason>();
            foreach (Season season in seasons)
            {
                nowseasons.Add(new NowSeason(dbcontext.Speler.Where(player => player.Id == season.PlayerKey).First(), season));
            }
            DataGridTextColumn nr = new DataGridTextColumn();
            nr.Header = "Rugnummer";
            nr.Binding = new Binding("Player.RugNummer");
            DataGridTextColumn name = new DataGridTextColumn();
            name.Header = "Naam";
            name.Binding = new Binding("Player.Naam");
            DataGridTextColumn Gplayed = new DataGridTextColumn();
            Gplayed.Header = "Games Played";
            Gplayed.Binding = new Binding("GamesPlayed");
            DataGridTextColumn AtBats = new DataGridTextColumn();
            AtBats.Header = "At Bats";
            AtBats.Binding = new Binding("AtBats");
            DataGridTextColumn BA = new DataGridTextColumn();
            BA.Header = "Batting Avg";
            BA.Binding = new Binding("BA");
            DataGridTextColumn SB = new DataGridTextColumn();
            SB.Header = "Stolen Bases";
            SB.Binding = new Binding("StolenBases");

            LeagueStats.Columns.Add(nr);
            LeagueStats.Columns.Add(name);
            LeagueStats.Columns.Add(Gplayed);
            LeagueStats.Columns.Add(AtBats);
            LeagueStats.Columns.Add(BA);
            LeagueStats.Columns.Add(SB);

            LeagueStats.ItemsSource = nowseasons;
        }

        public void getseasons()
        {
            Stats.ItemsSource = null;
            Stats.Items.Clear();
            Stats.Columns.Clear();
            Stats.CanUserResizeRows = false;
            Stats.AutoGenerateColumns = false;
            Stats.SelectionUnit = DataGridSelectionUnit.FullRow;

            DataGridTextColumn Gplayed = new DataGridTextColumn();
            Gplayed.Header = "Games Played";
            Gplayed.Binding = new Binding("GamesPlayed");
            DataGridTextColumn year = new DataGridTextColumn();
            year.Header = "Year";
            year.Binding = new Binding("Year");

            Stats.Columns.Add(year);
            Stats.Columns.Add(Gplayed);

            ComboBoxItem cbitem = (ComboBoxItem)PlayerList.SelectedItem;

            List<Season> seasons = dbcontext.Season.Where(season =>
            season.PlayerKey == ((Speler)cbitem.FindResource(cbitem.Content)).Id
            ).ToList();

            Stats.ItemsSource = seasons;
        }

        private void handlePlayer(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)EditCb.SelectedItem;
            if (typeItem.Content != null && !emptycomboselect.IsSelected)
            {
                string? value = typeItem.Content.ToString();
                switch (value)
                {
                    case "Edit":
                        ComboBoxItem cbitemE = (ComboBoxItem)PlayerList.SelectedItem;
                        Speler player = dbcontext.Speler.Where(speler => speler.Id == ((Speler)cbitemE.FindResource(cbitemE.Content)).Id).First();

                        HandleSpeler handle = new HandleSpeler(dbcontext, this, player.Id);
                        handle.fillInForm(player, this);

                        handle.Show();
                        break;

                    case "Remove":
                        ComboBoxItem cbitemR = (ComboBoxItem)PlayerList.SelectedItem;
                        List<Season> seasons = dbcontext.Season.Where(season => season.PlayerKey == ((Speler)cbitemR.FindResource(cbitemR.Content)).Id).ToList();
                        foreach (Season season in seasons)
                        {
                            dbcontext.Season.Remove(season);
                        }

                        dbcontext.Speler.Remove(dbcontext.Speler.Where(speler => speler.Id == ((Speler)cbitemR.FindResource(cbitemR.Content)).Id).First());
                        dbcontext.SaveChanges();
                        break;
                }
                emptycomboselect.IsSelected = true;
            }
        }

        private void EditCb_MouseEnter(object sender, MouseEventArgs e)
        {
            EditCb.IsDropDownOpen = true;
        }

        private void PlayerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditCb.Visibility = Visibility.Visible;
            addbtn.Visibility = Visibility.Hidden;
            addcombobx.Visibility = Visibility.Visible;

            if (PlayerList.SelectedItem != null)
                getseasons();
        }

        private void handleAdd(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)addcombobx.SelectedItem;
            if (typeItem.Content != null && !Additem.IsSelected)
            {
                string? value = typeItem.Content.ToString();
                switch (value)
                {
                    case "Player":
                        new HandleSpeler(dbcontext, this).Show();
                        break;

                    case "Season":
                        new HandleSeason(dbcontext, this).Show();
                        break;
                }
                Additem.IsSelected = true;
            }
        }

        private void AddPlayer(object sender, RoutedEventArgs e)
        {
            new HandleSpeler(dbcontext, this).Show();
        }

        private void Stats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HandleSeason seasonhandle = new HandleSeason(dbcontext, this, ((Season)Stats.SelectedItem).Id);
            seasonhandle.fillInForm((Season)Stats.SelectedItem);
            seasonhandle.Show();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                IList<DataGridCellInfo> items = Stats.SelectedCells;
                Season season = (Season)items.First().Item;
                new StatsView(season).Show();
            }
            catch (Exception){}
        }

        private void DataGridRow_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            IList<DataGridCellInfo> items = Stats.SelectedCells;
            if(items.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to remove this entry?", "Remove", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    Season season = (Season)items.First().Item;
                    dbcontext.Season.Remove(season);
                    dbcontext.SaveChanges();
                }
                getseasons();
            }
        }
    }
}

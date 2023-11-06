using BaseballCalc.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private MyDbContext dbcontext = new MyDbContext();

        public StatsPage(MainWindow pwindow)
        {
            m_pwindow = pwindow;
            
            InitializeComponent();

            FillTeamList();
        }

        private void FillTeamList()
        {
            foreach (Team team in dbcontext.Team.ToList())
            {
                TeamList.Items.Add(team.Id + " - " + team.Naam);
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
            }
        }
        #endregion

        private void PlayerSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                PlayerList.Items.Clear();

                List<Speler> spelers = dbcontext.Speler.Where(player => player.Naam.Contains(PlayerSearch.Text) && player.TeamKey == TeamList.SelectedIndex).ToList();
                foreach (Speler speler in spelers)
                {
                    PlayerList.Items.Add(speler.RugNummer + " - " + speler.Naam);
                }
            }
            catch (Exception) { }
    }

        private void TeamSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TeamList.Items.Clear();

                List<Team> teams = dbcontext.Team.Where(team => team.Naam.Contains(TeamSearch.Text)).ToList();
                foreach (Team team in teams)
                {
                    TeamList.Items.Add(team.Id + " - " + team.Naam);
                }
            }
            catch (Exception) { }
        }

        private void TeamList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TeamList.SelectedItem != null)
                getplayers();        
        }

        private void getplayers()
        {
            try
            {
                PlayerList.Items.Clear();

                int id = int.Parse(TeamList.SelectedValue.ToString().Split('-')[0]);
                List<Speler> spelers = dbcontext.Speler.Where(speler => speler.TeamKey == id).ToList();
                foreach (Speler speler in spelers)
                {
                    PlayerList.Items.Add(speler.Id + " - " + speler.Naam);
                }

                EditCb.Visibility = Visibility.Hidden;
            }
            catch (Exception) { }
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
                        int ide = int.Parse(PlayerList.SelectedValue.ToString().Split('-')[0]);
                        Speler player = dbcontext.Speler.Where(speler => speler.Id == ide).First();
                        HandleSpeler handle = new HandleSpeler(dbcontext, player.Id);
                        handle.NaamTxBx.Text = player.Naam;
                        handle.RugnummerTxBx.Text = player.RugNummer.ToString();
                        //handle.TeamCmbBx.SelectedIndex = player.TeamKey;
                        handle.Show();
                        break;

                    case "Remove":
                        int idr = int.Parse(PlayerList.SelectedValue.ToString().Split('-')[0]);
                        dbcontext.Speler.Remove(dbcontext.Speler.Where(speler => speler.Id == idr).First());
                        dbcontext.SaveChanges();
                        break;
                }
                emptycomboselect.IsSelected = true;

                getplayers();
            }
        }

        private void EditCb_MouseEnter(object sender, MouseEventArgs e)
        {
            EditCb.IsDropDownOpen = true;
        }

        private void PlayerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditCb.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new HandleSpeler(dbcontext).Show();
        }
    }
}

using BaseballCalc.Classes;
using Microsoft.EntityFrameworkCore;
using System;
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
        private MyDbContext dbcontext = new MyDbContext();

        public StatsPage(MainWindow pwindow)
        {
            m_pwindow = pwindow;
            
            InitializeComponent();

            FillTeamList();
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
            if(TeamList.SelectedItem != null)
                getplayers();        
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
                        ComboBoxItem cbteamE = (ComboBoxItem)TeamList.SelectedItem;
                        Speler player = dbcontext.Speler.Where(speler => speler.Id == ((Speler)cbitemE.FindResource(cbitemE.Content)).Id).First();

                        HandleSpeler handle = new HandleSpeler(dbcontext, this, player.Id);
                        handle.NaamTxBx.Text = player.Naam;
                        handle.RugnummerTxBx.Text = player.RugNummer.ToString();

                        int idx = -1;
                        int i = 0;
                        foreach (ComboBoxItem item in handle.TeamCmbBx.Items)
                        {
                            if (item.Content == cbteamE.Content)
                            {
                                idx = ((Team)cbteamE.FindResource(cbteamE.Content)).Id;
                                break;
                            }
                            i++;
                        }

                        if(idx > -1)
                            ((ComboBoxItem)handle.TeamCmbBx.Items.GetItemAt(i)).IsSelected = true;
                        handle.Show();
                        break;

                    case "Remove":
                        ComboBoxItem cbitemR = (ComboBoxItem)PlayerList.SelectedItem;
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new HandleSpeler(dbcontext, this).Show();
        }
    }
}

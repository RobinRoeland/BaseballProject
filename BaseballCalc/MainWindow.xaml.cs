﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BaseballCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WebShopbtn_Click(object sender, RoutedEventArgs e)
        {
            WebShop webShop = new WebShop();
            webShop.Left = this.Left;
            webShop.Top = this.Top;
            webShop.WindowState = this.WindowState;
            webShop.cb.SelectedIndex = this.cb.SelectedIndex;
            webShop.Show();
            this.Close();
        }

        private void Statsbtn_Click(object sender, RoutedEventArgs e)
        {
            StatsPage statspage = new StatsPage();
            statspage.Left = this.Left;
            statspage.Top = this.Top;
            statspage.WindowState = this.WindowState;
            statspage.cb.SelectedIndex = this.cb.SelectedIndex;
            statspage.Show();
            this.Close();
        }

        #region window buttons
        private void Closebtn_Click(object sender, RoutedEventArgs e)
        {
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

        #region Color Changer
        private void Cb_OnMouseEnter(object sender, MouseEventArgs e)
        {
            cb.IsDropDownOpen = true;
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)cb.SelectedItem;
            if(typeItem.Content != null)
                try
                {
                    string value = typeItem.Content.ToString();
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
                catch(Exception){ }
        }
        #endregion
    }
}
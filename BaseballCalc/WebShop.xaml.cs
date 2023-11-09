using BaseballCalc.Classes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BaseballCalc
{
    /// <summary>
    /// Interaction logic for WebShop.xaml
    /// </summary>
    public partial class WebShop : Window
    {
        private MainWindow m_pwindow;

        public WebShop(MainWindow pwindow)
        {
            m_pwindow = pwindow;
            InitializeComponent();
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
                try
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
                catch (Exception) { }
        }
        #endregion
    }
}

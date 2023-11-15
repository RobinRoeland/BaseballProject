using Azure;
using BaseballCalc.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;

namespace BaseballCalc
{
    /// <summary>
    /// Interaction logic for WebShop.xaml
    /// </summary>
    public partial class WebShop : Window
    {
        private MainWindow m_pwindow;
        private MyDbContext dbContext;
        private List<Product> mandje = new List<Product>();

        public WebShop(MainWindow pwindow, MyDbContext dbcontext)
        {
            m_pwindow = pwindow;
            dbContext = dbcontext;
            InitializeComponent();

            getProducts();
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

        public void getProducts()
        {
            Prods.ItemsSource = null;
            Prods.Items.Clear();
            Prods.Columns.Clear();
            Prods.CanUserResizeRows = false;
            Prods.AutoGenerateColumns = false;
            DataGridTextColumn Naam = new DataGridTextColumn();
            Naam.Header = "Naam";
            Naam.Binding = new Binding("Naam");
            DataGridTextColumn Prijs = new DataGridTextColumn();
            Prijs.Header = "Prijs";
            Prijs.Binding = new Binding("Prijs");
            Prods.Columns.Add(Naam);
            Prods.Columns.Add(Prijs);

            List<Product> products = dbContext.Product.ToList();

            Prods.ItemsSource = products;
        }

        private void AddCart_Click(object sender, RoutedEventArgs e)
        {
            IList<DataGridCellInfo> items = Prods.SelectedCells;

            if (items.Count > 0)
            {
                Product prod = (Product)items.First().Item;
                mandje.Add(prod);
            }

            if (mandje.Count > 0)
                Checkoutbtn.Visibility = Visibility.Visible;
            else
                Checkoutbtn.Visibility = Visibility.Hidden;
        }

        private void Checkout_1(object sender, RoutedEventArgs e)
        {
            double prijs = 0;
            foreach (Product product in mandje)
            {
                prijs += product.Prijs;
            }
            MessageBoxResult result = MessageBox.Show("Proceed to checkout? \ntotal price: " + prijs + "$\ntotal items:" + mandje.Count + "\nShipping is free!", "Checkout", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                /*Order order = new Order();
                Amount amount = new Amount();
                
                amount.currency = "EUR";
                Details details = new Details();
                details.subtotal = prijs.ToString();
                details.shipping = "0";
                amount.details = details;
                amount.total = details.subtotal + details.shipping;
                order.amount = amount;
                PaymentExecution execution = new PaymentExecution();
                execution.*/
                MessageBox.Show("Betaald!");
                //Dit lukte niet op tijd.
            }
        }
    }
}

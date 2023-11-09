using BaseballCalc.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddSpeler.xaml
    /// </summary>
    public partial class HandleSpeler : Window
    {
        private StatsPage pPage;
        private MyDbContext dbcontext;
        private int spelerid;

        public HandleSpeler(MyDbContext dbContext, StatsPage parentpage, int id = -1)
        {
            dbcontext = dbContext;
            pPage = parentpage;

            if (id > -1)
                spelerid = id;

            InitializeComponent();

            foreach (Team team in dbcontext.Team.ToList())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = team.Naam;
                item.Resources.Add(team.Naam, team);

                TeamCmbBx.Items.Add(item);
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            bool finished = false;
            if(spelerid <= 0) 
            {
                if (RugnummerTxBx.Text.Length > 0 && NaamTxBx.Text.Length > 0 && TeamCmbBx.SelectedIndex != -1)
                {
                    dbcontext.Speler.Add(new Speler(dbcontext.Speler.ToList().OrderBy(speler => speler.Id).Last().Id + 1, int.Parse(RugnummerTxBx.Text), NaamTxBx.Text, ((Team)((ComboBoxItem)TeamCmbBx.SelectedItem).FindResource(((ComboBoxItem)TeamCmbBx.SelectedItem).Content)).Id));
                    finished = true;
                }
                else
                    MessageBox.Show("Fill everything in!");
            }
            else
            {
                if (RugnummerTxBx.Text.Length > 0 && NaamTxBx.Text.Length > 0 && TeamCmbBx.SelectedIndex != -1)
                {
                    Speler speler = dbcontext.Speler.Where(speler => speler.Id == spelerid).First();
                    speler.Naam = NaamTxBx.Text;
                    speler.RugNummer = int.Parse(RugnummerTxBx.Text);
                    speler.TeamKey = ((Team)((ComboBoxItem)TeamCmbBx.SelectedItem).FindResource(((ComboBoxItem)TeamCmbBx.SelectedItem).Content)).Id;
                    dbcontext.Speler.Update(speler);
                    finished = true;
                }
                else
                    MessageBox.Show("Fill everything in!");
            }

            if (finished)
            {
                dbcontext.SaveChanges();
                pPage.getplayers();
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Prb.Ladders.Core;
using System.Linq;
namespace Prb.Ladders.Wpf
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
        List<Ladder> ladders;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DoSeeding();
            PopulateListbox();
            ClearControls();
            DoStats();
        }
        private void DoSeeding()
        {
            ladders = new List<Ladder>();
            ladders.Add(new Ladder("Alfa", 1, 10, 1.8, 55M, 3));
            ladders.Add(new Ladder("Beta", 1, 10, 1.8, 65M, 2));
            ladders.Add(new Ladder("Tango", 1, 10, 1.8, 75M, 3));
            ladders.Add(new Ladder("Alfa", 2, 10, 2.9, 99.99M, 5));
            ladders.Add(new Ladder("Beta", 2, 10, 2.9, 107.99M, 1));
            ladders.Add(new Ladder("Tango", 2, 10, 2.9, 120M, 5));
            ladders.Add(new Ladder("Alfa", 3, 10, 4.1, 125M, 3));
            ladders.Add(new Ladder("Beta", 3, 10, 4.1, 140M, 4));
            ladders.Add(new Ladder("Tango", 3, 10, 4.1, 160M, 5));
            ladders.Add(new Ladder("Alfa", 1, 12, 2.1, 65M, 4));
            ladders.Add(new Ladder("Beta", 1, 12, 2.1, 75M, 4));
            ladders.Add(new Ladder("Tango", 1, 12, 2.1, 85M, 1));
            ladders.Add(new Ladder("Alfa", 2, 12, 3.5, 109M, 0));
            ladders.Add(new Ladder("Beta", 2, 12, 3.5, 117M, 1));
            ladders.Add(new Ladder("Tango", 2, 12, 3.5, 130M, 5));
            ladders.Add(new Ladder("Alfa", 3, 12, 4.9, 135M, 3));
            ladders.Add(new Ladder("Beta", 3, 12, 4.9, 150M, 1));
            ladders.Add(new Ladder("Tango", 3, 12, 4.9, 170M, 7));
            ladders = ladders.OrderBy(l => l.Brand).ThenBy(l => l.Sections).ThenBy(l => l.StepsPerSection).ToList();
        }
        private void PopulateListbox()
        {
            lstLadders.ItemsSource = null;
            lstLadders.ItemsSource = ladders;
        }
        private void ClearControls()
        {
            lblBrand.Content = "";
            lblMaxHeight.Content = "";
            lblSalePrice.Content = "";
            lblSections.Content = "";
            lblStepsPerSection.Content = "";
            lblStock.Content = "";
            lblStockValue.Content = "";
        }
        private void PopulateControls(Ladder ladder)
        {
            lblBrand.Content = ladder.Brand;
            lblMaxHeight.Content = ladder.MaxHeight;
            lblSalePrice.Content = ladder.SalePrice.ToString("€#,##0.00");
            lblSections.Content = ladder.Sections;
            lblStepsPerSection.Content = ladder.StepsPerSection;
            lblStock.Content = ladder.Stock;
            lblStockValue.Content = (ladder.Stock * ladder.SalePrice).ToString("€#,##0.00");

        }
        private void DoStats()
        {
            int totalStock = 0;
            decimal totalStockValue = 0M;
            foreach(Ladder ladder in ladders)
            {
                totalStock += ladder.Stock;
                totalStockValue += (ladder.Stock * ladder.SalePrice);
            }
            lblTotalStock.Content = totalStock;
            lblTotalStockValue.Content = totalStockValue.ToString("€#,##0.00");
        }
        private void lstLadders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearControls();
            if(lstLadders.SelectedItem != null)
            {
                Ladder ladder =(Ladder)lstLadders.SelectedItem;
                PopulateControls(ladder);
            }
        }
    }
}

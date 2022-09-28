using SalesWPFApp.Configuration;
using SalesWPFApp.Event;
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

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static WindowOrders _orders;
        private static WindowMembers _members;
        private static WindowProducts _products;

        public MainWindow(WindowOrders orders, WindowMembers members, WindowProducts products)
        {
            _orders = orders;
            _members = members;
            _products = products;
            InitializeComponent();
        }

        private void btnOrderSrc_click(object sender, RoutedEventArgs e)
        {
            _orders.Show();
        }

        private void btnProductSrc_click(object sender, RoutedEventArgs e)
        {
            _products.Show();
        }

        private void btnMemberSrc_Click(object sender, RoutedEventArgs e)
        {
            _members.Show();
        }

        private void btnLogOut_click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

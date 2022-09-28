using BusinessObject.Entity;
using DataAccess;
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
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowOrders.xaml
    /// </summary>
    public partial class WindowOrders : Window
    {
        private static IOrderRepository _orderRepository;
        public WindowOrders(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            InitializeComponent();
        }
        public Order GetObject()
        {
            Order order = null;
            try
            {
                order = new Order
                {
                  MemberId = int.Parse(txtMemberID.Text),
                  OrderId = int.Parse(txtOrderId.Text),
                  OrderDate = DateTime.Parse(dpOrderDate.Text),
                  RequiredDate = DateTime.Parse(dpRequiredDate.Text),
                  ShippedDate = DateTime.Parse(dpShippedDate.Text),

                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }
        public void LoadOrderList()
        {
            lvOrder.ItemsSource = _orderRepository.GetListOrder();
        }

        private void btnLoadOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadOrderList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = GetObject();
                var result = _orderRepository.InsertOrder(order);
                LoadOrderList();
                MessageBox.Show(result.Message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnUpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = GetObject();
                var result = _orderRepository.UpdateOrder(order);
                LoadOrderList();
                MessageBox.Show(result.Message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = GetObject();
                var result = _orderRepository.DeleteOrder(order);
                LoadOrderList();
                MessageBox.Show(result.Message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnClearText_Click(object sender, RoutedEventArgs e)
        {
            txtMemberID.Clear();
            txtOrderId.Clear();
            dpOrderDate.Resources.Clear();
            dpRequiredDate.Resources.Clear();
            dpShippedDate.Resources.Clear();
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAddOrderDetail(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
    /// Interaction logic for WindowProducts.xaml
    /// </summary>
    public partial class WindowProducts : Window
    {
        IProductRepository _productRepository;
        
        public WindowProducts(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            InitializeComponent();
        }
        private Product GetProductObject()
        {
            Product product = null;
            try
            {
                product = new Product
                {
                    ProductId = int.Parse(txtProductID.Text),
                    ProductName = txtProductName.Text,
                    UnitPrice = int.Parse(txtUnitPrice.Text),

                };
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Get product");
            }
            return product;
        }
        public void LoadProductList()
        {
            lvProduct.ItemsSource = _productRepository.GetProductList();
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtProductID.Clear();
            txtProductName.Clear();
            cbCategory.SelectedIndex = 0;
            txtUnitPrice.Clear();
            txtUnitsInStock.Clear();
            txtWeight.Clear();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadProductList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Load product list");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = GetProductObject();
                _productRepository.InsertProduct(product);
                LoadProductList();
                MessageBox.Show($"{product.ProductName} insert successfully", "Insert product");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert car");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = GetProductObject();
                _productRepository.UpdateProduct(product);
                LoadProductList();
                MessageBox.Show($"{product.ProductName} update successfully", "Update product");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update car");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var isAdmin = AppManager.getCurrentRole();
            if (isAdmin)
            {
                try
                {
                    Product product = GetProductObject();
                    _productRepository.DeleteProduct(product);
                    LoadProductList();
                    MessageBox.Show($"{product.ProductName} delete successfully", "Delete product");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete car fail");
                }
            }
            else
            {
                MessageBox.Show("Only admin can delete product!");
            }

        }

        private void cbCategory_Drop(object sender, DragEventArgs e)
        {
            //cbCategory.ItemsSource = 
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

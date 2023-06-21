using Ass1Client.Model.Category;
using Ass1Client.Model.Product;
using Ass1Client.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Ass1Client.View
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        CallAPIUtils util;
        public ProductWindow()
        {
            InitializeComponent();
            util = new CallAPIUtils();
            LoadCategories();
            LoadData();
        }

        private void LoadCategories()
        {
            string jsonCategory = util.Get("api/Product/category");
            if (!string.IsNullOrEmpty(jsonCategory))
            {
                List<CategoryInfo> categoryInfos = JsonSerializer.Deserialize<List<CategoryInfo>>(jsonCategory);
                cmbCategories.ItemsSource = categoryInfos;
                cmbCategories.SelectedValuePath = "CategoryId";
                cmbCategories.DisplayMemberPath = "CategoryName";
            }
        }

        private void LoadData()
        {
            string jsonProduct = util.Get("api/Product");
            if (!string.IsNullOrEmpty(jsonProduct))
            {
                List<ProductInfo> productInfos = JsonSerializer.Deserialize<List<ProductInfo>>(jsonProduct);
                lvProducts.ItemsSource = productInfos;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        { 
            var obj = new
            {
                ProductId = 0,
                CategoryId = int.Parse(cmbCategories.SelectedValue.ToString()),
                ProductName = tbProductName.Text,
                Weight = double.Parse(tbWeight.Text),
                UnitPrice = double.Parse(tbUnitPrice.Text),
                UnitsInStock = int.Parse(tbUnitInStock.Text)
            };
            string json = JsonSerializer.Serialize(obj);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            string response = util.Post("api/Product", httpContent);
            if (response == "error")
            {
                MessageBox.Show("Please check your input!");
            }
            else
            {
                MessageBox.Show("Add Product Successfully!");
                LoadData();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var obj = new
            {
                ProductId = int.Parse(tbProductId.Text),
                CategoryId = int.Parse(cmbCategories.SelectedValue.ToString()),
                ProductName = tbProductName.Text,
                Weight = double.Parse(tbWeight.Text),
                UnitPrice = double.Parse(tbUnitPrice.Text),
                UnitsInStock = int.Parse(tbUnitInStock.Text)
            };
            string json = JsonSerializer.Serialize(obj);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            string response = util.Put("api/Product", httpContent);
            if (response == "error")
            {
                MessageBox.Show("Please check your input!");
            }
            else
            {
                MessageBox.Show("Update Product Successfully!");
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string response = util.Delete($"api/Product/{int.Parse(tbProductId.Text)}");
            if (response == "error")
            {
                MessageBox.Show("Please check your input!");
            }
            else
            {
                MessageBox.Show("Delete Product Successfully!");
                LoadData();
            }
        }

        private void btnReportNav_Click(object sender, RoutedEventArgs e)
        {
            new ReportWindow().Show();
            this.Close();
        }

        private void btnOrderNav_Click(object sender, RoutedEventArgs e)
        {
            new OrderWindow().Show();
            this.Close();
        }

        private void btnProfileNav_Click(object sender, RoutedEventArgs e)
        {
            new ProfileWindow(PseudoSession.Role, PseudoSession.LoginUser).Show();
            this.Close();
        }
    }
}

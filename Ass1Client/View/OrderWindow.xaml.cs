using Ass1Client.Model.Product;
using Ass1Client.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;

namespace Ass1Client.View
{
    
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        CallAPIUtils util;
        static List<ProductInfo> orderedProducts;
        public OrderWindow()
        {
            InitializeComponent();
            util = new CallAPIUtils();
            orderedProducts = new List<ProductInfo>();
            LoadDefaultData();
        }

        private void LoadProducts(List<ProductInfo> productInfos)
        {
            lvProducts.ItemsSource = productInfos;
        }

        private void LoadOrderedProduct()
        {
            List<ProductInfo> products = new List<ProductInfo>();
            products.AddRange(orderedProducts);
            lvOrderProducts.ItemsSource = products;
        }

        private void LoadDefaultData()
        {
            string jsonProduct = util.Get("api/Product");
            if (!string.IsNullOrEmpty(jsonProduct))
            {
                List<ProductInfo> productInfos = JsonSerializer.Deserialize<List<ProductInfo>>(jsonProduct);
                LoadProducts(productInfos);
            }
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;
            ProductInfo selectedProduct = (ProductInfo)button.DataContext;
            bool isExistedInCart = false;
            foreach (ProductInfo productInfo in orderedProducts)
            {
                if(productInfo.ProductId == selectedProduct.ProductId)
                {
                    productInfo.UnitPrice += selectedProduct.UnitPrice;
                    productInfo.UnitsInStock++;
                    LoadOrderedProduct();
                    isExistedInCart = true;
                    break;
                }
                else
                {
                    isExistedInCart = false;
                }
            }
            if (!isExistedInCart)
            {
                orderedProducts.Add(new ProductInfo
                {
                    ProductId = selectedProduct.ProductId,
                    ProductName = selectedProduct.ProductName,
                    UnitPrice = selectedProduct.UnitPrice,
                    UnitsInStock = 1
                });
                LoadOrderedProduct();
            }
        }
    }
}

﻿using Ass1Client.Model.Order;
using Ass1Client.Model.Product;
using Ass1Client.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace Ass1Client.View
{
    
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        CallAPIUtils util;
        static List<OrderDetailCreateDTO> orderedDetails;
        public OrderWindow()
        {
            InitializeComponent();
            util = new CallAPIUtils();
            orderedDetails = new List<OrderDetailCreateDTO>();
            lvOrderProducts.ItemsSource = orderedDetails;
            if(PseudoSession.Role == 1)
            {
                panelCreateOrder.Visibility = Visibility.Collapsed;
            }
            if(PseudoSession.Role == 2)
            {
                btnReportNav.Visibility = Visibility.Collapsed;
                btnProductNav.Visibility = Visibility.Collapsed;
            }
            LoadDefaultData();
        }

        private void LoadProducts(IEnumerable<ProductInfo> productInfos)
        {
            lvProducts.ItemsSource = productInfos;
        }

        private void LoadOrders(IEnumerable<OrderInfoDTO> orderInfos)
        {
            lvOrders.ItemsSource = orderInfos;
        }

        private void LoadOrderedProduct()
        {
            List<OrderDetailCreateDTO> orders = new List<OrderDetailCreateDTO>();
            orders.AddRange(orderedDetails);
            lvOrderProducts.ItemsSource = orders;
        }

        private void LoadDefaultData()
        {
            string jsonProduct = util.Get("api/Product");
            string jsonOrder = string.Empty;
            if (PseudoSession.Role == 1)
            {
                jsonOrder = util.Get("api/Order");
            }
            else
            {
                jsonOrder = util.Get($"api/Order/{PseudoSession.LoginUser.MemberId}/orders");
            }
            if (!string.IsNullOrEmpty(jsonProduct) && !string.IsNullOrEmpty(jsonOrder))
            {
                List<OrderInfoDTO> orderInfoDTOs = JsonSerializer.Deserialize<List<OrderInfoDTO>>(jsonOrder); 
                List<ProductInfo> productInfos = JsonSerializer.Deserialize<List<ProductInfo>>(jsonProduct);
                LoadOrders(orderInfoDTOs);
                LoadProducts(productInfos);
            }
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            // Get Information of the selected product
            Button button = (Button) sender;
            ProductInfo selectedProduct = (ProductInfo)button.DataContext;

            // Check if the product has been already added to cart before
            bool isExistedInCart = false;
            foreach (var productInfo in orderedDetails)
            {
                if(productInfo.ProductId == selectedProduct.ProductId)
                {
                    productInfo.Price += selectedProduct.UnitPrice;
                    productInfo.Quantity++;
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
                orderedDetails.Add(new OrderDetailCreateDTO
                {
                    ProductId = selectedProduct.ProductId,
                    ProductName = selectedProduct.ProductName,
                    Price = selectedProduct.UnitPrice,
                    Quantity = 1
                });
                LoadOrderedProduct();
            }
        }

        private void btnProductSearch_Click(object sender, RoutedEventArgs e)
        {
            string hint = tbProductSearch.Text;
            string json = util.Get($"api/Product/{hint}");
            IEnumerable<ProductInfo> products = JsonSerializer.Deserialize<IEnumerable<ProductInfo>>(json);
            LoadProducts(products);
        }

        private void btnConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime requireddate = dpkRequiredDate.SelectedDate.HasValue ?
                dpkRequiredDate.SelectedDate.Value : throw new Exception("You have to choose required date");
                OrderCreateDTO orderCreateDTO = new OrderCreateDTO
                {
                    RequiredDate = requireddate,
                    OrderDate = DateTime.Now,
                    MemberId = PseudoSession.LoginUser.MemberId,
                    OrderDetails = orderedDetails
                };
                string json = JsonSerializer.Serialize<OrderCreateDTO>(orderCreateDTO);
                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                util.Post("api/Order", httpContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewOrder_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            OrderInfoDTO selectedOrder = (OrderInfoDTO)button.DataContext;
            OrderDetailWindow window = new OrderDetailWindow(selectedOrder.OrderId);
            window.Show();
            this.Close();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            string jsonProduct = util.Get("api/Product");
            List<ProductInfo> productInfos = JsonSerializer.Deserialize<List<ProductInfo>>(jsonProduct);
            LoadProducts(productInfos);
        }

        private void btnProfileNav_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow window = new ProfileWindow(PseudoSession.Role, PseudoSession.LoginUser);
            this.Close();
            window.Show();
        }

        private void btnProductNav_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow window = new ProductWindow();
            this.Close();
            window.Show();
        }

        private void btnReportNav_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow window = new ReportWindow();
            this.Close();
            window.Show();
        }
    }
}

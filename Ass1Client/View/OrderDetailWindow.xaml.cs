using Ass1Client.Model.Order;
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
using System.Windows.Shapes;

namespace Ass1Client.View
{
    /// <summary>
    /// Interaction logic for OrderDetailWindow.xaml
    /// </summary>
    public partial class OrderDetailWindow : Window
    {
        CallAPIUtils util;
        int _orderId;
        public OrderDetailWindow(int orderId)
        {
            InitializeComponent();
            util = new CallAPIUtils();
            _orderId = orderId;
            if(PseudoSession.Role != 1)
            {
                dpkRequiredDate.IsEnabled = false;
                panelAdminArea.Visibility = Visibility.Collapsed;
            }
            LoadData();
        }

        private void LoadData()
        {
            string json = util.Get($"api/Order/{_orderId}");
            if (string.IsNullOrEmpty(json))
            {
                MessageBox.Show("Server Error");
            }
            else
            {
                OrderWithDetailDTO orderWithDetailDTO = JsonSerializer.Deserialize<OrderWithDetailDTO>
                    (json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (orderWithDetailDTO != null)
                {
                    dpkOrderDate.SelectedDate = orderWithDetailDTO.OrderDate;
                    dpkRequiredDate.SelectedDate = orderWithDetailDTO.RequiredDate;
                    dpkShippedDate.SelectedDate = orderWithDetailDTO.ShippedDate;
                    tbFreight.Text = orderWithDetailDTO.Freight.ToString();
                    lvOrderDetails.ItemsSource = orderWithDetailDTO.OrderDetails;
                    lblOrderValue.Content = orderWithDetailDTO.OrderDetails.Sum(od => od.Price).ToString();
                }
            }
        }

        private void btnUpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            DateTime? shippedDate = dpkShippedDate.SelectedDate;
            string text = tbFreight.Text;
            if(!string.IsNullOrEmpty(text) && shippedDate.HasValue) 
            {
                OrderUpdateDTO order = new OrderUpdateDTO
                {
                    OrderId = _orderId,
                    ShippedDate = dpkOrderDate.SelectedDate.Value,
                    Freight = double.Parse(text)
                };
                string json = JsonSerializer.Serialize(order);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                string response = util.Put($"api/Order/{_orderId}",httpContent);
                if (response == "error")
                {
                    MessageBox.Show("Update failed!");
                }
                else
                {
                    MessageBox.Show("Update successfully!");
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Check data again!");
            }
        }

        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            string response = util.Delete($"api/Order/{_orderId}");
            if(response == "error")
            {
                MessageBox.Show("Can not delete order!");
            }
            else
            {
                MessageBox.Show("Delete successfully!");
                OrderWindow window = new OrderWindow();
                this.Close();
                window.Show();
            }
        }

        private void btnDeleteDetail_Click(object sender, RoutedEventArgs e)
        {
            int productId = (int)lblProductId.Content;
            string json = util.Get($"api/Order/{_orderId}");
            if (string.IsNullOrEmpty(json))
            {
                MessageBox.Show("Server Error");
            }
            else
            {
                OrderWithDetailDTO orderWithDetailDTO = JsonSerializer.Deserialize<OrderWithDetailDTO>
                    (json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (orderWithDetailDTO != null)
                {
                    if(orderWithDetailDTO.OrderDetails.Count <= 1)
                    {
                        MessageBox.Show("Can not clear items of order!");
                    }
                }
            }
            string response = util.Delete($"api/Order/detail/{_orderId}/{productId}");
            if(response == "error")
            {
                MessageBox.Show("Can not remove the item from order!");
            }
            else
            {
                MessageBox.Show("Delete successfully!");
                LoadData();
            }
        }

        private void btnUpdateDetail_Click(object sender, RoutedEventArgs e)
        {
            int productId = (int)lblProductId.Content;
            OrderDetailUpdateDTO od = new OrderDetailUpdateDTO
            {
                OrderId = _orderId,
                ProductId = productId,
                Discount = double.Parse(tbDiscount.Text),
                Quantity = int.Parse(tbQuantity.Text)
            };
            string json = JsonSerializer.Serialize(od);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            util.Put($"api/Order/detail", httpContent);
            LoadData();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OrderWindow window = new OrderWindow();
            window.Show();
        }
    }
}

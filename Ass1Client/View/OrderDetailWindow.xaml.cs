using Ass1Client.Model.Order;
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
    /// Interaction logic for OrderDetailWindow.xaml
    /// </summary>
    public partial class OrderDetailWindow : Window
    {
        CallAPIUtils util;
        public OrderDetailWindow(int orderId)
        {
            InitializeComponent();
            util = new CallAPIUtils();
            string json = util.Get($"api/Order/{orderId}");
            if (string.IsNullOrEmpty(json))
            {
                MessageBox.Show("Server Error");
            }
            else
            {
                OrderWithDetailDTO orderWithDetailDTO = JsonSerializer.Deserialize<OrderWithDetailDTO>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
                if(orderWithDetailDTO != null )
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

        }

        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteDetail_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateDetail_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

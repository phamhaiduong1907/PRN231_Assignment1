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
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        CallAPIUtils util;
        public ReportWindow()
        {
            InitializeComponent();
            util = new CallAPIUtils();
            string json = util.Get($"api/Order/report");
            IEnumerable<OrderReportDTO> orders = JsonSerializer.Deserialize<IEnumerable<OrderReportDTO>>( json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true} );
            lvOrders.ItemsSource = orders;
            lblTotalCost.Content = $"{orders.Sum(o => o.Price)}";
        }

        private void btnProductNav_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow window = new ProductWindow();
            window.Show();
            this.Close();
        }

        private void btnOrderNav_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow window = new OrderWindow();
            window.Show();
            this.Close();
        }

        private void btnProfileNav_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow window = new ProfileWindow(PseudoSession.Role, PseudoSession.LoginUser);
            window.Show();
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
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

namespace Ass1Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:5170/");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage resp = client.GetAsync("WeatherForecast").Result;
            //if (resp.IsSuccessStatusCode)
            //{
            //    string content = resp.Content.ReadAsStringAsync().Result;
            //    MessageBox.Show(content.Substring(0, 20));
            //}
            //else
            //{
            //    MessageBox.Show("server error");
            //}
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            tbPassword.Text = pwbPassword.Password;
            pwbPassword.Visibility = Visibility.Collapsed;
            tbPassword.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            pwbPassword.Password = tbPassword.Text;
            pwbPassword.Visibility = Visibility.Visible;
            tbPassword.Visibility = Visibility.Collapsed;
        }
    }
}

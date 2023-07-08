using Ass1Client.Model.Member;
using Ass1Client.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Ass1Client.View
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        CallAPIUtils util;
        int _role;
        MemberInfo _loginUser;
        public ProfileWindow(int role, MemberInfo loginUser)
        {
            InitializeComponent();
            util = new CallAPIUtils();
            _role = role;
            _loginUser = loginUser;
            LoadStartupData();
        }

        private void LoadListData(List<MemberInfo> members)
        {
            lvUsers.ItemsSource = members;
        }

        private void LoadDefaultListData()
        {
            string json = util.Get("api/Member");
            List<MemberInfo> memberInfos = new List<MemberInfo>();
            if (!string.IsNullOrEmpty(json))
            {
                memberInfos = JsonSerializer.Deserialize<List<MemberInfo>>(json);
            }
            LoadListData(memberInfos);
        }

        private void LoadStartupData()
        {
            // admin
            if (_role == 1)
            {
                string json = util.Get("api/Member");
                List<MemberInfo> memberInfos = new List<MemberInfo>();
                if (!string.IsNullOrEmpty(json))
                {
                    memberInfos = JsonSerializer.Deserialize<List<MemberInfo>>(json);
                }
                LoadListData(memberInfos);
            }
            // normal user
            else
            {
                panelSearch.Visibility = Visibility.Collapsed;
                lvUsers.Visibility = Visibility.Collapsed;
                btnProductNav.Visibility = Visibility.Collapsed;
                tbMemberId.Visibility = Visibility.Collapsed;
                btnCreate.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
                btnReportNav.Visibility = Visibility.Collapsed;
                BindingOperations.ClearBinding(tbMemberId, TextBox.TextProperty);
                BindingOperations.ClearBinding(tbEmail, TextBox.TextProperty);
                BindingOperations.ClearBinding(tbPassword, TextBox.TextProperty);
                BindingOperations.ClearBinding(tbCompany, TextBox.TextProperty);
                BindingOperations.ClearBinding(tbCountry, TextBox.TextProperty);
                BindingOperations.ClearBinding(tbCity, TextBox.TextProperty);
                tbMemberId.Text = _loginUser.MemberId.ToString();
                tbEmail.Text = _loginUser.Email;
                pwbPassword.Password = _loginUser.Password;
                tbPassword.Text = _loginUser.Password;
                tbCompany.Text = _loginUser.CompanyName;
                tbCountry.Text = _loginUser.Country;
                tbCity.Text = _loginUser.City;

            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(tbMemberId.Text);
                string result = util.Delete($"api/Member/{id}");
                if (result == "error")
                    throw new Exception("Error processing the data!");
                else
                {
                    MessageBox.Show("Delete Product Successfully!");
                    LoadDefaultListData();
                }
            }
            catch(Exception ex)  
            {
                MessageBox.Show(ex.Message); 
            }
            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            bool showPass = cbShowPass.IsChecked.HasValue ? cbShowPass.IsChecked.Value : false;
            string password = string.Empty;
            if (showPass)
                password = tbPassword.Text;
            else
                password = pwbPassword.Password;
            MemberInfo member = new MemberInfo
            {
                MemberId = int.Parse(tbMemberId.Text),
                Email = tbEmail.Text,
                CompanyName = tbCompany.Text,
                Country = tbCountry.Text,
                City = tbCity.Text,
                Password = password
            };
            string json = JsonSerializer.Serialize<MemberInfo>(member);
            HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            string result = util.Put($"api/Member/{int.Parse(tbMemberId.Text)}", httpContent);
            if (result == "error")
                throw new Exception("check your data again");
            else
            {
                MessageBox.Show("Update Product Successfully!");
                LoadDefaultListData();
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            tbPassword.Text = pwbPassword.Password;
            tbPassword.Visibility = Visibility.Visible;
            pwbPassword.Visibility = Visibility.Collapsed;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            pwbPassword.Password = tbPassword.Text;
            pwbPassword.Visibility = Visibility.Visible;
            tbPassword.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadDefaultListData();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool showPass = cbShowPass.IsChecked.HasValue ? cbShowPass.IsChecked.Value : false;
                string password = string.Empty;
                if (showPass)
                    password = tbPassword.Text;
                else
                    password = pwbPassword.Password;
                MemberInfo member = new MemberInfo
                {
                    MemberId = 0,
                    Email = tbEmail.Text,
                    CompanyName = tbCompany.Text,
                    Country = tbCountry.Text,
                    City = tbCity.Text,
                    Password = password
                };
                string json = JsonSerializer.Serialize<MemberInfo>(member);
                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                string result = util.Post($"api/Member", httpContent);
                if (result == "error")
                    throw new Exception("check your data again");
                else
                {
                    MessageBox.Show("Add User Successfully!");
                    LoadDefaultListData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search_query = tbSearch.Text;
            string json = util.Get($"api/Member/search?search_query={search_query}");
            List<MemberInfo> result = JsonSerializer.Deserialize<List<MemberInfo>>(json);
            LoadListData(result);
        }

        private void btnOrderNav_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow window = new OrderWindow();
            window.Show();
            this.Close();
        }

        private void btnProductNav_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow window = new ProductWindow();
            window.Show();
            this.Close();
        }

        private void btnReportNav_Click(object sender, RoutedEventArgs e)
        {
            new ReportWindow().Show();
            this.Close();
        }
    }
}

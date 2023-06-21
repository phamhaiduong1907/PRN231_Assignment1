using Ass1Client.Model.Member;
using Ass1Client.Utilities;
using Ass1Client.View;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace Ass1Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CallAPIUtils util;
        public MainWindow()
        {
            InitializeComponent();
            util = new CallAPIUtils();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = tbEmail.Text;
                string passwordOrgin = pwbPassword.Password;
                string passwordRep = tbPassword.Text;
                bool isPasswordShown = cbShowPass.IsChecked.HasValue?cbShowPass.IsChecked.Value:false;
                string password = string.Empty;
                int role = 0;
                MemberInfo loginUser = null;
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",true, true).Build();
                if (isPasswordShown)
                {
                    password = passwordRep;
                }
                else
                {
                    password = passwordOrgin;
                }

                if (!config["admin:email"].Equals(email) && !config["admin:password"].Equals(password))
                {
                    string json = util.Get($"api/Member/login?username={email}&password={password}");
                    if (string.IsNullOrEmpty(json))
                    {
                        throw new Exception($"Check your email and password again!");
                    }
                    else
                    {
                        MemberInfo? memberInfo = JsonSerializer.Deserialize<MemberInfo>(json);
                        if (memberInfo != null)
                        {
                            loginUser = memberInfo;
                            role = 2;
                        }
                    }
                }
                else
                {
                    if (config["admin:email"].Equals(email) && config["admin:password"].Equals(password))
                    {
                        role = 1;
                    }
                    else
                    {
                        throw new Exception($"Check your email and password again!");
                    }
                }
                PseudoSession.LoginUser = loginUser;
                PseudoSession.Role = role;
                ProfileWindow profileWindow = new ProfileWindow(role, loginUser);
                profileWindow.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

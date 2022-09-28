using BusinessObject.Entity;
using MahApps.Metro.Controls.Dialogs;
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
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        private static MainWindow _main;
        public static AppSettings AppSettings = AppManager.GetAppsetting();

        public WindowLogin(MainWindow main)
        {
            _main = main;
            InitializeComponent();
        }

        private void btnLogin_click(object sender, RoutedEventArgs e)
        {
            try
            {
                var email = txtEmail.Text;
                var password = txtPassword.Text;

                if (email == "" || password == "")
                {
                    MessageBox.Show("Email or Password cannot be empty!");
                }
                else
                {

                    if (email == AppSettings.AdminAccount.Email)
                    {
                        if (password == AppSettings.AdminAccount.Password)
                        {
                            AppManager.setCurrentRole(true);
                            _main.Show();
                        }
                        else
                        {
                            MessageBox.Show("Password admin account is invalid");
                        }
                    }
                    else
                    {
                        var context = new FStoreDBContext();
                        var validEmail = context.Members.Where(c => c.Email == email).FirstOrDefault();
                        if (validEmail == null)
                        {
                            MessageBox.Show("Account not exsist!");
                        }
                        else if (validEmail != null && validEmail.Password != password)
                        {
                            MessageBox.Show("Password is invalid!");
                        }
                        else
                        {
                            MessageBox.Show("Login successfull");
                            _main.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

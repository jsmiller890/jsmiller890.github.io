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
using System.Data.SqlClient;

namespace WPFRegisterStudent
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        private void loginbtnClick(object sender, RoutedEventArgs e)
        {
            //-- Verification code that email and password match info in database
            String email = nametxtbox.Text;
            String password = passwordtxtbox.Text;
            errorTxtbox.Content = "";
            //Directive for where to send the user based on Admin privileges
            switch (clsDB.PasswordCheck(email, password))
            {
                case 0:
                    errorTxtbox.Content = "Email or Password is Incorrect";
                    break;
                case 1:
                    AdminWindow newAdminWindow = new AdminWindow();
                    newAdminWindow.Show();
                    this.Close();
                    break;
                case 2:
                    MainWindow newMainWindow = new MainWindow(email);
                    newMainWindow.Show();
                    this.Close();
                    break;
            }
        }
    }
}

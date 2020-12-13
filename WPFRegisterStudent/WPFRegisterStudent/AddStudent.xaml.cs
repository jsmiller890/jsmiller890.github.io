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

namespace WPFRegisterStudent
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public AddStudent()
        {
            InitializeComponent();
        }
        // -- Changes Button text based on adminCheckBox
        private void Admincheckbox_Checked(object sender, RoutedEventArgs e)
        {
            adduserbtn.Content = "Add Administrator";
        }

        private void Admincheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            adduserbtn.Content = "Add Student";
        }
        //----------------------------------------------

        // -- Logic in the event that adduserbtn is clicked
        private void Adduserbtn_Click(object sender, RoutedEventArgs e)
        {
            if (passwordtxtbox.Text == "" && Admincheckbox.IsChecked == false)
            {
                passwordtxtbox.Text = "password";
            }
            else if (passwordtxtbox.Text == "" && Admincheckbox.IsChecked == true)
            {
                passwordtxtbox.Text = "admin";
            }
            string sqlQuery = "INSERT INTO login(email, password, admin) VALUES('" + emailtxtbox.Text + "', '" + passwordtxtbox.Text + "', '" + Admincheckbox.IsChecked + "')";
            clsDB.Execute_SQL(sqlQuery);

            //Adds admin privileges if box is unchecked
            if (!(bool)Admincheckbox.IsChecked)
            {
                emailtxtbox.Text = clsDB.CheckUserEmail(firstnametxtbox.Text, lastnametxtbox.Text);
                sqlQuery = "INSERT INTO student(firstname, lastname, email, address, gpa, creditcount, totalcredits) VALUES('" + firstnametxtbox.Text + "', '" + lastnametxtbox.Text + "', '" + emailtxtbox.Text + "', '" + addresstxtbox.Text + "', '" + 0.0 + "', '" + 0 + "', '" + 0 + "')";
                clsDB.Execute_SQL(sqlQuery);
                emailtxtbox.Text = clsDB.CheckUserEmail(firstnametxtbox.Text, lastnametxtbox.Text);
            }
            passwordtxtbox.Text = "";
        }
        //------------------------------------------------

        //Changes the email textbox contents based on what is entered in firstname and lastname textboxes
        private void Firstnametxtbox_TextChanged(object sender, TextChangedEventArgs e)
        { 
            emailtxtbox.Text = clsDB.CheckUserEmail(firstnametxtbox.Text, lastnametxtbox.Text);
        }

        private void Lastnametxtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            emailtxtbox.Text = clsDB.CheckUserEmail(firstnametxtbox.Text, lastnametxtbox.Text);
        }

        //------------------------------------
        //Return to admin window

        private void Closebtn_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }
    }
}

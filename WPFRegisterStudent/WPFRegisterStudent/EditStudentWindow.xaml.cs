using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for EditStudentWindow.xaml
    /// </summary>
    public partial class EditStudentWindow : Window
    {
        Student choice;
        List<Student> students = new List<Student>();

        public EditStudentWindow()
        {

            InitializeComponent();
            int count = 1;
            string studentCountQuery = "SELECT COUNT(*) FROM student";
            SqlCommand countQuery = new SqlCommand(studentCountQuery, clsDB.Get_DB_Connection());
            int tableSize = (int)countQuery.ExecuteScalar();
            while(students.Count() < tableSize)
            {
                SqlCommand studentQuery = new SqlCommand("SELECT * FROM student WHERE Id = " + count, clsDB.Get_DB_Connection());
                SqlDataReader reader = studentQuery.ExecuteReader();
                while (reader.Read())
                {
                    if(reader != null)
                    {
                        students.Add(new Student((string)reader[1], (string)reader[2], (string)reader[3], (string)reader[4], (string)reader[7], (string)reader[8], (string)reader[9], (int)reader[6], (int)reader[10], (float)reader.GetDouble(5)));;
                    }
                }
                count++;

            }

            for (int i = 0; i < students.Count(); i++)
            {
                for (int j = i + 1; j < students.Count(); j++)
                {
                    if (students[i].getEmail().CompareTo(students[j].getEmail()) > 0)
                    {
                        Student temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }

                }

            }

            for (int i = 0; i < students.Count(); i++)
            {
                studentListbox.Items.Add(students[i].getEmail());
            }
        }

        private void StudentListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string email = studentListbox.SelectedItem.ToString();
            foreach (Student student in students)
            {
                if(student.getEmail() == email)
                {
                    choice = student;
                }
            }
            firstnametxtbox.Text = choice.getFirstName();
            lastnametxtbox.Text = choice.getLastName();
            emailtxtbox.Text = choice.getEmail();
            addresstxtbox.Text = choice.getAddress();
            SqlCommand passwordQuery = new SqlCommand("SELECT password FROM login WHERE email = '" + email + "'", clsDB.Get_DB_Connection());
            string password = (string)passwordQuery.ExecuteScalar();
            passwordtxtbox.Text = password;
            clsDB.Close_DB_Connection();
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            choice.setAddress(addresstxtbox.Text);
            string adminCheck = "False";
            if (Admincheckbox.IsChecked == true)
                adminCheck = "True";
            SqlCommand studentUpdateQuery = new SqlCommand("UPDATE student SET address = '" + choice.getAddress() + "' WHERE email = '" + choice.getEmail() + "'", clsDB.Get_DB_Connection());
            studentUpdateQuery.ExecuteNonQuery();
            clsDB.Close_DB_Connection();
            studentUpdateQuery = new SqlCommand("UPDATE login SET password = '" + passwordtxtbox.Text + "', admin = '" + adminCheck + "' WHERE email = '" + choice.getEmail() + "'", clsDB.Get_DB_Connection());
            studentUpdateQuery.ExecuteNonQuery();
        }

        private void Adddropbtn_Click(object sender, RoutedEventArgs e)
        {
            if (choice != null)
            {
                AdminMainWindow adminMainWindow = new AdminMainWindow(choice.getEmail());
                adminMainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please choose a student");
            }
        }

        private void Cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
        }

        private void Admincheckbox_Checked(object sender, RoutedEventArgs e)
        {
            Admincheckbox.IsChecked = true;
        }

        private void Admincheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            Admincheckbox.IsChecked = false;
        }
    }
}

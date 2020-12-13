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
    /// Interaction logic for EditClassWindow.xaml
    /// </summary>
    public partial class EditClassWindow : Window
    {
        //initialize the global variables
        List<Course> courses = new List<Course>();
        Course choice = null;

        public EditClassWindow()
        {
            //access the course information from the classes database
            InitializeComponent();
            int count = 1;
            string courseCountQuery = "SELECT COUNT(*) FROM classes";
            SqlCommand countQuery = new SqlCommand(courseCountQuery, clsDB.Get_DB_Connection());
            int tableSize = (int)countQuery.ExecuteScalar();
            while (courses.Count() < tableSize)
            {
                SqlCommand courseQuery = new SqlCommand("SELECT * FROM classes WHERE Id = " + count, clsDB.Get_DB_Connection());
                SqlDataReader reader = courseQuery.ExecuteReader();
                while (reader.Read())
                {
                    if (reader != null)
                    {
                        courses.Add(new Course((string)reader[1], (string)reader[2], (string)reader[6], (string)reader[7], (int)reader[3], (int)reader[4], (int)reader[5])); ;
                    }
                }
                count++;

            }

            //sorts courses by courseID

            for (int i = 0; i < courses.Count(); i++)
            {
                for (int j = i + 1; j < courses.Count(); j++)
                {
                    if (courses[i].getCourseId().CompareTo(courses[j].getCourseId()) > 0)
                    {
                        Course temp = courses[i];
                        courses[i] = courses[j];
                        courses[j] = temp;
                    }

                }

            }

            //loads courseIDs into the listbox

            for (int i = 0; i < courses.Count(); i++)
            {
                courseIdlistbox.Items.Add(courses[i].getCourseId());
            }
        }

        private void Acceptchangebtn_Click(object sender, RoutedEventArgs e)
        {
            //sends data in textboxes to SQL database
            choice.setCourseId(courseidtxtbox.Text);
            choice.setName(coursenametxtbox.Text);
            choice.setCourseDesc(descriptiontxtbox.Text);
            choice.setCreditHours(Convert.ToInt32(credithourstxtbox.Text));
            choice.setClassSize(Convert.ToInt32(classsizetxtbox.Text));
            choice.setStudentsRegistered(Convert.ToInt32(registeredtxtbox.Text));
            SqlCommand courseUpdateQuery = new SqlCommand("UPDATE classes SET courseId = '" + choice.getCourseId() + "', name = '" + choice.getName() + "', credithours = " + choice.getCreditHours() + ", classSize = " + choice.getClassSize() + ", studentsRegistered = " + choice.getStudentsRegistered() + ", courseDescription = '" + choice.getCourseDesc() + "' WHERE courseId = '" + choice.getCourseId() + "'", clsDB.Get_DB_Connection());
            courseUpdateQuery.ExecuteNonQuery();
            clsDB.Close_DB_Connection();
            MessageBox.Show(choice.getCourseId() + " was successfully updated.");
        }

        private void Cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
            //returns to admin window
        }

        private void CourseIdlistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //logic for updating information in textboxes when selection is changed in listbox
            string courseId = courseIdlistbox.SelectedItem.ToString();
            foreach (Course course in courses)
            {
                if (course.getCourseId() == courseId)
                {
                    choice = course;
                }
            }
            courseidtxtbox.Text = choice.getCourseId();
            coursenametxtbox.Text = choice.getName();
            descriptiontxtbox.Text = choice.getCourseDesc();
            credithourstxtbox.Text = choice.getCreditHours().ToString();
            classsizetxtbox.Text = choice.getClassSize().ToString();
            registeredtxtbox.Text = choice.getStudentsRegistered().ToString();
            clsDB.Close_DB_Connection();
        }
    }
}

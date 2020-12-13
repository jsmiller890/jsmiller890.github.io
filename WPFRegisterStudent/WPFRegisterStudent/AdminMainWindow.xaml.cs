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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFRegisterStudent
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {

        //--------------------------
        //initializes the global variables
        string courseIdChosen;
        Course choice;
        Course course;
        Course selectedCourse;
        string listChoice;
        Student student;
        List<Course> courses = new List<Course>();
        SqlConnection cn_connection = clsDB.Get_DB_Connection();

        string studentEmail = "";


        public AdminMainWindow(string email)
        {
            //----------------------
            //access student's info from student database using the email passed from the edit user window
            InitializeComponent();
            this.Title = email;
            this.studentEmail = email;
            SqlCommand studentQuery = new SqlCommand("SELECT * FROM student WHERE email = '" + email + "'", cn_connection);
            SqlDataReader reader = studentQuery.ExecuteReader();
            while (reader.Read())
            {
                student = new Student((string)reader[1], (string)reader[2], (string)reader[3], (string)reader[4], (string)reader[7], (string)reader[8], (string)reader[9], (int)reader[6], (int)reader[10], (float)reader.GetDouble(5));
            }
            listBox.Items.Add(student.getCurrentClass1());
            listBox.Items.Add(student.getCurrentClass2());
            listBox.Items.Add(student.getCurrentClass3());
            textBox.Text = student.getCreditHours().ToString();
            reader.Close();
        }
        //-- Adds and loads courses into combobox
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int count = 1;
            string courseCountQuery = "SELECT COUNT(*) FROM classes";
            SqlCommand countQuery = new SqlCommand(courseCountQuery, cn_connection);
            int tableSize = (int)countQuery.ExecuteScalar();
            List<string> courseIds = new List<string>();
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

            //sorts the courses by courseID

            for (int i = 0; i < courses.Count(); i++)
            {
                for (int j = i+1; j < courses.Count(); j++)
                {
                    if(courses[i].getCourseId().CompareTo(courses[j].getCourseId()) > 0)
                    { 
                        Course temp = courses[i];
                        courses[i] = courses[j];
                        courses[j] = temp;
                    }

                }

            }

            //loads courses into combobox
            for (int i = 0; i < courses.Count(); i++)
            {
                comboBox.Items.Add(courses[i].getCourseId());
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //changes the information displayed based on which course is selected
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if(courses[i].getCourseId() == (string)comboBox.Items.CurrentItem)
                {
                    course = courses[i];
                    string courseIdSelected = courses[i].getCourseId();
                    Course currentSelection = courses[i];
                    string courseDesc = currentSelection.getCourseDesc();
                    this.courseIdtxtblk.Text = currentSelection.getCourseId();
                    this.coursedesctxtblk.Text = courseDesc;
                    this.seatsremainingtxtblk.Text = (currentSelection.getClassSize() - currentSelection.getStudentsRegistered()).ToString();
                    this.credithourstxtblk.Text = currentSelection.getCreditHours().ToString();
                }
            }            
        }
        //------------------------------

        //Logic in the event of registration button clicked
        private void button_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            courseIdChosen = (string)this.comboBox.SelectedItem;
            for(int i = 0; i < courses.Count(); i++)
            {
                if(courses[i].getCourseId() == courseIdChosen)
                {
                    choice = courses[i];
                }
            }
            int totalCredits = Convert.ToInt32(textBox.Text);
            //Display error message if no choice is selected
            if (choice == null)
            {
                label3.Content = string.Format("Please choose a course to register for");
            }
            //Verification that student is able to register for selected class
            else if (student.getCurrentClass1() == choice.getCourseId() || student.getCurrentClass2() == choice.getCourseId() || student.getCurrentClass3() == choice.getCourseId())
            {
                label3.Content = string.Format("You have alread registered for {0}.", choice.getCourseId());
            }
            else if (student.getCurrentClass1() != "" && student.getCurrentClass2() != "" && student.getCurrentClass3() != "")
            {
                label3.Content = string.Format("You can not register for more than 9 credit hours.");
            }
            else if (student.getCurrentClass1() == "")
            {
                SqlCommand updateStudentInfo = new SqlCommand("UPDATE student SET currentclass1 = '" + choice.getCourseId() + "', creditcount = '" + (student.getCreditHours() + 3) + "' WHERE email = '" + studentEmail + "'", cn_connection);
                updateStudentInfo.ExecuteNonQuery();
                textBox.Text = Convert.ToString(student.getCreditHours());
                label3.Content = string.Format("Registration confirmed for course {0}", choice.getCourseId());
                SqlCommand updateClassNumber = new SqlCommand("UPDATE classes SET studentsRegistered = " + (course.getStudentsRegistered() + 1) + " WHERE courseId = '" + choice.getCourseId() + "'", cn_connection);
                updateClassNumber.ExecuteNonQuery();
                student.setCurrentClass1(choice.getCourseId());
                student.setCreditHours(student.getCreditHours() + 3);
            }
            else if (student.getCurrentClass1() != "" && student.getCurrentClass2() == "")
            {
                SqlCommand updateStudentInfo = new SqlCommand("UPDATE student SET currentclass2 = '" + choice.getCourseId() + "', creditcount = '" + (student.getCreditHours() + 3) + "' WHERE email = '" + studentEmail + "'", cn_connection);
                updateStudentInfo.ExecuteNonQuery();
                textBox.Text = Convert.ToString(student.getCreditHours());
                label3.Content = string.Format("Registration confirmed for course {0}", choice.getCourseId());
                SqlCommand updateClassNumber = new SqlCommand("UPDATE classes SET studentsRegistered = " + (course.getStudentsRegistered() + 1) + " WHERE courseId = '" + choice.getCourseId() + "'", cn_connection);
                updateClassNumber.ExecuteNonQuery();
                student.setCurrentClass2(choice.getCourseId());
                student.setCreditHours(student.getCreditHours() + 3);
            }
            else if (student.getCurrentClass2() != "" && student.getCurrentClass3() == "")
            {
                SqlCommand updateStudentInfo = new SqlCommand("UPDATE student SET currentclass3 = '" + choice.getCourseId() + "', creditcount = '" + (student.getCreditHours() + 3) + "' WHERE email = '" + studentEmail + "'", cn_connection);
                updateStudentInfo.ExecuteNonQuery();
                textBox.Text = Convert.ToString(student.getCreditHours());
                label3.Content = string.Format("Registration confirmed for course {0}", choice.getCourseId());
                SqlCommand updateClassNumber = new SqlCommand("UPDATE classes SET studentsRegistered = " + (course.getStudentsRegistered() + 1) + " WHERE courseId = '" + choice.getCourseId() + "'", cn_connection);
                updateClassNumber.ExecuteNonQuery();
                student.setCurrentClass3(choice.getCourseId());
                student.setCreditHours(student.getCreditHours() + 3);
            }
            listBox.Items.Add(student.getCurrentClass1());
            listBox.Items.Add(student.getCurrentClass2());
            listBox.Items.Add(student.getCurrentClass3());
            textBox.Text = student.getCreditHours().ToString();
        }

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //logic for a selection change in the drop listbox
            foreach (Course course in courses)
            {
                if((string)listBox.SelectedItem == course.getCourseId())
                {
                    selectedCourse = course;
                    break;
                }
            }
        }

        private void dropbutton_Click(object sender, RoutedEventArgs e)
        {
            //-----------------------------------------
            //logic for dropping a class and SQL logic
            //for removing the courseID from the student's schedule
            listChoice = (string)listBox.SelectedItem;
            if (listChoice == null || listChoice == "")
            {
                label3.Content = "Please select a class to drop.";
            }
            else if (student.getCurrentClass1() == selectedCourse.getCourseId())
            { 
                SqlCommand updateStudentInfo = new SqlCommand("UPDATE student SET currentclass1 = '', creditcount = " + (student.getCreditHours() - 3), clsDB.Get_DB_Connection());
                updateStudentInfo.ExecuteNonQuery();
                label3.Content = string.Format("{0} successfully dropped", selectedCourse.getCourseId());
                SqlCommand updateClassNumber = new SqlCommand("UPDATE classes SET studentsRegistered = " + (selectedCourse.getStudentsRegistered() + 1), clsDB.Get_DB_Connection());
                updateClassNumber.ExecuteNonQuery();
                student.setCurrentClass1("");
                student.setCreditHours(student.getCreditHours() - 3);
            }
            else if (student.getCurrentClass2() == selectedCourse.getCourseId())
            {
                SqlCommand updateStudentInfo = new SqlCommand("UPDATE student SET currentclass2 = '', creditcount = " + (student.getCreditHours() - 3), clsDB.Get_DB_Connection());
                updateStudentInfo.ExecuteNonQuery();
                label3.Content = string.Format("{0} successfully dropped", selectedCourse.getCourseId());
                SqlCommand updateClassNumber = new SqlCommand("UPDATE classes SET studentsRegistered = " + (selectedCourse.getStudentsRegistered() + 1), clsDB.Get_DB_Connection());
                updateClassNumber.ExecuteNonQuery();
                student.setCurrentClass2("");
                student.setCreditHours(student.getCreditHours() - 3);
            }
            else if (student.getCurrentClass3() == selectedCourse.getCourseId())
            {
                SqlCommand updateStudentInfo = new SqlCommand("UPDATE student SET currentclass3 = '', creditcount = " + (student.getCreditHours() - 3), clsDB.Get_DB_Connection());
                updateStudentInfo.ExecuteNonQuery();
                label3.Content = string.Format("{0} successfully dropped", selectedCourse.getCourseId());
                SqlCommand updateClassNumber = new SqlCommand("UPDATE classes SET studentsRegistered = " + (selectedCourse.getStudentsRegistered() + 1), clsDB.Get_DB_Connection());
                updateClassNumber.ExecuteNonQuery();
                student.setCurrentClass3("");
                student.setCreditHours(student.getCreditHours() - 3);
            }
            listBox.Items.Clear();
            listBox.Items.Add(student.getCurrentClass1());
            listBox.Items.Add(student.getCurrentClass2());
            listBox.Items.Add(student.getCurrentClass3());
            textBox.Text = student.getCreditHours().ToString();
        }

        private void closebtn_Click(object sender, RoutedEventArgs e)
        {
            //close window
            EditStudentWindow editStudentWindow = new EditStudentWindow();
            editStudentWindow.Show();
            Close();
        }
    }
}

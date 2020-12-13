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
    /// Interaction logic for AdminAddDropWindow.xaml
    /// </summary>
    public partial class AdminAddDropWindow : Window
    {
        //---------------------------
        //initialize global variables

        Student studentChoice = null;
        List<Student> students = new List<Student>();
        Course addChoice = null;
        Course dropChoice = null;
        List<Course> courses = new List<Course>();

        public AdminAddDropWindow()
        {
            //-------------------------
            //access student database and populate student listbox with student emails

            InitializeComponent();
            int count = 1;
            string studentCountQuery = "SELECT COUNT(*) FROM student";
            SqlCommand countQuery = new SqlCommand(studentCountQuery, clsDB.Get_DB_Connection());
            int tableSize = (int)countQuery.ExecuteScalar();
            while (students.Count() < tableSize)
            {
                SqlCommand studentQuery = new SqlCommand("SELECT * FROM student WHERE Id = " + count, clsDB.Get_DB_Connection());
                SqlDataReader reader = studentQuery.ExecuteReader();
                while (reader.Read())
                {
                    if (reader != null)
                    {
                        students.Add(new Student((string)reader[1], (string)reader[2], (string)reader[3], (string)reader[4], (string)reader[7], (string)reader[8], (string)reader[9], (int)reader[6], (int)reader[10], (float)reader.GetDouble(5))); ;
                    }
                }
                count++;

            }

            //-----------------------------
            //sort students a-z by email

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

            //----------------------------
            //add student emails into listbox

            for (int i = 0; i < students.Count(); i++)
            {
                studentlistbox.Items.Add(students[i].getEmail());
            }

            //---------------------------
            //access course data from classes databases

            count = 1;
            string courseCountQuery = "SELECT COUNT(*) FROM classes";
            SqlCommand classCountQuery = new SqlCommand(courseCountQuery, clsDB.Get_DB_Connection());
            int classTableSize = (int)classCountQuery.ExecuteScalar();
            while (courses.Count() < classTableSize)
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

            //---------------------------------
            //sort courses by courseId

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

            //--------------------------------
            //add courseIds to listbox

            for (int i = 0; i < courses.Count(); i++)
            {
                addclasslistbox.Items.Add(courses[i].getCourseId());
            }

        }

        //--------------------------------------
        //logic for showing the selected student's current courses
        private void Studentlistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Student student in students)
            {
                if(student.getEmail() == studentlistbox.SelectedItem.ToString())
                {
                    studentChoice = student;
                    dropclasslistbox.Items.Clear();
                    dropclasslistbox.Items.Add(student.getCurrentClass1());
                    dropclasslistbox.Items.Add(student.getCurrentClass2());
                    dropclasslistbox.Items.Add(student.getCurrentClass3());
                    break;
                }
            }
        }

        //------------------------------------
        //logic for showing course information when the course is selected
        private void Addclasslistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(studentlistbox.SelectedItem == null)
            {
                label3.Content = "Please choose a student to add a class for.";
            }
            foreach (Course course in courses)
            {
                if(course.getCourseId() == addclasslistbox.SelectedItem.ToString())
                {
                    addChoice = course;
                    courseIdtxtblk.Text = course.getCourseId();
                    coursedesctxtblk.Text = course.getCourseDesc();
                    credithourstxtblk.Text = course.getCreditHours().ToString();
                    seatsremainingtxtblk.Text = (course.getClassSize() - course.getStudentsRegistered()).ToString();
                    break;
                }
            }
        }

        private void Dropclasslistbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //-------------------------------
            //logic for showing course information in the course drop listbox
            foreach (Course course in courses)
            {
                if(course.getCourseId() == (string)dropclasslistbox.SelectedItem)
                {
                    dropChoice = course;
                    courseIdtxtblk.Text = course.getCourseId();
                    coursedesctxtblk.Text = course.getCourseDesc();
                    credithourstxtblk.Text = course.getCreditHours().ToString();
                    seatsremainingtxtblk.Text = (course.getClassSize() - course.getStudentsRegistered()).ToString();
                    break;
                }
            }
        }

        //----------------------------------
        //logic for registering a student for a class
        //SQL logic for adding courseID to selected student
        //SQL logic for updating the number of students registered in a course

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if(addChoice == null)
            {
                label3.Content = "Please select a valid course";
            }
            else if (studentChoice == null)
            {
                label3.Content = "Please select a student";
            }
            else if (studentChoice.getCurrentClass1() == addChoice.getCourseId() || studentChoice.getCurrentClass2() == addChoice.getCourseId() || studentChoice.getCurrentClass3() == addChoice.getCourseId())
            {
                label3.Content = string.Format("This student is already registered for {0}.", addChoice.getCourseId());
            }
            else if (studentChoice.getCurrentClass1() != "" && studentChoice.getCurrentClass2() != "" && studentChoice.getCurrentClass3() != "")
            {
                label3.Content = string.Format("Students can not register for more than 9 credit hours.");
            }
            else if (studentChoice.getCurrentClass1() == "")
            {
                dropclasslistbox.Items.Add(addChoice.getCourseId());
                SqlCommand updateStudentInfo = new SqlCommand("UPDATE student SET currentclass1 = '" + addChoice.getCourseId() + "', creditcount = " + (studentChoice.getCreditHours() + 3), clsDB.Get_DB_Connection());
                updateStudentInfo.ExecuteNonQuery();
                label3.Content = string.Format("Registration confirmed for course {0}", addChoice.getCourseId());
                SqlCommand updateClassNumber = new SqlCommand("UPDATE classes SET studentsRegistered = " + (addChoice.getStudentsRegistered() - 1), clsDB.Get_DB_Connection());
                updateClassNumber.ExecuteNonQuery();
                studentChoice.setCurrentClass1(addChoice.getCourseId());
            }
            else if (studentChoice.getCurrentClass1() != "" && studentChoice.getCurrentClass2() == "")
            {
                dropclasslistbox.Items.Add(addChoice.getCourseId());
                SqlCommand updateStudentInfo = new SqlCommand("UPDATE student SET currentclass2 = '" + addChoice.getCourseId() + "', creditcount = " + (studentChoice.getCreditHours() + 3), clsDB.Get_DB_Connection());
                updateStudentInfo.ExecuteNonQuery();
                label3.Content = string.Format("Registration confirmed for course {0}", addChoice.getCourseId());
                SqlCommand updateClassNumber = new SqlCommand("UPDATE classes SET studentsRegistered = " + (addChoice.getStudentsRegistered() - 1), clsDB.Get_DB_Connection());
                updateClassNumber.ExecuteNonQuery();
                studentChoice.setCurrentClass2(addChoice.getCourseId());
            }
            else if (studentChoice.getCurrentClass2() != "" && studentChoice.getCurrentClass3() == "")
            {
                dropclasslistbox.Items.Add(addChoice.getCourseId());
                SqlCommand updateStudentInfo = new SqlCommand("UPDATE student SET currentclass3 = '" + addChoice.getCourseId() + "', creditcount = " + (studentChoice.getCreditHours() + 3), clsDB.Get_DB_Connection());
                updateStudentInfo.ExecuteNonQuery();
                label3.Content = string.Format("Registration confirmed for course {0}", addChoice.getCourseId());
                SqlCommand updateClassNumber = new SqlCommand("UPDATE classes SET studentsRegistered = " + (addChoice.getStudentsRegistered() - 1), clsDB.Get_DB_Connection());
                updateClassNumber.ExecuteNonQuery();
                studentChoice.setCurrentClass3(addChoice.getCourseId());
            }

            //resets listbox items
            dropclasslistbox.Items.Clear();
            dropclasslistbox.Items.Add(studentChoice.getCurrentClass1());
            dropclasslistbox.Items.Add(studentChoice.getCurrentClass2());
            dropclasslistbox.Items.Add(studentChoice.getCurrentClass3());
        }

        private void DropBtn_Click(object sender, RoutedEventArgs e)
        {
            //----------------------------------------
            //logic for dropping a class from a student's schedule
            //SQL logic removes the courseID and adds a position back to the class
            if (dropChoice == null)
            {
                label3.Content = "Please select a valid course";
            }
            else if (studentChoice == null)
            {
                label3.Content = "Please select a student";
            }
            else if (studentChoice.getCurrentClass1() != "" && studentChoice.getCurrentClass2() != "" && studentChoice.getCurrentClass3() != "")
            {
                label3.Content = string.Format("Students can not register for more than 9 credit hours.");
            }
            else if (studentChoice.getCurrentClass1() == dropChoice.getCourseId())
            {
                dropclasslistbox.Items.Remove(dropChoice.getCourseId());
                SqlCommand updateStudentInfo = new SqlCommand("UPDATE student SET currentclass1 = '', creditcount = " + (studentChoice.getCreditHours() - 3), clsDB.Get_DB_Connection());
                updateStudentInfo.ExecuteNonQuery();
                label3.Content = string.Format("{0} successfully dropped", dropChoice.getCourseId());
                SqlCommand updateClassNumber = new SqlCommand("UPDATE classes SET studentsRegistered = " + (dropChoice.getStudentsRegistered() + 1), clsDB.Get_DB_Connection());
                updateClassNumber.ExecuteNonQuery();
                studentChoice.setCurrentClass1("");
            }
            else if (studentChoice.getCurrentClass2() == dropChoice.getCourseId())
            {
                dropclasslistbox.Items.Remove(dropChoice.getCourseId());
                SqlCommand updateStudentInfo = new SqlCommand("UPDATE student SET currentclass2 = '', creditcount = " + (studentChoice.getCreditHours() - 3), clsDB.Get_DB_Connection());
                updateStudentInfo.ExecuteNonQuery();
                label3.Content = string.Format("{0} successfully dropped", dropChoice.getCourseId());
                SqlCommand updateClassNumber = new SqlCommand("UPDATE classes SET studentsRegistered = " + (dropChoice.getStudentsRegistered() + 1), clsDB.Get_DB_Connection());
                updateClassNumber.ExecuteNonQuery();
                studentChoice.setCurrentClass2("");
            }
            else if (studentChoice.getCurrentClass3() == dropChoice.getCourseId())
            {
                dropclasslistbox.Items.Remove(dropChoice.getCourseId());
                SqlCommand updateStudentInfo = new SqlCommand("UPDATE student SET currentclass3 = '', creditcount = " + (studentChoice.getCreditHours() - 3), clsDB.Get_DB_Connection());
                updateStudentInfo.ExecuteNonQuery();
                label3.Content = string.Format("{0} successfully dropped", dropChoice.getCourseId());
                SqlCommand updateClassNumber = new SqlCommand("UPDATE classes SET studentsRegistered = " + (dropChoice.getStudentsRegistered() + 1), clsDB.Get_DB_Connection());
                updateClassNumber.ExecuteNonQuery();
                studentChoice.setCurrentClass3("");
            }

            //resets the courses listed in the drop listbox
            dropclasslistbox.Items.Clear();
            dropclasslistbox.Items.Add(studentChoice.getCurrentClass1());
            dropclasslistbox.Items.Add(studentChoice.getCurrentClass2());
            dropclasslistbox.Items.Add(studentChoice.getCurrentClass3());
        }

        private void Closebtn_Click(object sender, RoutedEventArgs e)
        {
            //------------------------------
            //closes the window and opens admin window
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }
    }
}

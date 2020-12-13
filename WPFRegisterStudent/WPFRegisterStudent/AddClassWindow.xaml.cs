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
    /// Interaction logic for AddClassWindow.xaml
    /// </summary>
    public partial class AddClassWindow : Window
    {
        public AddClassWindow()
        {
            InitializeComponent();
        }

        //---------------------------
        //Insert course information into the classes database

        public void AddClassbtn_Click(object sender, RoutedEventArgs e)
        {
            string sqlQuery = "INSERT INTO classes(courseId, name, credithours, classSize, studentsRegistered) VALUES('" + courseidtxtbox.Text + "', '" + coursenametxtbox.Text + "', '" + credithourstxtbox.Text + "', '" + classsizetxtbox.Text + "', '" + registeredtxtbox.Text + "')";
            clsDB.Execute_SQL(sqlQuery);
            MessageBox.Show(courseidtxtbox.Text + " was successfully added.");
        }

        private void Closebtn_Click(object sender, RoutedEventArgs e)
        {
            //--------------------------
            //Return to adminWindow

            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }
    }
}

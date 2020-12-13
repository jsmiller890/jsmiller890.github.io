using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFRegisterStudent
{
    class clsDB
        //Class responsible for interacting with SQL database
    {
        public static SqlConnection Get_DB_Connection()

        {

            //--------< db_Get_Connection() >--------
            // Get a connection to the database using the default connection string

            string cn_String = Properties.Settings.Default.connection_String;
            SqlConnection cn_connection = new SqlConnection(cn_String);
            if (cn_connection.State != ConnectionState.Open) cn_connection.Open();

            return cn_connection;
        }

        public static DataTable Get_DataTable(string SQL_Text)

        {

            //--------< db_Get_DataTable() >--------

            SqlConnection cn_connection = Get_DB_Connection();

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(SQL_Text, cn_connection);
            adapter.Fill(table);

            return table;
        }

        public static void Execute_SQL(string SQL_Text)

        {

            //--------< Execute_SQL() >--------
            //Connects to the database and executes a command SQL_Text

            SqlConnection cn_connection = Get_DB_Connection();
            
            SqlCommand cmd_Command = new SqlCommand(SQL_Text, cn_connection);
            cmd_Command.ExecuteNonQuery();
        }

        //---------< Add Class to Student Information >------------

        public static void ClassAdd(string courseId, string email)
        {
            string addClassQuery = "";

        }

        public static string CheckUserEmail(string firstname, string lastname)
        {
            //Checks whether the email is already in use and adds a number if it is
            int count = 1;
            bool emailCheck = false;
            string email = firstname + "." + lastname + "@snhu.edu";
            while (!emailCheck)
            {
                SqlConnection cn_connection = Get_DB_Connection();
                string getEmail = "SELECT email FROM student WHERE email = '" + email + "'";
                SqlCommand emailCommand = new SqlCommand(getEmail, cn_connection);
                string emailQuery = (string)emailCommand.ExecuteScalar();
                if (emailQuery == null)
                {
                    return email;
                }
                else if ( emailQuery.ToLower() != email.ToLower())
                {
                    return email;
                }
                email = firstname + "." + lastname + count.ToString() + "@snhu.edu";
                count++;
                cn_connection.Close();
            }
            return email;
        }

        public static int PasswordCheck(string email, string password)
        {
            //verifies the password provided is the same that is stored in the database for provided email
            SqlConnection cn_connection = Get_DB_Connection();

            string passwordQuery = "SELECT password FROM login WHERE email = '" + email +"'";
            SqlCommand cmd_Password = new SqlCommand(passwordQuery, cn_connection);
            string adminQuery = "SELECT admin FROM login WHERE email = '" + email +"'";
            SqlCommand cmd_Admin = new SqlCommand(adminQuery, cn_connection);
            string passCheck = (string)cmd_Password.ExecuteScalar();
            bool adminCheck;
            if (cmd_Admin.ExecuteScalar() == null)
            {
                //Verifies the admin column is not null
                return 0;
            }
            else
            {
                adminCheck = (bool)cmd_Admin.ExecuteScalar();
            }
            

            if (passCheck == password)
            {
                if (adminCheck)
                {
                    //admin page case number
                    return 1;
                }
                //student page case number
                return 2;
            }
            else
            {
                //error message case number
                return 0;
            }

        }

        public static void Close_DB_Connection()

        {
            //--------< Close_DB_Connection() >--------

            string cn_String = Properties.Settings.Default.connection_String;

            SqlConnection cn_connection = new SqlConnection(cn_String);
            if (cn_connection.State != ConnectionState.Closed) cn_connection.Close();
        }
    }
}
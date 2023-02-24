/*
* Module 5: Assessment
* Casinsinan, Cj C. 
* BSCS 3-1N
*/

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Employee_Records
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Show/Refresh Database
        void GetEmpList()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-48HNV6S\\SQLEXPRESS01;Initial Catalog=Employee-Record;Integrated Security=True");
            SqlCommand c = new SqlCommand("exec Employee_List", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = c;
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataGrid1.ItemsSource = (IEnumerable)dt.DefaultView;
        }

        // Add Employee Info
        private void add_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-48HNV6S\\SQLEXPRESS01;Initial Catalog=Employee-Record;Integrated Security=True");
            try
            {
                string emp_name = TB_Name.Text, phone = TB_Phone.Text;
                int emp_age = int.Parse(TB_Age.Text);
                double emp_salary = double.Parse(TB_Salary.Text);
                DateTime join_date = DateTime.Parse(TB_JoinDate.Text);
                string FDateTime = join_date.ToString("yyyy-MM-dd HH:mm:ss");

                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand("exec Insert_Info '" + emp_name + "','" + emp_age + "','" + emp_salary + "','" + FDateTime + "','" + phone + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                MessageBox.Show("Your data has been succesfully saved!", "Success");
                con.Close();
                GetEmpList();
            }
            catch
            {
                MessageBox.Show("Invalid! Please try to input again", "Error");
            }
        }

        // Update Employee Info
        private void upd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-48HNV6S\\SQLEXPRESS01;Initial Catalog=Employee-Record;Integrated Security=True");
                string emp_name = TB_Name.Text, phone = TB_Phone.Text;
                int emp_age = int.Parse(TB_Age.Text), id = int.Parse(TB_ID.Text);
                double emp_salary = double.Parse(TB_Salary.Text);
                DateTime join_date = DateTime.Parse(TB_JoinDate.Text);
                string FDateTime = join_date.ToString("yyyy-MM-dd HH:mm:ss");

                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand("exec Update_Info '" + id + "','" + emp_name + "','" + emp_age + "','" + emp_salary + "','" + FDateTime + "','" + phone + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                MessageBox.Show("Your data has been succesfully saved!", "Success");
                con.Close();
                GetEmpList();
            }
            catch
            {
                MessageBox.Show("Invalid! Please try to input again", "Error");
            }
        }

        // Delete Employee Info
        private void delete_click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-48HNV6S\\SQLEXPRESS01;Initial Catalog=Employee-Record;Integrated Security=True");
                int id = int.Parse(TB_ID.Text);

                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand("exec Delete_Info'" + id + "'", con);
                con.Open();
                dr = cmd.ExecuteReader();
                MessageBox.Show("Your data has been deleted successfully!", "Success");
                con.Close();
                GetEmpList();
            }
            catch
            {
                MessageBox.Show("Invalid! Please try to input again", "Error");
            }
        }

        // Upon opening form
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetEmpList();
        }

        private void DataGrid1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}

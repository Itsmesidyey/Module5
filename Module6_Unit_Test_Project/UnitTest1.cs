﻿/*
 * Module 6: Assessment
 * 
 *
 */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.SqlClient;

namespace Module6_Unit_Test
{
    [TestClass]
    public class UnitTest1
    {
        private SqlConnection connection;
        [TestInitialize]
        public void TestSetup()
        {
            // Create a test database and populate it with sample data
            string connectionString = "Data Source=DESKTOP-48HNV6S\\SQLEXPRESS01;Initial Catalog=Employee-Record;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        [TestMethod]
        public void Test1AddEmployee()
        {
            SqlCommand command = new SqlCommand("exec Insert_Info 'John Doe', 25, 50000.00, '2022 - 02 - 25', '1234567890'", connection);
            int result = command.ExecuteNonQuery();
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void Test2UpdateEmployee()
        {
            SqlCommand command = new SqlCommand("exec Update_Info 3, 'Jane Smith', 30, 50000.00, '2022 - 02 - 25', '1234567890'", connection);
            int result = command.ExecuteNonQuery();
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void Test3LoadEmployee()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("exec Employee_List", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            Assert.AreEqual(1, table.Rows[0]["id"]);
        }
        [TestMethod]
        public void Test4DeleteEmployee()
        {
            SqlCommand command = new SqlCommand("exec Delete_Info 3",connection);
            int result = command.ExecuteNonQuery();
            Assert.AreEqual(1, result);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            connection.Close();
        }
    }
}

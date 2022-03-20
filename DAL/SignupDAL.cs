using CoffeeShopManagement.DAO;
using CoffeeShopManagement.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagement.DAL
{
    internal class SignupDAL
    {
        SqlConnection connection;
        SqlCommand command;
        //string username, string fullname, string dob, bool gender, int phone, string address, string pass
        public int SignUp(Account account)
        {
            int result = 0;
            connection = new SqlConnection(DBContext.GetConnectionString());
            string sql = "insert into Account(userName,fullName,dateOfBirth,gender,phoneNumber,address,passWord) " +
                "values(@uName,@fName,@dob,@gender,@phone,@address,@pass)";
            command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@uName", account.userName);
            command.Parameters.AddWithValue("@fName", account.fullName);
            command.Parameters.AddWithValue("@dob", account.dateOfBirth);
            command.Parameters.AddWithValue("@gender", account.gender);
            command.Parameters.AddWithValue("@phone", account.phone);
            command.Parameters.AddWithValue("@address", account.address);
            command.Parameters.AddWithValue("@pass", account.password);
            try
            {
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }
}

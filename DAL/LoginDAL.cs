using CoffeeShopManagement.DAO;
using CoffeeShopManagement.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace CoffeeShopManagement.DAL
{
    internal class LoginDAL
    {
        SqlConnection connection;
        SqlCommand command;

        public Account Login(string username, string password)
        {
            string sql = "select userName, passWord, type from Account where userName=@uName and passWord=@pass";
            connection = new SqlConnection(DBContext.GetConnectionString());
            command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@uName", username);
            command.Parameters.AddWithValue("@pass", password);
            Account a = new Account();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        a.userName = username;
                        a.password = password;
                        a.type = reader.GetInt32("type");
                        return a;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return null;
        }
    }
}

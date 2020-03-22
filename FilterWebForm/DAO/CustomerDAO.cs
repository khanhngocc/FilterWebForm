using FilterWebForm.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FilterWebForm.DAO
{
    public class CustomerDAO
    {
        DBContext dBContext = new DBContext();

        public List<Customer> GetAllCustomers()
        {
            List<Customer> lists = new List<Customer>();
            SqlConnection cnn = dBContext.GetConnection();
            cnn.Open();
            String query = "Select * from Customers";
            SqlCommand command = new SqlCommand(query, cnn);
            SqlDataReader reader = command.ExecuteReader();
            Customer all = new Customer();
            all.Id = "0";
            all.Name = "All";
            lists.Add(all);
            while (reader.Read())
            {
                String id = reader.GetString(0);
                String name = reader.GetString(1);
                Customer temp = new Customer();
                temp.Id = id;
                temp.Name = name;
                lists.Add(temp);
            }

            cnn.Close();

            return lists;
        }


    }
}

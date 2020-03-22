using FilterWebForm.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FilterWebForm.DAO
{
    public class OrderDAO
    {
        DBContext dBContext = new DBContext();

        public int GetRowCount(OrderQuery order)
        {
            int num = 0;
            SqlConnection cnn = dBContext.GetConnection();
            cnn.Open();
            String query = "Select Count(*) from Employees,Customers,Orders"
                      + " where"
                      + " Employees.EmployeeID = Orders.EmployeeID"
                      + " and"
                      + " Customers.CustomerID = Orders.CustomerID"
            ;

            if(order.EmployeeID != 0)
                query += " and Employees.EmployeeID = @val3";

            if (!order.CustomerID.Equals("0"))
                query += " and Customers.CustomerID = @val4";

          

            SqlCommand command = new SqlCommand(query, cnn);

            if (order.EmployeeID != 0)
                command.Parameters.AddWithValue("@val3", order.EmployeeID);

            if (!order.CustomerID.Equals("0"))
                command.Parameters.AddWithValue("@val4", order.CustomerID);

           
            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                num = reader.GetInt32(0);
            }
            return num;
        }


        public List<Order> GetAllData(OrderQuery order,int pageIndex,int pageSize)
        {
            int numberOfRecord = (pageIndex - 1) * pageSize;
            List<Order> lists = new List<Order>();
            SqlConnection cnn = dBContext.GetConnection();
            cnn.Open();
            String query = "Select OrderID,Employees.FirstName+' '+Employees.LastName as 'Employee',Customers.CompanyName as 'Customer',Orders.OrderDate,Orders.RequiredDate,Orders.ShippedDate,Orders.ShipVia from Employees,Customers,Orders"
                      + " where"
                      + " Employees.EmployeeID = Orders.EmployeeID"
                      + " and"
                      + " Customers.CustomerID = Orders.CustomerID"
                      + " and"
                      + " Orders.OrderDate BETWEEN @val1 AND @val2"
                      ;

            if (order.EmployeeID != 0)
                query += " and Employees.EmployeeID = @val3";

            if(!order.CustomerID.Equals("0"))
                query += " and Customers.CustomerID = @val4";

          

            query += " Order by OrderID asc";
            query += " OFFSET @val5 ROWS";
            query += " FETCH NEXT @val6 ROWS ONLY";

            SqlCommand command = new SqlCommand(query, cnn);
            command.Parameters.AddWithValue("@val1", order.DateFrom);
            command.Parameters.AddWithValue("@val2", order.DateTo);
            command.Parameters.AddWithValue("@val5",numberOfRecord);
            command.Parameters.AddWithValue("@val6", pageSize);


            if (order.EmployeeID != 0)
                command.Parameters.AddWithValue("@val3", order.EmployeeID);

            if (!order.CustomerID.Equals("0"))
                command.Parameters.AddWithValue("@val4", order.CustomerID);

          

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Order temp = new Order();
                if (!reader.IsDBNull(0))
                {
                    temp.OrderID = reader.GetInt32(0);
                }
                if (!reader.IsDBNull(1))
                {
                    temp.Employee = reader.GetString(1);
                }
                if (!reader.IsDBNull(2))
                {
                    temp.Customer = reader.GetString(2);
                }
                if (!reader.IsDBNull(3))
                {
                    temp.OrderDate = reader.GetDateTime(3).Date;
                }
                if (!reader.IsDBNull(4))
                {
                    temp.RequiredDate = reader.GetDateTime(4).Date;
                }
                if (!reader.IsDBNull(5))
                {
                    temp.ShippedDate = reader.GetDateTime(5).Date;
                }
                if (!reader.IsDBNull(6))
                {
                    temp.ShipVia = reader.GetInt32(6);
                }

                lists.Add(temp);
            }

            cnn.Close();

            return lists;
        }

        
    }
}

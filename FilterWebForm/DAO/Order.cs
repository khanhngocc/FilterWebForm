using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilterWebForm.DAO
{
    public class Order
    {
        private int orderID;
        private String employee;
        private String customer;
        private DateTime orderDate;
        private DateTime requiredDate;
        private DateTime shippedDate;
        private int shipVia;



        public int OrderID { get => orderID; set => orderID = value; }
        public string Employee { get => employee; set => employee = value; }
        public string Customer { get => customer; set => customer = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }

        public DateTime RequiredDate { get => requiredDate; set => requiredDate = value; }
        public DateTime ShippedDate { get => shippedDate; set => shippedDate = value; }

        public int ShipVia { get => shipVia; set => shipVia = value; }
    }
}
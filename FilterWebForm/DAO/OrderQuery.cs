using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilterWebForm.DAO
{
    public class OrderQuery
    {
        private int employeeID;
        private String customerID;
        private DateTime dateFrom;
        private DateTime dateTo;

        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public DateTime DateFrom { get => dateFrom; set => dateFrom = value; }
        public DateTime DateTo { get => dateTo; set => dateTo = value; }
    }
}
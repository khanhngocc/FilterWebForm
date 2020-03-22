using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilterWebForm.DAO
{
    public class Employee
    {
        private int id;
        private String first_name;
        private String last_name;

        private String display_name;


        public string First_name { get => first_name; set => first_name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public int Id { get => id; set => id = value; }
        public string Display_name { get => First_name+" "+Last_name; set => display_name = value; }
    }
}
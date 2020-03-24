using FilterWebForm.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FilterWebForm
{
    public partial class View : System.Web.UI.Page
    {
        static int pageCount;
        static int pageIndex = 1;
        int pageSize = 20;
        
        OrderDAO orderDAO = new OrderDAO();
        EmployeeDAO employeeDAO = new EmployeeDAO();
        CustomerDAO customerDAO = new CustomerDAO();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                ddlEmployees.DataSource = employeeDAO.GetAllEmployees();
                ddlEmployees.SelectedIndex = 0;
                ddlEmployees.DataBind();

                ddlCustomer.DataSource = customerDAO.GetAllCustomers();
                ddlCustomer.SelectedIndex = 0;
                ddlCustomer.DataBind();

                caFrom.SelectedDate = new DateTime(1996, 1, 1);
                caFrom.TodaysDate = new DateTime(1996, 1, 1);
                caTo.SelectedDate = DateTime.Today;
                caTo.TodaysDate = DateTime.Today;

                int employeeID = Convert.ToInt32(ddlEmployees.SelectedValue);
                string customerID = ddlCustomer.SelectedValue.ToString();
                OrderQuery orderQuery = new OrderQuery();
                orderQuery.EmployeeID = employeeID;
                orderQuery.CustomerID = customerID;
                orderQuery.DateFrom = caFrom.SelectedDate;
                orderQuery.DateTo = caTo.SelectedDate;
                LoadData();
                LoadPageNumber();
              

            }

        }

        public void LoadPageNumber()
        {
            List<int> list = new List<int>();

            for (int i = 1; i <= pageCount; i++)
                list.Add(i);

            pageNumberList.DataSource = list;
            pageNumberList.DataBind();
        }

        void LoadData()
        {
            int employeeID = Convert.ToInt32(ddlEmployees.SelectedValue);
            string customerID = ddlCustomer.SelectedValue.ToString();
            OrderQuery orderQuery = new OrderQuery();
            orderQuery.EmployeeID = employeeID;
            orderQuery.CustomerID = customerID;
            orderQuery.DateFrom = caFrom.SelectedDate;
            orderQuery.DateTo = caTo.SelectedDate;
            lOrder.DataSource = orderDAO.GetAllData(orderQuery, pageIndex, pageSize);
            lOrder.DataBind();
            int rowCount = orderDAO.GetRowCount(orderQuery);

            if (rowCount % pageSize == 0)
            {
                pageCount = rowCount / pageSize;
            }
            else
            {
                pageCount = rowCount / pageSize + 1;
            }

            if (pageCount == 0 || pageCount == 1)
            {
                if (pageCount == 0)
                    pageIndex = 0;
                else
                    pageIndex = 1;
                btnFirst.Enabled = false;
                btnPre.Enabled = false;
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPre.Enabled = true;
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
                
            pageText.Text = String.Format("Page {0}/{1}", pageIndex, pageCount);

            LoadPageNumber();
        }
        protected void ddlEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageIndex = 1;
            LoadData();
        }

        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageIndex = 1;
            LoadData();
        }

        protected void btnPre_Click(object sender, EventArgs e)
        {
            if(pageIndex == 1)
            {
                pageIndex = pageCount;
            }
            else
            {
                pageIndex--;
            }
            pageNumberList.SelectedValue = pageIndex + "";
            LoadData();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (pageIndex == pageCount)
            {
                pageIndex = 1;
            }
            else
            {
                pageIndex++;
            }
            pageNumberList.SelectedValue = pageIndex + "";
            LoadData();
        }

        protected void btnFirst_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            pageNumberList.SelectedValue = pageIndex + "";
            LoadData();
        }

        protected void btnLast_Click(object sender, EventArgs e)
        {
            pageIndex = pageCount;
            pageNumberList.SelectedValue = pageIndex + "";
            LoadData();
        }

        protected void pageNumberList_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageIndex = Int32.Parse(pageNumberList.SelectedValue);
            pageNumberList.SelectedValue = pageIndex+"";
            LoadData();
            
        }

        protected void caFrom_SelectionChanged(object sender, EventArgs e)
        {
            pageIndex = 1;
            LoadData();
        }

        protected void caTo_SelectionChanged(object sender, EventArgs e)
        {
            pageIndex = 1;
            LoadData();
        }

       

       


    }
}
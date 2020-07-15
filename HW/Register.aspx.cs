using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Web.Security;
namespace HW
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }



        private bool UserExists(String UserName)
        {
            return false;
        }

        private void CreateUser()
        {
            if (UserName.Text == "" || Password.Text == "" || BillingInfo.Text == "")
            {
                StatusLabel.Text = "Необходимо заполнить все поля";
                return;
            }
            if (DB.UserExists(UserName.Text))
                StatusLabel.Text = "Пользователь с таким именем уже существует";
            else
            {
                if (DB.CreateUser(UserName.Text, Password.Text, Convert.ToInt32(DropDownN.SelectedValue),BillingInfo.Text))
                    Response.Redirect("Login.aspx");
                else
                    StatusLabel.Text = "Ошибка";
            }      
        }
        protected void RegButton_Click(object sender, EventArgs e)
        {
            CreateUser();
        }
    }
}
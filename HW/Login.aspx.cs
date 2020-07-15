using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.Security;

namespace HW
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void LogInButton_Click(object sender, EventArgs e)
        {
            Validate();

        }

        private void Validate()
        {
            if (!DB.UserExists(UserName.Text))
                StatusLabel.Text = "Неверное имя пользователя";
            else
            {
                if (DB.IsValid(UserName.Text, Password.Text))
                    FormsAuthentication.RedirectFromLoginPage(UserName.Text, false);
                else
                    StatusLabel.Text = "Пароль неверен";
            }   
        }
    }
}
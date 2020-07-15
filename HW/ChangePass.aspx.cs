using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace HW
{
    public partial class ChangePass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        private void ChangePassword()
        {
            if (OldPass.Text == "" || NewPass.Text == "")
            {
                StatusLabel.Text = "Необходимо заполнить все поля";
                return;
            }
            string username = Page.User.Identity.Name;
            if (!DB.IsValid(username, OldPass.Text))
            {
                StatusLabel.Text = "Пароль неверен";
                return;
            }
            string Info = DB.GetInfo(username, OldPass.Text);

            DB.ChangePass(username, NewPass.Text);

            if (Info != "")
                DB.ChangeInfo(username, NewPass.Text, Info);

            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }


        protected void ChangeButton_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }
    }
}
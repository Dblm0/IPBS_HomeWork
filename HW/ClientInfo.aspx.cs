using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
namespace HW
{
    public partial class ClientInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void AccesButton_Click(object sender, EventArgs e)
        {
            Acces();
        }
        private void Acces()
        {
            if (Password.Text == "")
                StatusLabel.Text = "Необходимо заполнить поле";
            else
            {
                string username = Page.User.Identity.Name;
                if (!DB.IsValid(username, Password.Text))
                {
                    StatusLabel.Text = "Неверный пароль";
                }
                else
                {
                    TextBox.Visible = true;
                    SaveButton.Visible = true;
                    AccesButton.Visible = false;

                    string CryptedInfo = DB.GetInfo(username, Password.Text);

                    TextBox.Text = CryptedInfo;
                }
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (Password.Text == "")
                StatusLabel.Text = "Необходимо заполнить поле";
            else
            {
                string username = Page.User.Identity.Name;
                if (!DB.IsValid(username, Password.Text))
                {
                    StatusLabel.Text = "Неверный пароль";
                }
                else
                    DB.ChangeInfo(username, Password.Text, TextBox.Text);
            }
        }
    }
}
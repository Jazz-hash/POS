using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aariaz_Workshop
{
    public partial class Login : Form
    {
        aaraiz_dbEntities data = new aaraiz_dbEntities();
        public static string username = "admin";
        public static string name = "Jazzel";
        public Login()
        {
            InitializeComponent();
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            user login_user_username = data.users.Where(x => x.Username == bunifuMaterialTextbox1.Text && x.Password == bunifuMaterialTextbox2.Text && x.Status == true).FirstOrDefault();
            user login_user_email = data.users.Where(x => x.Email == bunifuMaterialTextbox1.Text && x.Password == bunifuMaterialTextbox2.Text && x.Status == true).FirstOrDefault();
            if(login_user_email != null)
            {
                username = login_user_email.Username;
                name = login_user_email.Name;
                MetroFramework.MetroMessageBox.Show(this, "Welcome User "+login_user_email.Name+" !!", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                Dashboard db = new Dashboard();
                this.Hide();
                db.Show();
            }
            else if (login_user_username != null)
            {
                username = login_user_username.Username;
                name = login_user_username.Name;

                MetroFramework.MetroMessageBox.Show(this, "Welcome User "+login_user_username.Name+" !!", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                Dashboard db = new Dashboard();
                this.Hide();
                db.Show();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Couldn't find your account !!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                bunifuMaterialTextbox2.Text = "";
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Aariaz_Workshop
{
    public partial class Admin_authentication : Form
    {
        public static bool allow_user;
        public static string username_text;
        public static string name_text;

        aaraiz_dbEntities data = new aaraiz_dbEntities();
        public Admin_authentication()
        {
            InitializeComponent();
            if (Login.username == "admin")
            {
                username_label.Text = Login.username;
                name_label.Text = Login.name;

            }
            else
            {
                this.Hide();
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        string email;
       

        private void Yes_Click(object sender, EventArgs e)
        {
            user userData = data.users.Where(x => x.Password == pass_confirm_txt.Text).FirstOrDefault();
            if(userData != null)
            {
                allow_user = true;
                this.Hide();
            }
        }

        private void No_Click(object sender, EventArgs e)
        {
            this.Hide();
            allow_user = false;
        }
    }
}

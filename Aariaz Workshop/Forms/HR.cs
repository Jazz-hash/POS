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
    public partial class HR : Form
    {
        public HR()
        {
            InitializeComponent();
        }

        private void Add_new_employee_btn_Click(object sender, EventArgs e)
        {
            mini_HR_screen.SelectedTab = new_HR_tab;
        }

        private void Update_employee_btn_Click(object sender, EventArgs e)
        {
            mini_HR_screen.SelectedTab = update_HR_tab;

        }

        private void BunifuImageButton14_Click(object sender, EventArgs e)
        {
            mini_HR_screen.SelectedTab = main_HR_tab;

        }
    }
}

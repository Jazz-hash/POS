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
    public partial class Shops : Form
    {
        public Shops()
        {
            InitializeComponent();
        }

        private void Add_new_shop_btn_Click(object sender, EventArgs e)
        {
            mini_shops_screen.SelectedTab = new_shops_tab;
        }

        private void Add_warehouse_btn_Click(object sender, EventArgs e)
        {
            mini_shops_screen.SelectedTab = new_warehouse_tab;

        }

        private void New_shop_user_btn_Click(object sender, EventArgs e)
        {
            mini_shops_screen.SelectedTab = shop_users_tab;

        }

        private void BunifuImageButton21_Click(object sender, EventArgs e)
        {
            mini_shops_screen.SelectedTab = main_shops_tab;

        }

    }
}

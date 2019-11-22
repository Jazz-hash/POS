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
    public partial class Customers_Suppliers : Form
    {
        public Customers_Suppliers()
        {
            InitializeComponent();
        }

        private void Add_new_customer_supplier_btn_Click(object sender, EventArgs e)
        {
            mini_customer_supplier_screen.SelectedTab = new_customer_supplier_tab;
        }

        private void Update_customer_supplier_btn_Click(object sender, EventArgs e)
        {
            mini_customer_supplier_screen.SelectedTab = update_customer_supplier_tab;

        }

        private void BunifuImageButton10_Click(object sender, EventArgs e)
        {
            mini_customer_supplier_screen.SelectedTab = main_customer_supplier_tab;

        }

        private void Detailed_view_btn_Click(object sender, EventArgs e)
        {
            mini_customer_supplier_screen.SelectedTab = detailed_view_customer_tab;

        }
    }
}

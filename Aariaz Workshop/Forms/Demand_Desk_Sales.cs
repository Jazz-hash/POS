using Aariaz_Workshop.Forms;
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
    public partial class Demand_Desk_Sales : Form
    {
        GenerateReceipt ReceiptForm;
        public Demand_Desk_Sales()
        {
            InitializeComponent();
        }

        private void Transfer_stock_btn_Click(object sender, EventArgs e)
        {
            mini_demand_sales_screen.SelectedTab = transfer_stock_tab;
        }

        private void MetroTile2_Click(object sender, EventArgs e)
        {
            mini_demand_sales_screen.SelectedTab = transfer_stock_tab;

        }

        private void BunifuImageButton26_Click(object sender, EventArgs e)
        {
            mini_demand_sales_screen.SelectedTab = main;

        }

        private void BunifuImageButton6_Click(object sender, EventArgs e)
        {

            mini_demand_sales_screen.SelectedTab = transfer_stock_tab;
        }

        private void Transfering_next_step_btn_Click(object sender, EventArgs e)
        {
            mini_demand_sales_screen.SelectedTab = products_transfer_tab;

        }

        private void Generate_receipt_btn_Click(object sender, EventArgs e)
        {
            Program.Form.Receipt_nav_btn_Click();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aariaz_Workshop.Forms
{
    public partial class GenerateReceipt : Form
    {
        public GenerateReceipt()
        {
            InitializeComponent();
        }

        private void MetroGrid8_DoubleClick(object sender, EventArgs e)
        {
            mini_receipts_screen.SelectedTab = new_receipt_tab;
        }

        private void Next_to_check_receipt_btn_Click(object sender, EventArgs e)
        {
            mini_receipts_screen.SelectedTab = next_step_receipt_tab;

        }

        private void Move_to_next_step_btn_Click(object sender, EventArgs e)
        {
            mini_receipts_screen.SelectedTab = opening_receipt_tab;

        }

        private void MetroGrid9_DoubleClick(object sender, EventArgs e)
        {
            mini_receipts_screen.SelectedTab = product_details_tab;

        }

        private void MetroGrid10_DoubleClick(object sender, EventArgs e)
        {
            mini_receipts_screen.SelectedTab = confirm_products_tab;

        }

        private void BunifuImageButton34_Click(object sender, EventArgs e)
        {
            mini_receipts_screen.SelectedTab = product_details_tab;

        }

        private void BunifuImageButton33_Click(object sender, EventArgs e)
        {
            mini_receipts_screen.SelectedTab = opening_receipt_tab;

        }

        private void BunifuImageButton32_Click(object sender, EventArgs e)
        {
            mini_receipts_screen.SelectedTab = next_step_receipt_tab;

        }

        private void BunifuImageButton30_Click(object sender, EventArgs e)
        {
            mini_receipts_screen.SelectedTab = new_receipt_tab;

        }

        private void BunifuImageButton31_Click(object sender, EventArgs e)
        {
            mini_receipts_screen.SelectedTab = main_receipts_tab;

        }
    }
}

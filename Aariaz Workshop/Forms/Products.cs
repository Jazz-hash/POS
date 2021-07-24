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
    public partial class Products : Form
    {
        aaraiz_dbEntities data = new aaraiz_dbEntities();

        public Products()
        {
            InitializeComponent();
            ComboBoxLoad();
        }

        private void ComboBoxLoad()
        {
            var sales = from item in data.salespercentages
                        where item.Status == true
                        select new
                        {
                            Id = item.Id,
                            Sales = item.Percentage,
                        };
            comboBox5.DataSource = sales.ToList();
            comboBox5.DisplayMember = "Sales";
            comboBox5.ValueMember = "Id";
            var product = from item in data.products
                          where item.Status == true
                          select new
                          {
                              Id = item.Id,
                              ProductCode = item.ProductCode,
                              Quantity = item.Quantity,
                              CostPrice = item.CostPrice,
                              RetailPrice = item.RetailPrice,
                          };
            metroGrid2.DataSource = product.ToList();

        }

        private void Add_new_product_btn_Click(object sender, EventArgs e)
        {
            mini_products_screen.SelectedTab = new_products_tab;
        }

        private void Update_product_btn_Click(object sender, EventArgs e)
        {
            mini_products_screen.SelectedTab = update_products_tab;

        }

        private void Back_to_main_products_tab_Click(object sender, EventArgs e)
        {
            mini_products_screen.SelectedTab = main_products_tab;

        }

        private void BunifuImageButton4_Click(object sender, EventArgs e)
        {

        }
    }
}

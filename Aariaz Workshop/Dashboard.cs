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
using MySql.Data.MySqlClient;
using Aariaz_Workshop.Model;
using MetroFramework;

namespace Aariaz_Workshop
{
    public partial class Dashboard : Form
    {
        aaraiz_dbEntities data = new aaraiz_dbEntities();
        Login Loginform;
        Accounts AccountsForm;
        Barcodes BarcodesForm;
        Buying BuyingForm;
        Customers_Suppliers Customers_SuppliersForm;
        Demand_Desk_Sales Demand_Desk_SalesForm;
        Home HomeForm;
        HR HRForm;
        Products ProductsForm;
        SalesForm SaleForm;
        Shops ShopsForm;
        Stock StockForm;
        Tools ToolsForm;
        Users UserForm;
        GenerateReceipt ReceiptForm;

        public Dashboard()
        {
            InitializeComponent();
            Theme_manager();
        }

        
        private void Theme_manager()
        {
            mini_logo.Visible = true;
            logo.Visible = false;
            navbar.Width = 50;
            FormSizing();
            //DefaultForm();
        }

        private void FormSizing()
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
        }

        private void DefaultForm()
        {
            if (HomeForm == null)
            {
                HomeForm = new Home();
                HomeForm.MdiParent = this;
                forms_container.Controls.Add(HomeForm);
                HomeForm.FormClosed += new FormClosedEventHandler(form_closing);
                HomeForm.Dock = DockStyle.Fill;
                HomeForm.Show();
                HomeForm.BringToFront();
            }
            else
            {
                HomeForm.Activate();
                HomeForm.BringToFront();
            }
        }

        private void nav_shortner()
        {
            logo.Visible = false;
            navbar.Visible = false;
            navbar.Width = 50;
            mini_navbar_animator.ShowSync(navbar);
            mini_logo_animator.ShowSync(mini_logo);
        }

        private void Nav_btn_Click(object sender, EventArgs e)
        {
            if (navbar.Width == 50)
            {
                mini_logo.Visible = false;
                navbar.Visible = false;
                navbar.Width = 280;
                navbar_animator.ShowSync(navbar);
                logo_animator.ShowSync(logo);

            }
            else
            {
                logo.Visible = false;
                navbar.Visible = false;
                navbar.Width = 50;
                mini_navbar_animator.ShowSync(navbar);
                mini_logo_animator.ShowSync(mini_logo);

            }

        }

        private void Nav_opener_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 226; i++)
            {
                if (navbar.Width > 225)
                {
                    nav_opener.Stop();
                    break;
                }
                navbar.Width += 60;
            }
        }

        private void Nav_closer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 226; i++)
            {
                if (navbar.Width == 0)
                {
                    nav_closer.Stop();
                    break;
                }
                navbar.Width -= 60;
            }
        }

        private void form_closing(object sender, FormClosedEventArgs e)
        {
            HomeForm = null;
            UserForm = null;
            AccountsForm = null;
            BarcodesForm = null;
            BuyingForm = null;
            Customers_SuppliersForm = null;
            Demand_Desk_SalesForm = null;
            HomeForm = null;
            HRForm = null;
            ProductsForm = null;
            SaleForm = null;
            ShopsForm = null;
            StockForm = null;
            ToolsForm = null;
            UserForm = null;
            ReceiptForm = null;
        }

        private void Dashboard_btn_Click(object sender, EventArgs e)
        {
            if (HomeForm == null)
            {
                HomeForm = new Home();
                HomeForm.MdiParent = this;
                forms_container.Controls.Add(HomeForm);
                HomeForm.FormClosed += new FormClosedEventHandler(form_closing);
                //HomeForm.Dock = DockStyle.Fill;
                HomeForm.Width = forms_container.Width;
                HomeForm.Show();
                HomeForm.BringToFront();
            }
            else
            {
                HomeForm.Activate();
                HomeForm.BringToFront();
            }
        }

        private void Users_btn_Click(object sender, EventArgs e)
        {
            if (UserForm == null)
            {
                UserForm = new Users();
                UserForm.MdiParent = this;
                forms_container.Controls.Add(UserForm);
                UserForm.FormClosed += new FormClosedEventHandler(form_closing);
                //UserForm.Dock = DockStyle.Fill;
                UserForm.Show();
                UserForm.BringToFront();
            }
            else
            {
                UserForm.Activate();
                UserForm.BringToFront();

            }
        }

        DialogResult dr;
        private void Close_btn_Click(object sender, EventArgs e)
        {
            Loginform = new Login();
            dr = MetroMessageBox.Show(this, "Are you sure you want to exit ? This will logout you from the application !!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dr == DialogResult.Yes)
            {
                this.Hide();
                Loginform.Show();
            }
            else
            {
                return;
            }
            
        }

        private void Minimize_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Products_btn_Click(object sender, EventArgs e)
        {
            if (ProductsForm == null)
            {
                ProductsForm = new Products();
                ProductsForm.MdiParent = this;
                forms_container.Controls.Add(ProductsForm);
                ProductsForm.FormClosed += new FormClosedEventHandler(form_closing);
                //ProductsForm.Dock = DockStyle.Fill;
                ProductsForm.Show();
                ProductsForm.BringToFront();
            }
            else
            {
                ProductsForm.Activate();
                ProductsForm.BringToFront();

            }

        }

        private void Sales_btn_Click(object sender, EventArgs e)
        {
            if (SaleForm == null)
            {

                SaleForm = new SalesForm();
                SaleForm.MdiParent = this;
                forms_container.Controls.Add(SaleForm);
                SaleForm.FormClosed += new FormClosedEventHandler(form_closing);
                //SalesForm.Dock = DockStyle.Fill;
                SaleForm.Show();
                SaleForm.BringToFront();
            }
            else
            {
                SaleForm.Activate();
                SaleForm.BringToFront();

            }
        }

        private void Customers_supplier_btn_Click(object sender, EventArgs e)
        {
            if (Customers_SuppliersForm == null)
            {
                Customers_SuppliersForm = new Customers_Suppliers();
                Customers_SuppliersForm.MdiParent = this;
                forms_container.Controls.Add(Customers_SuppliersForm);
                Customers_SuppliersForm.FormClosed += new FormClosedEventHandler(form_closing);
                //Customers_SuppliersForm.Dock = DockStyle.Fill;
                Customers_SuppliersForm.Show();
                Customers_SuppliersForm.BringToFront();
            }
            else
            {
                Customers_SuppliersForm.Activate();
                Customers_SuppliersForm.BringToFront();

            }
        }

        private void HR_btn_Click(object sender, EventArgs e)
        {
            if (HRForm == null)
            {
                HRForm = new HR();
                HRForm.MdiParent = this;
                forms_container.Controls.Add(HRForm);
                HRForm.FormClosed += new FormClosedEventHandler(form_closing);
                //HRForm.Dock = DockStyle.Fill;
                HRForm.Show();
                HRForm.BringToFront();
            }
            else
            {
                HRForm.Activate();
                HRForm.BringToFront();

            }
        }

        private void Buying_btn_Click(object sender, EventArgs e)
        {
            if (BuyingForm == null)
            {
                BuyingForm = new Buying();
                BuyingForm.MdiParent = this;
                forms_container.Controls.Add(BuyingForm);
                BuyingForm.FormClosed += new FormClosedEventHandler(form_closing);
                //BuyingForm.Dock = DockStyle.Fill;
                BuyingForm.Show();
                BuyingForm.BringToFront();
            }
            else
            {
                BuyingForm.Activate();
                BuyingForm.BringToFront();

            }
        }

        private void Shops_btn_Click(object sender, EventArgs e)
        {
            if (ShopsForm == null)
            {
                ShopsForm = new Shops();
                ShopsForm.MdiParent = this;
                forms_container.Controls.Add(ShopsForm);
                ShopsForm.FormClosed += new FormClosedEventHandler(form_closing);
                //ShopsForm.Dock = DockStyle.Fill;
                ShopsForm.Show();
                ShopsForm.BringToFront();
            }
            else
            {
                ShopsForm.Activate();
                ShopsForm.BringToFront();

            }
        }

        private void Demand_desk_btn_Click(object sender, EventArgs e)
        {
            if (Demand_Desk_SalesForm == null)
            {
                Demand_Desk_SalesForm = new Demand_Desk_Sales();
                Demand_Desk_SalesForm.MdiParent = this;
                forms_container.Controls.Add(Demand_Desk_SalesForm);
                Demand_Desk_SalesForm.FormClosed += new FormClosedEventHandler(form_closing);
                //Demand_Desk_SalesForm.Dock = DockStyle.Fill;
                Demand_Desk_SalesForm.Show();
                Demand_Desk_SalesForm.BringToFront();
            }
            else
            {
                Demand_Desk_SalesForm.Activate();
                Demand_Desk_SalesForm.BringToFront();

            }
        }

        private void Accounts_btn_Click(object sender, EventArgs e)
        {
            if (AccountsForm == null)
            {
                AccountsForm = new Accounts();
                AccountsForm.MdiParent = this;
                forms_container.Controls.Add(AccountsForm);
                AccountsForm.FormClosed += new FormClosedEventHandler(form_closing);
                //AccountsForm.Dock = DockStyle.Fill;
                AccountsForm.Show();
                AccountsForm.BringToFront();
            }
            else
            {
                AccountsForm.Activate();
                AccountsForm.BringToFront();

            }
        }

        private void Barcodes_btn_Click(object sender, EventArgs e)
        {
            if (BarcodesForm == null)
            {
                BarcodesForm = new Barcodes();
                BarcodesForm.MdiParent = this;
                forms_container.Controls.Add(BarcodesForm);
                BarcodesForm.FormClosed += new FormClosedEventHandler(form_closing);
                //BarcodesForm.Dock = DockStyle.Fill;
                BarcodesForm.Show();
                BarcodesForm.BringToFront();
            }
            else
            {
                BarcodesForm.Activate();
                BarcodesForm.BringToFront();

            }
        }

        private void Tools_btn_Click(object sender, EventArgs e)
        {
            if (ToolsForm == null)
            {
                ToolsForm = new Tools();
                ToolsForm.MdiParent = this;
                forms_container.Controls.Add(ToolsForm);
                ToolsForm.FormClosed += new FormClosedEventHandler(form_closing);
                //ToolsForm.Dock = DockStyle.Fill;
                ToolsForm.Show();
                ToolsForm.BringToFront();
            }
            else
            {
                ToolsForm.Activate();
                ToolsForm.BringToFront();

            }
        }

        private void Stock_nav_btn_Click(object sender, EventArgs e)
        {
            if (StockForm == null)
            {
                StockForm = new Stock();
                StockForm.MdiParent = this;
                forms_container.Controls.Add(StockForm);
                StockForm.FormClosed += new FormClosedEventHandler(form_closing);
                //StockForm.Dock = DockStyle.Fill;
                StockForm.Show();
                StockForm.BringToFront();
            }
            else
            {
                StockForm.Activate();
                StockForm.BringToFront();

            }
        }

        public void Receipt_nav_btn_Click()
        {
            if (ReceiptForm == null)
            {
                ReceiptForm = new GenerateReceipt();
                ReceiptForm.MdiParent = this;
                forms_container.Controls.Add(ReceiptForm);
                ReceiptForm.FormClosed += new FormClosedEventHandler(form_closing);
                //ReceiptForm.Dock = DockStyle.Fill;
                ReceiptForm.Show();
                ReceiptForm.BringToFront();
            }
            else
            {
                ReceiptForm.Activate();
                ReceiptForm.BringToFront();

            }
        }

    }
}

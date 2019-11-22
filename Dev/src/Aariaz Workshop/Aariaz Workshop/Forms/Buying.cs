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
    public partial class Buying : Form
    {
        public Buying()
        {
            InitializeComponent();
        }

        private void Add_new_buying_btn_Click(object sender, EventArgs e)
        {
            mini_buying_screen.SelectedTab = new_buying_tab;

        }

        private void BunifuImageButton19_Click(object sender, EventArgs e)
        {
            mini_buying_screen.SelectedTab = main_buying_tab;
        }
    }
}

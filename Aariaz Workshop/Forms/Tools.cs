using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aariaz_Workshop
{
    public partial class Tools : Form
    {
        public Tools()
        {
            InitializeComponent();
        }

        private void MetroTile3_Click(object sender, EventArgs e)
        {
            CreateCalc();
        }

        bool RequestNewCalc = false;
        Process pCalc;
        public void CreateCalc()
        {
            if (pCalc == null)
            {
                pCalc = new Process();
                pCalc.StartInfo.FileName = "calc.exe";
                pCalc.Start();
                pCalc.EnableRaisingEvents = true;
                pCalc.Exited += new EventHandler(pCalc_Exited);
            }
            else
            {
                CloseCalc();
                RequestNewCalc = true;
            }
        }
        public void CloseCalc()
        {
            if (pCalc != null)
                pCalc.CloseMainWindow();
        }
        void pCalc_Exited(object sender, EventArgs e)
        {
            pCalc.Dispose();
            pCalc = null;
            if (RequestNewCalc)
            {
                RequestNewCalc = false;
                CreateCalc();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseCalc();
        }
    }
}

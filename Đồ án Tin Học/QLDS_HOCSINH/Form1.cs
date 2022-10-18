using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDS_HOCSINH.GUI;

namespace QLDS_HOCSINH
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DSHocSinhGUI dsHS = new DSHocSinhGUI();
            dsHS.Show();
          //  this.Visible = false;
        }
    }
}

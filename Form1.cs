using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kelompok_6_TUBES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int jumlah = 0;

        private void label1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            jumlah = 10000;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            jumlah = 20000;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            jumlah = 50000;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            jumlah = 100000;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            jumlah = 200000;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            jumlah = 500000;
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}

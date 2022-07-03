using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUBES2
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int kode1 = 1000 + rnd.Next(9999);
            int kode2 = 1000 + rnd.Next(9999);
            int kode3 = 1000 + rnd.Next(9999);
            int kode4 = 1000 + rnd.Next(9999);
            textBox1.Text = kode1.ToString();
            textBox2.Text = kode2.ToString();
            textBox3.Text = kode3.ToString();
            textBox4.Text = kode4.ToString();
        }
    }
}

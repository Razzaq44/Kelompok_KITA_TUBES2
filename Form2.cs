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
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 menu = new Form1();
            menu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                int jumlah, saldo, Sumbangan;
                if(textBox4.Text == ""||textBox5.Text == ""||textBox2.Text == ""||textBox3.Text == "")
                {
                    MessageBox.Show("Kolom tidak boleh kosong!!");
                }
                else 
                {
                    jumlah = Convert.ToInt32(textBox4.Text);
                    Sumbangan = Convert.ToInt32(textBox5.Text);
                    if (jumlah <= Sumbangan)
                    {
                        MessageBox.Show("Isi saldo tidak boleh <= sumbangan!!");
                    }
                    else
                    {
                        saldo = jumlah - Sumbangan;

                        textBox1.Text = "" + saldo;
                        MessageBox.Show("Saldo berhasil ditambahkan");
                    }
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error, Masukan harus berupa angka!!\n"+ex.Message);
            }

        }

    }
}

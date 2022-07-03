using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaldoLibrary;

namespace Kelompok_6_TUBES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Runtime RT = new Runtime();
            int saldo = Convert.ToInt32(RT.config.saldo);
            label6.Text = "Rp. " + saldo.ToString();
        }

        int jumlah = 0;
        string rek;

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
            // Nomor rekening harus min 6 angka dan maks 14 angka
            if (textBox1.Text.Length <= 6 || textBox1.Text.Length >= 14)
            {
                MessageBox.Show("Nomer Rekening tidak terdaftar");
                textBox1.Focus();
            }
            else
            {
                rek = textBox1.Text;
                Runtime RT = new Runtime();
                int saldo = Convert.ToInt32(RT.config.saldo);
                int fee = Convert.ToInt32(RT.config.fee);
                if (saldo <= jumlah + fee)
                {
                    MessageBox.Show("Saldo anda tidak mencukupi untuk melakukan withdrawal dengan nominal Rp. " + jumlah);
                }
                else
                {
                    if (textBox1.Text == "" || jumlah == 0)
                    {
                        MessageBox.Show("Pilih Jumlah dan Isi Nomor Rekening terlebih dahulu!");
                        textBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Withdrawal ke rekening " + rek + " dengan nonimal Rp. " + jumlah + " berhasil");
                        MessageBox.Show("Sisa saldo anda: " + (saldo - jumlah));
                        Config.UpdateSaldo(saldo, jumlah);
                        string UpdateSaldo = SaldoLibrary.Saldo.withdrawal(saldo, jumlah, fee).ToString();
                        label6.Text = "Rp. " + UpdateSaldo;
                    }
                }
            }   
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                        
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 6 || textBox1.Text.Length >= 14)
            {
                MessageBox.Show("Nomer Rekening tidak terdaftar");
                textBox1.Focus();
            }
            else
            {
                rek = textBox1.Text;
                Runtime RT = new Runtime();
                int saldo = Convert.ToInt32(RT.config.saldo);
                if (textBox1.Text == "" || jumlah == 0)
                {
                    MessageBox.Show("Pilih Jumlah dan Isi Nomor Rekening terlebih dahulu!");
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("Tagihan ke rekening " + rek + " dengan nonimal Rp. " + jumlah + " berhasil");
                    MessageBox.Show("saldo anda: " + SaldoLibrary.Saldo.topup(saldo, jumlah));
                    Config.UpdateSaldoTopUp(saldo, jumlah);
                    string UpdateSaldo = SaldoLibrary.Saldo.topup(saldo, jumlah).ToString();
                    label6.Text = "Rp. " + UpdateSaldo;
                }
            }           
        }
    }
}

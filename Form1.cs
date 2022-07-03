namespace TUBES2
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
            this.StartPosition = FormStartPosition.CenterScreen;
           
        }

        private void InitializeComboBox()
        {
            comboBox1.Items.AddRange(Enum.GetNames(typeof(bankIND)));
        }

        enum bankIND
        {
            BCA,
            BRI,
            MANDIRI
        }

        string[] gambar = Directory.GetFiles("C:/TUBES2/Gambar");
        int gambarIndex = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            if (gambarIndex < gambar.Length - 1)
            {
                gambarIndex++;
                picPromo.Image = Image.FromFile(gambar[gambarIndex]);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Isi saldo bebas ribet, yuk cari tahu manfaatnya!\n\nCepat dan Mudah\n\nSaldo Lebih Banyak!\n\nBebas Biaya Admin");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gambarIndex > 0)
            {
                gambarIndex--;
                picPromo.Image = Image.FromFile(gambar[gambarIndex]);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bankIND bank = (bankIND)comboBox1.SelectedIndex;
            if (bank.ToString() == "")
            {
                MessageBox.Show("MOHON MEMLIH BANK YANG TERSEDIA!");
            }
            else
            {
                try
                {
                    if (bank.ToString() == "BCA")
                    {
                        userControl41.Hide();
                        userControl31.Hide();
                        userControl21.Hide();
                        userControl11.Show();
                        userControl11.BringToFront();
                    }
                    else if (bank.ToString() == "BRI")
                    {
                        userControl41.Hide();
                        userControl31.Hide();
                        userControl11.Hide();
                        userControl21.Show();
                        userControl21.BringToFront();
                    }
                    else if (bank.ToString() == "MANDIRI")
                    {
                        userControl41.Hide();
                        userControl11.Hide();
                        userControl21.Hide();
                        userControl31.Show();
                        userControl31.BringToFront();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 kartuBaru = new Form2();
            kartuBaru.Show();
        }
    }
}
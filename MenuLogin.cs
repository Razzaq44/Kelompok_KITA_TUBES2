using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Kelompok_6_TUBES
{
    public partial class MenuLogin : Form
    {
        SqlConnection konek = new SqlConnection(@"Data Source=RARA;Initial Catalog=E-Wallet;Integrated Security=True");
        public MenuLogin()
        {
            InitializeComponent();
        }

        private void MenuLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            konek.Open();
            if (textBox1.Text == "" & textBox2.Text == "" & textBox3.Text == "" & !Regex.IsMatch(textBox3.Text, @"^[a-zA-Z][\w.-][a-zA-Z0-9]@[a-zA-Z0-9][\w.-][a-zA-Z0-9].[a-zA-Z][a-zA-Z.]*[a-zA-Z]$"))//Parshing METHOD
            {
                MessageBox.Show("Username atau password masih kosong");//Programing Defensive METHOD
            }
            else if (textBox2.Text != "Password")
            {
                MessageBox.Show("Password tidak sama");
            }
            else
            {
                SqlDataAdapter adr = new SqlDataAdapter("select Username,Password,Gmail from E-Wallet where Username = '" + textBox1.Text + "' OR Gmail = '" + textBox3.Text + "' AND Password = '" + textBox2.Text + "' ", konek);
                DataTable dt = new DataTable();
                adr.Fill(dt);

                //Table Driven METHOD 
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["Pengguna"].ToString() == "admin")
                        {
                            this.Hide();
                            MenuAdmin MA = new MenuAdmin();
                            MA.Show();
                        }
                        else if (dr["Pengguna"].ToString() == "mahasiswa")
                        {
                            this.Hide();
                            MenuUtama MU = new MenuUtama();
                            MU.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("username atau password salah", "Warning !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);//Programing Defensive METHOD
                }
                //Table Driven METHOD
            }
            konek.Close();
        }
    }
}

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

        }
    }
}

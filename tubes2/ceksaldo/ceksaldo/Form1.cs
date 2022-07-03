using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace ceksaldo
{
    public partial class Form1 : Form
    {
        int saldo = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UIConfig uIConfig = new UIConfig();
            saldo = uIConfig.config.saldo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UIConfig UI = new UIConfig();

            if (saldo >= 0)
            {
                MessageBox.Show("Sisa saldo anda adalah Rp." + saldo);
            }
            else
            {
                MessageBox.Show("");
            }
        }
    }
    public class Config
    {
        public int saldo { get; set; }
        public Config() { }
        public Config(int saldo)
        {
            this.saldo = saldo;
        }
    }
    public class UIConfig
    {
        public Config config;
        public String path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public string fileConfigName = "cekSaldo_config.json";

        private Config ReadConfigFile()
        {
            String configJsonData = File.ReadAllText(path + "/" + fileConfigName);
            config = JsonSerializer.Deserialize<Config>(configJsonData);
            return config;
        }

        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String jsonString = JsonSerializer.Serialize(config);
            string filePath = path + "/" + fileConfigName;
            File.WriteAllText(filePath, jsonString);
        }

        private void SetDefault()
        {
            int saldo = 1000000;

            config = new Config(saldo);
        }
        public UIConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }
    }
}
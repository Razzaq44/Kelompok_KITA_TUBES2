using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using SaldoLibrary;

namespace Kelompok_6_TUBES
{
    public class Runtime
    {
        public Config config;
        public string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public string fileConfigName = "E-Wallet_config.json";

        public Runtime()
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

        private Config ReadConfigFile()
        {
            string jsonStringFromFile = File.ReadAllText(path + "/" + fileConfigName);
            config = System.Text.Json.JsonSerializer.Deserialize<Config>(jsonStringFromFile);
            return config;
        }

        private void SetDefault()
        {
            int fee = 2500;

            int saldo = 100000;

            config = new Config(fee, saldo);
        }

        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonString = System.Text.Json.JsonSerializer.Serialize(config, options);
            string fullFilePath = path + "/" + fileConfigName;
            File.WriteAllText(fullFilePath, jsonString);
        }
    }

    public class Config
    {
        public int fee { get; set; }
        public int saldo { get; set; }
        public Config() { }
        public Config(int fee, int saldo)
        {
            this.fee = fee;
            this.saldo = saldo;
        }
        public static void UpdateSaldo(int Saldo, int Jumlah)
        {
            // Set Path file directory
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string fileConfigName = "E-Wallet_config.json";
            string pathAndFile = path + "/" + fileConfigName;

            // Reading json file from path file directory
            string jsonStringFromFile = File.ReadAllText(path + "/" + fileConfigName);
            var config = System.Text.Json.JsonSerializer.Deserialize<Config>(jsonStringFromFile);

            // Read Saldo from config class
            int NewSaldo = config.saldo;

            // Read saldo from E-Wallet.json
            JObject jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonStringFromFile) as JObject;
            JToken jToken = jObject.SelectToken("saldo");

            // Business Logic
            if (NewSaldo <= 0)
            {
                NewSaldo = 0;
                jToken.Replace(NewSaldo);
            }
            else
            {
                NewSaldo = SaldoLibrary.Saldo.withdrawal(NewSaldo, Jumlah, config.fee);
                jToken.Replace(NewSaldo);
            }

            // Update Saldo in E-Wallet.json file
            string updatedJsonString = jObject.ToString();
            File.WriteAllText(pathAndFile, updatedJsonString);
        }

        public static void UpdateSaldoTopUp(int Saldo, int Nominal)
        {
            // Set Path file directory
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string fileConfigName = "E-Wallet_config.json";
            string pathAndFile = path + "/" + fileConfigName;

            // Reading json file from path file directory
            string jsonStringFromFile = File.ReadAllText(path + "/" + fileConfigName);
            var config = System.Text.Json.JsonSerializer.Deserialize<Config>(jsonStringFromFile);

            // Read Saldo from config class
            int NewSaldo = config.saldo;

            // Read saldo from E-Wallet.json
            JObject jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonStringFromFile) as JObject;
            JToken jToken = jObject.SelectToken("saldo");

            NewSaldo = SaldoLibrary.Saldo.topup(NewSaldo, Nominal);
            jToken.Replace(NewSaldo);

            // Update Saldo in E-Wallet.json file
            string updatedJsonString = jObject.ToString();
            File.WriteAllText(pathAndFile, updatedJsonString);
        }
    }
}

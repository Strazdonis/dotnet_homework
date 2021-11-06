using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApiClient;

namespace Homework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            System.Console.WriteLine("Loaded!");
            // do request for all cryptos.
            foreach (CryptoModel crypto in ApiClient.Fetch.FetchCryptos())
            {
                if(crypto.type_is_crypto != "1") { continue; }
                Console.WriteLine(crypto.name + " - " + crypto.price_usd);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        TableLayoutPanel panel = new TableLayoutPanel();
        private void Form1_Load(object sender, EventArgs e)
        {
            // TableLayoutPanel Initialization


            panel.AutoScroll = false;
            panel.HorizontalScroll.Enabled = false;
            panel.HorizontalScroll.Visible = false;
            panel.HorizontalScroll.Maximum = 0;
            panel.AutoScroll = true;
            panel.ColumnCount = 6;
            panel.RowCount = 1;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            panel.Controls.Add(new Label() { Text = "Name" }, 1, 0);
            panel.Controls.Add(new Label() { Text = "Price" }, 2, 0);
            panel.Controls.Add(new Label() { Text = "Hourly volume" }, 3, 0);
            panel.Controls.Add(new Label() { Text = "Daily volume" }, 4, 0);
            panel.Controls.Add(new Label() { Text = "Weekly volume" }, 5, 0);
            panel.BackColor = Color.Red;


            // do request for all cryptos.
            int i = 0;
            foreach (CryptoModel crypto in Fetch.FetchCryptos())
            {
                float h_volume = float.Parse(crypto.volume_1hrs_usd, CultureInfo.InvariantCulture);
                if (crypto.type_is_crypto == "0" || h_volume == 0) { continue; }
                if(i++ == 30) { break; }
                Console.WriteLine(crypto.name + " - " + h_volume + " - " + (h_volume > 0).ToString());
                panel.RowCount = panel.RowCount + 1;

                Label nameLabel = new Label() { Text = crypto.name };
                nameLabel.Click += delegate (object sndr, EventArgs ev) { clickOnRow(sndr, ev, crypto.asset_id); };

                Label priceLabel = new Label() { Text = crypto.price_usd };
                priceLabel.Click += delegate (object sndr, EventArgs ev) { clickOnRow(sndr, ev, crypto.asset_id); };

                Label volume_1hrs_label = new Label() { Text = crypto.volume_1hrs_usd };
                volume_1hrs_label.Click += delegate (object sndr, EventArgs ev) { clickOnRow(sndr, ev, crypto.asset_id); };

                Label volume_1day_label = new Label() { Text = crypto.volume_1day_usd };
                volume_1day_label.Click += delegate (object sndr, EventArgs ev) { clickOnRow(sndr, ev, crypto.asset_id); };

                Label volume_1mth_label = new Label() { Text = crypto.volume_1mth_usd };
                volume_1mth_label.Click += delegate (object sndr, EventArgs ev) { clickOnRow(sndr, ev, crypto.asset_id); };

                panel.Controls.Add(nameLabel, 1, panel.RowCount - 1);
                panel.Controls.Add(priceLabel, 2, panel.RowCount - 1);
                panel.Controls.Add(volume_1hrs_label, 3, panel.RowCount - 1);
                panel.Controls.Add(volume_1day_label, 4, panel.RowCount - 1);
                panel.Controls.Add(volume_1mth_label, 5, panel.RowCount - 1);
            }
            panel.Size = new Size(this.Width-15, this.Height-40);
            this.Controls.Add(panel);
        }

        private void clickOnRow(object sender, EventArgs e, string asset_id)
        {
            CryptoModel crypto = Fetch.FetchSingleCrypto(asset_id);
            MessageBox.Show("Graph and stuff for " + crypto.name + " some day, maybe.");
            Console.WriteLine(asset_id);
        }
    }
}

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
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            // 1 more, empty column needs to be added. Otherwise column above ignores absolute sizetype and uses all the space available.
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            panel.Controls.Add(new Label() { Text = "Name" }, 0, 0);
            panel.Controls.Add(new Label() { Text = "Price" }, 1, 0);
            panel.Controls.Add(new Label() { Text = "Hourly volume" }, 2, 0);
            panel.Controls.Add(new Label() { Text = "Daily volume" }, 3, 0);
            panel.Controls.Add(new Label() { Text = "Weekly volume" }, 4, 0);
            panel.Controls.Add(new Label() { Text = "" }, 5, 0);

            //panel.BackColor = Color.Red;

            int i = 0;
            foreach (CryptoModel crypto in Fetch.FetchCryptos())
            {
                float h_volume = float.Parse(crypto.volume_1hrs_usd, CultureInfo.InvariantCulture);
                if (crypto.type_is_crypto == "0" || h_volume == 0) { continue; }
                // show top 50 only
                if (i++ == 49) { break; }
                const int padding = 20;
                const int height = 80;
                panel.RowCount = panel.RowCount + 1;

                Label nameLabel = new Label() { Text = crypto.name };
                nameLabel.Height = 80;
                nameLabel.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
                nameLabel.Margin = new System.Windows.Forms.Padding(0, 40, 0, 20);
                // needed for borders to be displayed properly.
                nameLabel.Click += delegate (object sndr, EventArgs ev) { clickOnRow(sndr, ev, crypto.asset_id); };


                string price = ToKMBT(decimal.Parse(crypto.price_usd, CultureInfo.InvariantCulture));

                Label priceLabel = new Label() { Text = price };

                priceLabel.Height = 80;
                priceLabel.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
                priceLabel.Margin = new System.Windows.Forms.Padding(0, 40, 0, 20);

                priceLabel.Click += delegate (object sndr, EventArgs ev) { clickOnRow(sndr, ev, crypto.asset_id); };


                string volume_1hrs = ToKMBT(decimal.Parse(crypto.volume_1hrs_usd, CultureInfo.InvariantCulture));
                Label volume_1hrs_label = new Label() { Text = volume_1hrs };

                volume_1hrs_label.Height = 80;
                volume_1hrs_label.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
                volume_1hrs_label.Margin = new System.Windows.Forms.Padding(0, 40, 0, 20);

                volume_1hrs_label.Click += delegate (object sndr, EventArgs ev) { clickOnRow(sndr, ev, crypto.asset_id); };


                string volume_1day = ToKMBT(decimal.Parse(crypto.volume_1day_usd, CultureInfo.InvariantCulture));
                Label volume_1day_label = new Label() { Text = volume_1day };

                volume_1day_label.Height = 80;
                volume_1day_label.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
                volume_1day_label.Margin = new System.Windows.Forms.Padding(0, 40, 0, 20);

                volume_1day_label.Click += delegate (object sndr, EventArgs ev) { clickOnRow(sndr, ev, crypto.asset_id); };


                string volume_1mth = ToKMBT(decimal.Parse(crypto.volume_1mth_usd, CultureInfo.InvariantCulture));
                Label volume_1mth_label = new Label() { Text = volume_1mth };

                volume_1mth_label.Height = 80;
                volume_1mth_label.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
                volume_1mth_label.Margin = new System.Windows.Forms.Padding(0, 40, 0, 20);

                volume_1mth_label.Click += delegate (object sndr, EventArgs ev) { clickOnRow(sndr, ev, crypto.asset_id); };

                panel.Controls.AddRange(new Control[] { nameLabel, priceLabel, volume_1hrs_label, volume_1day_label, volume_1mth_label, new Label() { } });

            }
            panel.Location = new Point(10, 10);
            panel.Size = new Size(this.Width-30, this.Height-45);
            this.Controls.Add(panel);
            panel.CellPaint += panel_CellPaint;
        }

        private void clickOnRow(object sender, EventArgs e, string asset_id)
        {
            Form2 form2 = new Form2(asset_id);
            form2.ShowDialog();
            Console.WriteLine(asset_id);
        }
        private void clickOnRow(object sender, EventArgs e)
        {

        }
        // draws borders around cells
        void panel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            
            var rectangle = e.CellBounds;
            //rectangle.Inflate(0, 0);
            var topLeft = rectangle.Location;
            var topRight = new Point(rectangle.Right, rectangle.Top);
           
            if (e.Row > 0 && e.Column <5)
            {
                // e.Graphics.DrawRectangle(new Pen(Color.FromArgb(255, 239, 242, 245)), rectangle);
                e.Graphics.DrawLine(new Pen(Color.FromArgb(255, 239, 242, 245), 2), topLeft, topRight);
            }
                
        }


        public static string ToKMBT(decimal num)
        {   if(num == 0)
            {
                return "$0";
            }
            else
            if(num > 999999999999 || num < -999999999999)
            {
                return num.ToString("$0,,,,.####T", CultureInfo.InvariantCulture);
            }
            else
            if (num > 999999999 || num < -999999999)
            {
                return num.ToString("$0,,,.###B", CultureInfo.InvariantCulture);
            }
            else
            if (num > 999999 || num < -999999)
            {
                return num.ToString("$0,,.##M", CultureInfo.InvariantCulture);
            }
            else
            if (num > 999 || num < -999)
            {
                return num.ToString("$0,.#K", CultureInfo.InvariantCulture);
            }
            else
            {

                return "$"+RoundFirstSignificantDigit((double)num, 3);
            }
        }


        private static string RoundFirstSignificantDigit(double d, int digits)
        {
            double scale = Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(d))) + 1);
            return (scale * Math.Round(d / scale, digits)).ToString(CultureInfo.InvariantCulture);
        }

    }
}

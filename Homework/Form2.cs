using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ApiClient;

namespace Homework
{
    public partial class Form2 : Form
    {
        CryptoModel selectedCrypto = null;

        Cache history_cache = null;
        public Form2(string asset_id, Cache cache)
        {

            InitializeComponent();
            CryptoModel crypto = Fetch.FetchSingleCrypto(asset_id);
            selectedCrypto = crypto;
            this.Text = crypto.name;
            history_cache = cache;
            IList<HistoryModel> history = history_cache.FetchCryptoHistory(asset_id, "7DAY");
            Console.WriteLine("Got data, starting rendering");
            renderChart(history);
            populateList(history);
        }

        public void populateList(IList<HistoryModel> data)
        {
            Decimal current = Decimal.Parse(data[data.Count - 1].rate_close);

            // last 7 days
            Decimal previous = Decimal.Parse(data[data.Count - 2].rate_close);
            listBox1.Items.Add("7 Day: " + calculateChange(current, previous));

            // last month
            // 4 weeks = 1 month
            previous = Decimal.Parse(data[data.Count - 5].rate_close);
            listBox1.Items.Add("1 Month: " + calculateChange(current, previous));

            // last 6 months
            // 4 weeks = 1 month, 24 = 6 months
            previous = Decimal.Parse(data[data.Count - 25].rate_close);
            listBox1.Items.Add("6 Month: " + calculateChange(current, previous));

            // 1 year
            previous = Decimal.Parse(data[0].rate_close);
            listBox1.Items.Add("Past year: " + calculateChange(current, previous));
        }


        public static string calculateChange(Decimal current, Decimal previous)
        {
            string result = current > previous ? "+":"-";
            decimal difference;
            if (current == previous)
            {
                result = "=0 %";
            }
            else
            {
                difference = Math.Abs(current - previous);
                result += RoundFirstSignificantDigit((Double)(difference / previous) * 100, 4) + " %";
            }
            return result;
        }

        public void renderChart(IList<HistoryModel> data)
        {
            var objChart = chart1.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;

            objChart.AxisX.Minimum = 1;
            objChart.AxisX.Maximum = data.Count;

            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;

            chart1.Series.Clear();
            chart1.Series.Add("Close rate");
            chart1.Series["Close rate"].Color = Color.FromArgb(255, 22, 193, 132);
            chart1.Series["Close rate"].BorderWidth = 2;
            chart1.Series["Close rate"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            double minimum = double.Parse(data[0].rate_close, CultureInfo.InvariantCulture);
            double maximum = 0;
            Console.WriteLine("Looping...");
            foreach (HistoryModel h in data)
            {
                DateTime date = DateTime.Parse(h.time_close);

                chart1.Series["Close rate"].Points.AddXY(date.ToShortDateString(), h.rate_close);

                double close_rate = double.Parse(h.rate_close, CultureInfo.InvariantCulture);
                if (close_rate < minimum)
                {
                    minimum = close_rate;
                }
                else if (close_rate > maximum)
                {
                    maximum = close_rate;
                }
            }
            Console.WriteLine("done looping" + " " + minimum + " / " + maximum + " .... " + data.Count);
            objChart.AxisY.Minimum = RoundFirstSignificantDigit(minimum, 3);
            objChart.AxisY.Maximum = RoundFirstSignificantDigit(maximum, 3);
        }

        // TODO: move to another place, repeating code - also used in Form1.cs
        private static double RoundFirstSignificantDigit(double d, int digits)
        {
            if (d == 0)
            {
                return 0;
            }
            double scale = Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(d))) + 1);
            return scale * Math.Round(d / scale, digits);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void handleClick(string period)
        {
            renderChart(history_cache.FetchCryptoHistory(selectedCrypto.asset_id, period));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            handleClick("1DAY");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            handleClick("3DAY");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            handleClick("5DAY");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            handleClick("7DAY");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            handleClick("10DAY");
        }
    }
}

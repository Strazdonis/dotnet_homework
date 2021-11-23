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
    public partial class Form2 : Form
    {
        CryptoModel selectedCrypto = null;
        public Form2(string asset_id)
        {

            InitializeComponent();
            CryptoModel crypto = Fetch.FetchSingleCrypto(asset_id);
            selectedCrypto = crypto;
            this.Text = crypto.name;
            IList<HistoryModel> history = Fetch.FetchCryptoHistory(asset_id, "7DAY");
            Console.WriteLine("Got data, starting rendering");
            renderChart(history);
        }

        public void renderChart(IList<HistoryModel> data)
        {
            var objChart = chart1.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            // 1 year
            objChart.AxisX.Minimum = 1;
            objChart.AxisX.Maximum = 54;

            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            // loop history and find actual minimum?

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
            Console.WriteLine("done looping");
            objChart.AxisY.Minimum = minimum;
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
    }
}

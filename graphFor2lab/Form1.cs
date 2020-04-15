using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphFor2lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetEncStartForCaesar();
            GetDecStartForCaesar();
            GetEncStartForTrisemus();
            GetDecStartForTrisemus();
        }

        public void GetEncStartForCaesar()
        {
            string kek;
            using (StreamReader sw = new StreamReader(@"E:\SomeDir\encrypt.txt"))
            {
                kek = sw.ReadToEnd().ToLower();
            }

            var symbols = kek.Distinct().Where(c => c != ' ').ToArray();

            foreach (var symbol in symbols)
            {
                int i = 0, k = 0;
                for (int j = 0; j < kek.Length; j++)
                {
                    if (kek[j] == symbol)
                        i++;
                }
               
                double freq = Convert.ToDouble(i) / Convert.ToDouble(kek.Length);
                chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                chart1.Series["EncCaesar"].Points.AddXY(symbol.ToString(), freq);
                chart1.Series["EncCaesar"].ToolTip = $"Частота {freq}";
                chart1.Series["EncCaesar"].Points[k].AxisLabel = symbol.ToString();
                k++;
            }

        }


        public void GetDecStartForCaesar()
        {
            string kek;
            using (StreamReader sw = new StreamReader(@"E:\SomeDir\decrypt.txt"))
            {
                kek = sw.ReadToEnd().ToLower();
            }

            var symbols = kek.Distinct().Where(c => c != ' ').ToArray();

            foreach (var symbol in symbols)
            {
                int i = 0, k = 0;
                for (int j = 0; j < kek.Length; j++)
                {
                    if (kek[j] == symbol)
                        i++;
                }

                double freq = Convert.ToDouble(i) / Convert.ToDouble(kek.Length);
                chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                chart2.Series["DecCaesar"].Points.AddXY(symbol.ToString(), freq);
                chart2.Series["DecCaesar"].ToolTip = $"Частота {freq}";
                chart2.Series["DecCaesar"].Points[k].AxisLabel = symbol.ToString();
                k++;
            }

        }


        public void GetEncStartForTrisemus()
        {
            string kek;
            using (StreamReader sw = new StreamReader(@"E:\SomeDir\encryptTrisemus.txt"))
            {
                kek = sw.ReadToEnd().ToLower();
            }

            var symbols = kek.Distinct().Where(c => c != ' ').ToArray();

            foreach (var symbol in symbols)
            {
                int i = 0, k = 0;
                for (int j = 0; j < kek.Length; j++)
                {
                    if (kek[j] == symbol)
                        i++;
                }

                double freq = Convert.ToDouble(i) / Convert.ToDouble(kek.Length);
                chart3.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                chart3.Series["EncTrisemus"].Points.AddXY(symbol.ToString(), freq);
                chart3.Series["EncTrisemus"].ToolTip = $"Частота {freq}";
                chart3.Series["EncTrisemus"].Points[k].AxisLabel = symbol.ToString();
                k++;
            }

        }


        public void GetDecStartForTrisemus()
        {
            string kek;
            using (StreamReader sw = new StreamReader(@"E:\SomeDir\decryptTrisemus.txt"))
            {
                kek = sw.ReadToEnd().ToLower();
            }

            var symbols = kek.Distinct().Where(c => c != ' ').ToArray();

            foreach (var symbol in symbols)
            {
                int i = 0, k = 0;
                for (int j = 0; j < kek.Length; j++)
                {
                    if (kek[j] == symbol)
                        i++;
                }

                double freq = Convert.ToDouble(i) / Convert.ToDouble(kek.Length);
                chart4.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                chart4.Series["DecTrisemus"].Points.AddXY(symbol.ToString(), freq);
                chart4.Series["DecTrisemus"].ToolTip = $"Частота {freq}";
                chart4.Series["DecTrisemus"].Points[k].AxisLabel = symbol.ToString();
                k++;
            }

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}

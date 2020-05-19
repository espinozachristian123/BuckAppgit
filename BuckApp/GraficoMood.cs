using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BuckApp
{
    public partial class GraficoMood : Form
    {
        List<Mood> themood;
        MoodDAO cn = new MoodDAO();
        private MoodController moodcontroller;
        int numeromood;
        User user;
        public GraficoMood(User user)
        {
            InitializeComponent();
            this.user = user;
            moodcontroller = new MoodController();
            themood = new List<Mood>();
            loaddatamood();
            numeromood = themood.Count;
            //numeromood = numeromood;
        }

        private void loaddatamood()
        {
            themood = moodcontroller.loadOnePersonMood(user.Id);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = cn.ConsultarMood();
            chart1.Titles.Add("Grafico Modd");
            //foreach (DataRow row in dt.Rows)
            //{
            //  Series series = chart1.Series.Add(row["date"].ToString());
            //series.Points.Add(Convert.ToDouble(row["mood"].ToString()));
            // series.Label = row["date"].ToString();
            // series.ChartType = SeriesChartType.FastLine;
            //  MessageBox.Show("Numero total es "+ dt.Rows.Count);
            //prueba2
                for (int i = 0; i< numeromood; i++)
                {
                //for (int j = 0; j < i; j++)
                //{
                        chart1.Series["Mood"].Points.Add(themood[i].Moods);
                        chart1.Series["Mood"].Points[i].Color = Color.Green;
                        chart1.Series["Mood"].Points[i].AxisLabel = "Mood Dia: "+themood[i].Fecha;
                        chart1.Series["Mood"].Points[i].LegendText = "Mood Dia: " + themood[i].Fecha;
                // chart1.Series["Mood"].Points[i].Label = "Mood Dia: "+themood[i].Fecha;

                //}

                //i = i;

                // }

                //
                //chart1.Series["Mood"].Points.Add(Convert.ToInt32(row["mood"].ToString()));
                //chart1.Series["Mood"].Points[1].Color = Color.Red;
                //chart1.Series["Mood"].Points[1].AxisLabel = "Mood2";
                //chart1.Series["Mood"].Points[1].LegendText = "Mood2";
                //chart1.Series["Mood"].Points[1].Label = "Mood2";


            }
        }

        private void GraficoMood_Load(object sender, EventArgs e)
        {

        }
    }
}

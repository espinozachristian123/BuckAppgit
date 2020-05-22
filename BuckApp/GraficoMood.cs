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
        private int numeromood;
        private DateTime fecha;
        private List<Mood> themood;

        private MoodDAO cn;
        private MoodController moodcontroller;
        
        User user;
        
        public GraficoMood(User user)
        {
            InitializeComponent();
            this.user = user;
            moodcontroller = new MoodController();
            themood = new List<Mood>();
            cn = new MoodDAO();
            loaddatamood();
        }

        private void GraficoMood_Load(object sender, EventArgs e)
        {
            CargarMetodos();
        }

        private void loaddatamood()
        {
            themood = moodcontroller.loadOnePersonMood(user.Id);
        }

        private void CargarMetodos()
        {
            if (themood == null)
            {
                MessageBox.Show("No tienes datos de Mood!!");
            }
            else if (themood.Count == 1)
            {

                MessageBox.Show("Solo tienes un dato mood, No se puede crear grafico, Intentalo Mañana");
            }
            else
            {
                loadGrafic();
            }
        }

        private void loadGrafic()
        {
            numeromood = themood.Count;
            for (int i = 0; i < numeromood; i++)
            {
                fecha = Convert.ToDateTime(themood[i].Date);
                chart1.Series["Mood"].Points.Add(themood[i].Moods);
                chart1.Series["Mood"].Points[i].Color = Color.Green;
                chart1.Series["Mood"].Points[i].AxisLabel = "Mood Dia: " + fecha.ToShortDateString();
                chart1.Series["Mood"].Points[i].LegendText = "Mood Dia: " + fecha.ToShortDateString();
            }
        }
    }
}

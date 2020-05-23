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
        }
        /// <summary>
        /// Load the graph data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraficoMood_Load(object sender, EventArgs e)
        {
            loadDataMood();
            loadGraphicMood();
        }
        /// <summary>
        /// Loads the mood data of the user who has connected
        /// </summary>
        private void loadDataMood()
        {
            themood = moodcontroller.loadOnePersonMood(user.Id);
        }
        /// <summary>
        /// Check that the user has data, if it does not have, it shows a message informing that it has no data and does not open the graph
        /// Check that you have if you only have 1 mood data, if you only have 1 data it informs you to come back tomorrow and does not open the graph
        /// If after these checks are not fulfilled, call the method to load the graph
        /// </summary>
        private void loadGraphicMood()
        {
            if (themood == null)
            {
                MessageBox.Show("No tienes datos de Mood!!");
                this.Close();
            }
            else if (themood.Count == 1)
            {

                MessageBox.Show("Con un dato de estado de animo, no es posible crear un grafico !!");
                this.Close();
            }
            else
            {
                loadGrafic();
            }
        }
        /// <summary>
        /// Scrolls the mood data to be able to list it on the graph and shows it on the screen with its corresponding date on which the data was collected
        /// </summary>
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

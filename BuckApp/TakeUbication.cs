using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuckApp
{
    public partial class TakeUbication : Form
    {
        String direccion_Definitiva;
        
        public TakeUbication()
        {
            InitializeComponent();
        }

        /// <summary>
        /// open google maps
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TakeUbication_Load(object sender, EventArgs e)
        {
            try
            {
                StringBuilder queryaddress = new StringBuilder();
                queryaddress.Append("http://maps.google.com/maps?q=");

                wbMaps.ScriptErrorsSuppressed = true;
                wbMaps.Navigate(queryaddress.ToString());
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString(),"Error");
            }
        }

        /// <summary>
        /// get the full location of the current window (Google maps)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TakeUbication_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                String ubicacion = wbMaps.Document.Url.OriginalString;
                String[] infoSplited = ubicacion.Split('/');
                String direccion = infoSplited[5];
                direccion_Definitiva = direccion.Replace("+", " ");
            }
            catch
            {
                MessageBox.Show("No has puesto ninguna direccion!!");
            }
        }

        public string Direccion_Definitiva { get => direccion_Definitiva; set => direccion_Definitiva = value; }
    }
}

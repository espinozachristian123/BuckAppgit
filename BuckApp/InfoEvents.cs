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
    public partial class InfoEvents : Form
    {
        String name, description, localidad, fecha, type;
        int n_participantes, n_maxParticipantes, id_user, userID;

        public InfoEvents(String name, String description, String localidad, String fecha, 
            int n_participantes, int n_maxParticipantes, String type, int id_user, int userID)
        {
            InitializeComponent();
            this.name = name;
            this.description = description;
            this.localidad = localidad;
            this.fecha = fecha;
            this.n_participantes = n_participantes;
            this.n_maxParticipantes = n_maxParticipantes;
            this.type = type;
            this.id_user = id_user;
            this.userID = userID;
        }

        private void InfoEvents_Load(object sender, EventArgs e)
        {
            ponerDatosTextBox();
            ocultarCampos();
        }
        
        private void ponerDatosTextBox()
        {
            tbName.Text = name;
            tbDescription.Text = description;
            tbLocalidad.Text = localidad;
            tbFecha.Text = fecha;
            tbNInscritos.Text = Convert.ToString(n_participantes);
            tbMaxParticipantes.Text = Convert.ToString(n_maxParticipantes);
            tbTipo.Text = type;
        }

        private void ocultarCampos()
        {
            if (id_user != userID)
            {
                tbName.ReadOnly = true;
                tbDescription.ReadOnly = true;
                tbLocalidad.ReadOnly = true;
                tbFecha.ReadOnly = true;
                tbNInscritos.ReadOnly = true;
                tbMaxParticipantes.ReadOnly = true;
                tbTipo.ReadOnly = true;
                btModify.Enabled = false;
                btDelete.Enabled = false;
            }
        }
    }
}

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

namespace BuckApp
{
    public partial class MainUser : Form
    {

        private EventController eventController;
        ListViewItem itm;
        List<Event> events;
        List<String> typeEvents;
        User user;

        public MainUser(User user)
        {
            InitializeComponent();
            this.user = user;
            eventController = new EventController();
            events = new List<Event>();
            cargarEventosListView();
            cargarComboBox();
        }

        private void cargarEventosListView()
        {
            events = eventController.cargarDatos();
            if (events == null)
            {
                MessageBox.Show("No se ha podido cargar la lista de eventos !!");
            }
            else
            {
                for(int i = 0; i < events.Count; i++)
                {
                    string[] listaEventos = new string[8];
                    //add items to ListView
                    listaEventos[0] = events[i].Name;
                    listaEventos[1] = events[i].Description;
                    listaEventos[2] = events[i].Location;
                    listaEventos[3] = events[i].Date.ToString();
                    listaEventos[4] = events[i].NumParticipants.ToString();
                    listaEventos[5] = events[i].NumMaxParticipantes.ToString();
                    listaEventos[6] = events[i].Type;
                    listaEventos[7] = events[i].Id_user.ToString();
                    itm = new ListViewItem(listaEventos);
                    listViewEvent.Items.Add(itm);
                }
            }
            
        }

        private void cargarComboBox()
        {
            typeEvents = eventController.cargarDatosComboBox();
            for(int i = 0; i < typeEvents.Count; i++)
            {
                cbCategory.Items.Add(typeEvents[i]);
            }
        }

        private void cargarListViewConFiltro(object sender, EventArgs e)
        {
            listViewEvent.Items.Clear();
            string location = tbCity.Text;
            string type = cbCategory.SelectedItem.ToString();
            events = eventController.cargarDatosConFiltro(location,type);
            if (events == null)
            {
                MessageBox.Show("No se ha podido cargar la lista de eventos !!");
            }
            else
            {
                for (int i = 0; i < events.Count; i++)
                {
                    string[] listaEventos = new string[8];
                    //add items to ListView
                    listaEventos[0] = events[i].Name;
                    listaEventos[1] = events[i].Description;
                    listaEventos[2] = events[i].Location;
                    listaEventos[3] = events[i].Date.ToString();
                    listaEventos[4] = events[i].NumParticipants.ToString();
                    listaEventos[5] = events[i].NumMaxParticipantes.ToString();
                    listaEventos[6] = events[i].Type;
                    listaEventos[7] = events[i].Id_user.ToString();
                    itm = new ListViewItem(listaEventos);
                    listViewEvent.Items.Add(itm);
                }
            }
        }

        private void consultProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(user);
            profile.ShowDialog();
        }

        private void listarActividadesDeUnaPersona(object sender, EventArgs e)
        {
            listViewEvent.Items.Clear();
            events = eventController.cargarDatosUnaPersona(user.Id);
            if (events == null)
            {
                MessageBox.Show("No se ha podido cargar la lista de eventos !!");
            }
            else
            {
                for (int i = 0; i < events.Count; i++)
                {
                    string[] listaEventos = new string[8];
                    //add items to ListView
                    listaEventos[0] = events[i].Name;
                    listaEventos[1] = events[i].Description;
                    listaEventos[2] = events[i].Location;
                    listaEventos[3] = events[i].Date.ToString();
                    listaEventos[4] = events[i].NumParticipants.ToString();
                    listaEventos[5] = events[i].NumMaxParticipantes.ToString();
                    listaEventos[6] = events[i].Type;
                    listaEventos[7] = events[i].Id_user.ToString();
                    itm = new ListViewItem(listaEventos);
                    listViewEvent.Items.Add(itm);
                }
            }
        }
    }
}

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
                    string[] listaEventos = new string[9];
                    //add items to ListView
                    listaEventos[0] = events[i].Name;
                    listaEventos[1] = events[i].Description;
                    listaEventos[2] = events[i].Location;
                    listaEventos[3] = events[i].Date.ToString();
                    listaEventos[4] = events[i].NumParticipants.ToString();
                    listaEventos[5] = events[i].NumMaxParticipantes.ToString();
                    listaEventos[6] = events[i].Type;
                    listaEventos[7] = events[i].Id_user.ToString();
                    listaEventos[8] = events[i].Id.ToString();
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
                    string[] listaEventos = new string[9];
                    //add items to ListView
                    listaEventos[0] = events[i].Name;
                    listaEventos[1] = events[i].Description;
                    listaEventos[2] = events[i].Location;
                    listaEventos[3] = events[i].Date.ToString();
                    listaEventos[4] = events[i].NumParticipants.ToString();
                    listaEventos[5] = events[i].NumMaxParticipantes.ToString();
                    listaEventos[6] = events[i].Type;
                    listaEventos[7] = events[i].Id_user.ToString();
                    listaEventos[8] = events[i].Id.ToString();
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
                    string[] listaEventos = new string[9];
                    //add items to ListView
                    listaEventos[0] = events[i].Name;
                    listaEventos[1] = events[i].Description;
                    listaEventos[2] = events[i].Location;
                    listaEventos[3] = events[i].Date.ToString();
                    listaEventos[4] = events[i].NumParticipants.ToString();
                    listaEventos[5] = events[i].NumMaxParticipantes.ToString();
                    listaEventos[6] = events[i].Type;
                    listaEventos[7] = events[i].Id_user.ToString();
                    listaEventos[8] = events[i].Id.ToString();
                    itm = new ListViewItem(listaEventos);
                    listViewEvent.Items.Add(itm);
                }
            }
        }

        private void listViewEvent_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem listItem = listViewEvent.SelectedItems[0];
            String name = listItem.SubItems[0].Text;
            String description = listItem.SubItems[1].Text;
            String localidad = listItem.SubItems[2].Text;
            String fecha = listItem.SubItems[3].Text;
            int n_participantes = Convert.ToInt16(listItem.SubItems[4].Text);
            int n_maxParticipantes = Convert.ToInt16(listItem.SubItems[5].Text);
            String type = listItem.SubItems[6].Text;
            int id_user = Convert.ToInt16(listItem.SubItems[7].Text);
            int id_event = Convert.ToInt16(listItem.SubItems[8].Text);
            InfoEvents infoEvents = new InfoEvents(id_event,name, description,localidad,fecha,n_participantes,n_maxParticipantes,type,id_user, user.Id);
            infoEvents.ShowDialog();
            actualizarListView();
        }

        private void actualizarListView()
        {
            events = new List<Event>();
            listViewEvent.Items.Clear();
            cargarEventosListView();
        }
    }
}

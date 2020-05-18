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
        Boolean exit;

        public MainUser(User user)
        {
            InitializeComponent();
            this.user = user;
            eventController = new EventController();
            events = new List<Event>();
            loadEventsListView();
            loadComboBox();
        }

        private void loadEventsListView()
        {
            events = eventController.loadDatas();
            if (events == null)
            {
                MessageBox.Show("No se ha podido cargar la lista de eventos !!");
            }
            else
            {
                loadListListView();
            }
        }

        private void loadComboBox()
        {
            typeEvents = eventController.loadDataComboBox();
            for (int i = 0; i < typeEvents.Count; i++)
            {
                cbCategory.Items.Add(typeEvents[i]);
            }
        }

        private void loadListListView()
        {
            for (int i = 0; i < events.Count; i++)
            {
                string[] listEvents = new string[9];
                //add items to ListView
                listEvents[0] = events[i].Name;
                listEvents[1] = events[i].Description;
                listEvents[2] = events[i].Location;
                listEvents[3] = events[i].Date.ToString();
                listEvents[4] = events[i].NumParticipants.ToString();
                listEvents[5] = events[i].NumMaxParticipantes.ToString();
                listEvents[6] = events[i].Type;
                listEvents[7] = events[i].Id_user.ToString();
                listEvents[8] = events[i].Id.ToString();
                itm = new ListViewItem(listEvents);
                listViewEvent.Items.Add(itm);
            }

        }

        private void loadListViewWithFilter(object sender, EventArgs e)
        {
            listViewEvent.Items.Clear();
            try
            {
                string location = tbCity.Text;
                string type = cbCategory.SelectedItem.ToString();
                if (location.Equals(String.Empty) && type.Equals(String.Empty))
                {
                    events = eventController.loadDatas();
                    if (events == null)
                    {
                        MessageBox.Show("No se ha podido cargar la lista de eventos !!");
                    }
                    else
                    {
                        loadListListView();
                    }
                }
                else if (location.Equals(String.Empty))
                {
                    events = eventController.loadDataWithFilterType(type);
                    if (events == null)
                    {
                        MessageBox.Show("No se ha podido cargar la lista de eventos !!");
                    }
                    else
                    {
                        loadListListView();
                    }
                }
                else if (type.Equals(String.Empty))
                {

                    events = eventController.loadDataWithFilterLocation(location);
                    if (events == null)
                    {
                        MessageBox.Show("No se ha podido cargar la lista de eventos !!");
                    }
                    else
                    {
                        loadListListView();
                    }
                }
                else
                {
                    events = eventController.loadDataWithFilter(location, type);
                    if (events == null)
                    {
                        MessageBox.Show("No se ha podido cargar la lista de eventos !!");
                    }
                    else
                    {
                        loadListListView();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar una categoria!!");
            }
            
        }

        private void consultProfile(object sender, EventArgs e)
        {
            Profile profile = new Profile(user);
            profile.ShowDialog();
        }

        private void listOnePersonActivities(object sender, EventArgs e)
        {
            listViewEvent.Items.Clear();
            events = eventController.loadOnePersonActivities(user.Id);
            if (events == null)
            {
                MessageBox.Show("No se ha podido cargar la lista de eventos !!");
            }
            else
            {
                loadListListView();
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
            InfoEvents infoEvents = new InfoEvents(id_event, name, description, localidad, fecha, n_participantes, n_maxParticipantes, type, id_user, user.Id);
            infoEvents.ShowDialog();
            updateListView();
        }

        private void updateListView()
        {
            events = new List<Event>();
            listViewEvent.Items.Clear();
            loadEventsListView();
        }

        private void addEvent(object sender, EventArgs e)
        {
            AddEvents subir = new AddEvents(user);
            subir.ShowDialog();
            updateListView();
        }

        private void logOut(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Estas seguro de cerrar sesion?? ", "Cerrar sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                this.Close();
                exit = true;
            }
            else
            {
                exit = false;
            }
        }
        public bool Exit { get => exit; set => exit = value; }

        private void consultGraphicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraficoMood gm = new GraficoMood(user);
            gm.Show();
        }
    }
}

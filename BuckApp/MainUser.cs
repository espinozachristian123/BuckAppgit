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
        int selected_option = 0;

        string location;
        string type;

        public MainUser(User user)
        {
            InitializeComponent();
            this.user = user;
            eventController = new EventController();
           // events = new List<Event>();
            typeEvents = new List<String>();
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
                //DateTime date = Convert.ToDateTime(events[i].Date.ToString());
                string[] listEvents = new string[13];
                //add items to ListView
                listEvents[0] = events[i].Name;
                listEvents[1] = events[i].Description;
                listEvents[2] = events[i].City;
                listEvents[3] = events[i].Direction;
                listEvents[4] = Convert.ToDateTime(events[i].Date.ToString()).ToShortDateString();
                listEvents[5] = Convert.ToDateTime(events[i].Date.ToString()).ToShortTimeString();
                listEvents[6] = events[i].Duration.ToString();
                listEvents[7] = events[i].NumParticipants.ToString();
                listEvents[8] = events[i].NumMaxParticipantes.ToString();
                listEvents[9] = events[i].Type;
                listEvents[10] = events[i].Mood.ToString();
                listEvents[11] = events[i].Id_user.ToString();
                listEvents[12] = events[i].Id.ToString();
                itm = new ListViewItem(listEvents);
                listViewEvent.Items.Add(itm);
            }

        }

        private void loadListViewWithFilter(object sender, EventArgs e)
        {
            listViewEvent.Items.Clear();
            try
            {
                location = tbCity.Text;
                type = cbCategory.Text;
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
                    loadDataWithFilterType(type);
                }
                else if (type.Equals(String.Empty))
                {
                    loadDataWithFilterLocation(location);
                }
                else
                {
                    loadDataWithFilterLocationType(location,type);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar una categoria!!");
            }
            
        }

        private void loadDataWithFilterType(String type)
        {
            events = eventController.loadDataWithFilterType(type);
            if (events == null)
            {
                MessageBox.Show("No se ha podido cargar la lista de eventos segun la categoria." +
                    "Volviendo a la lista general de eventos!!");
                loadEventsListView();
            }
            else
            {
                loadListListView();
                selected_option = 4;
            }
        }

        private void loadDataWithFilterLocation(String location)
        {
            events = eventController.loadDataWithFilterLocation(location);
            if (events == null)
            {
                MessageBox.Show("No se ha podido cargar la lista de eventos segun la ciudad." +
                    "Volviendo a la lista general de eventos!!");
                loadEventsListView();
            }
            else
            {
                loadListListView();
                selected_option = 3;
            }
        }

        private void loadDataWithFilterLocationType(String location, String type)
        {
            events = eventController.loadDataWithFilter(location, type);
            if (events == null)
            {
                MessageBox.Show("No se ha podido cargar la lista de eventos " +
                    "Volviendo a la lista general de eventos!!");
                loadEventsListView();
            }
            else
            {
                loadListListView();
                selected_option = 5;
            }
        }

        private void consultProfile(object sender, EventArgs e)
        {
            Profile profile = new Profile(user);
            profile.ShowDialog();
        }
        
        private void listViewEvent_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem listItem = listViewEvent.SelectedItems[0];
            String name = listItem.SubItems[0].Text;
            String description = listItem.SubItems[1].Text;
            String city = listItem.SubItems[2].Text;
            String direction = listItem.SubItems[3].Text;
            String date = listItem.SubItems[4].Text;
            String time = listItem.SubItems[5].Text;
            String duration = listItem.SubItems[6].Text;
            int n_participants = Convert.ToInt32(listItem.SubItems[7].Text);
            int n_maxParticipants = Convert.ToInt32(listItem.SubItems[8].Text);
            String type = listItem.SubItems[9].Text;
            int mood = Convert.ToInt32(listItem.SubItems[10].Text);
            int id_user = Convert.ToInt32(listItem.SubItems[11].Text);
            int id_event = Convert.ToInt32(listItem.SubItems[12].Text);
            InfoEvents infoEvents = new InfoEvents(id_event, name, description, city, direction, date,time ,duration, n_participants, n_maxParticipants, type, mood, id_user, user.Id);
            infoEvents.ShowDialog();
            updateListView();
        }

        private void updateListView()
        {
            events = new List<Event>();
            listViewEvent.Items.Clear();
            switch (selected_option)
            {
                case 0:
                    loadEventsListView();
                    break;
                case 1:
                    activitiesRegister();
                    break;
                case 2:
                    listOnePersonActivities();
                    break;
                case 3:
                    loadDataWithFilterLocation(location);
                    break;
                case 4:
                    loadDataWithFilterType(type);
                    break;
                case 5:
                    loadDataWithFilterLocationType(location, type);
                    break;
            }
        }

        private void addEvent(object sender, EventArgs e)
        {
            AddEvents subir = new AddEvents(user);
            subir.ShowDialog();
            selected_option = 2;
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
        
        private void consultGraphicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraficoMood gm = new GraficoMood(user);
            gm.Show();
        }

        private void listOnePersonActivities_Click(object sender, EventArgs e)
        {
            listViewEvent.Items.Clear();
            listOnePersonActivities();
        }

        private void listOnePersonActivities()
        {
            events = eventController.loadOnePersonActivities(user.Id);
            if (events == null)
            {
                MessageBox.Show("No has creado ninguna actividad !!");
                loadEventsListView(); ;
            }
            else
            {
                loadListListView();
                selected_option = 2;
            }
        }

        private void activitiesRegisterOnePerson_Click(object sender, EventArgs e)
        {
            listViewEvent.Items.Clear();
            activitiesRegister();
        }

        private void activitiesRegister()
        {
            events = eventController.loadActivitiesRegisterOnePerson(user.Id);
            if (events == null)
            {
                MessageBox.Show("No estas registrado en ninguna actividad !!");
                loadEventsListView();
            }
            else
            {
                loadListListView();
                selected_option = 1;
            }
        }

        public bool Exit { get => exit; set => exit = value; }
    }
}

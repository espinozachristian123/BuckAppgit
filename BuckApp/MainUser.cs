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
        private string location, type;
        private int selected_option = 0;
        Boolean exit;

        private ListViewItem itm;
        private List<Event> events;
        private List<Categories> categories;

        private EventController eventController;
        private CategoriesController categoriesController;

        User user;

        public MainUser(User user)
        {
            InitializeComponent();
            this.user = user;
            eventController = new EventController();
            categoriesController = new CategoriesController();
        }

        /// <summary>
        /// Load the necessary methods to make that window work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainUser_Load(object sender, EventArgs e)
        {
            hideButtons();
            loadEventsListView();
            loadComboBox();
        }

        /// <summary>
        /// Disable certain buttons if the user being logged in is Admin
        /// since the admin should not do those actions
        /// </summary>
        private void hideButtons()
        {
            if (user.Rol.Equals("admin"))
            {
                consultProfileToolStripMenuItem.Enabled = false;
                consultGraphicToolStripMenuItem.Enabled = false;
                misActividadesToolStripMenuItem.Enabled = false;
                actividadesQueEstoyRegistradoToolStripMenuItem.Enabled = false;
            }
        }

        /// <summary>
        /// Loads the list of events according to the user being logged in
        /// If the user is an administrator, load all available events
        /// If the user is a user, load the events according to their mood
        /// </summary>
        private void loadEventsListView()
        {
            if (user.Rol.Equals("admin"))
            {
                events = eventController.loadAllEventsForAdmin();
                if (events != null)
                {
                    lbTittleFilter.Text = "Todas las actividades";
                    loadListListView();
                }
            }
            else if (user.Rol.Equals("user"))
            {
                events = eventController.loadDataWithFilterMood(user.Id);
                if (events != null)
                {
                    loadListListView();
                }
            }

        }

        /// <summary>
        /// Collect the data you receive from the database and save it in a combo box
        /// </summary>
        private void loadComboBox()
        {
            categories = categoriesController.loadDataComboBox();
            for (int i = 0; i < categories.Count; i++)
            {
                cbCategory.Items.Add(categories[i].Name);
            }
        }

        /// <summary>
        /// Take the list of events previously loaded and put the data of it in the listview
        /// </summary>
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

        /// <summary>
        /// Clear the current data from the field to display the new data.
        /// Take the available filters and according to the filters that exist and the role of the user, show the corresponding events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadListViewWithFilter(object sender, EventArgs e)
        {
            listViewEvent.Items.Clear();
            try
            {
                location = tbCity.Text;
                type = cbCategory.Text;
                if (location.Equals(String.Empty) && type.Equals(String.Empty))
                {
                    lbTittleFilter.Text = "Actividades filtradas por estado de animo";
                    events = eventController.loadDataWithFilterMood(user.Id);
                    if (events != null)
                    {
                        loadListListView();
                    }
                }
                else if (location.Equals(String.Empty))
                {
                    lbTittleFilter.Text = "Actividades filtradas por categoria";
                    if (user.Rol.Equals("admin"))
                    {
                        loadDataWithFilterType(type);
                    }
                    else if (user.Rol.Equals("user"))
                    {
                        loadDataWithFilterTypeAndMood(type, user.Id);
                    }
                }
                else if (type.Equals(String.Empty))
                {
                    lbTittleFilter.Text = "Actividades filtradas por ciudad";
                    if (user.Rol.Equals("admin"))
                    {
                        loadDataWithFilterLocation(location);
                    }
                    else if (user.Rol.Equals("user"))
                    {
                        loadDataWithFilterLocationAndMood(location, user.Id);
                    }
                }
                else
                {
                    lbTittleFilter.Text = "Actividades filtradas por ciudad y categoria";
                    if (user.Rol.Equals("admin"))
                    {
                        loadDataWithFilterLocationType(location, type);
                    }
                    else if (user.Rol.Equals("user"))
                    {
                        loadDataWithFilterLocationTypeAndMood(location, type, user.Id);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar una categoria!!");
            }

        }

        /// <summary>
        /// collects the events according to the type filter and loads them in the listview
        /// If the list is empty, notify the user
        /// </summary>
        /// <param name="type"></param>
        private void loadDataWithFilterType(String type)
        {
            events = eventController.loadDataWithFilterType(type);
            if (events == null)
            {
                MessageBox.Show("No se ha podido cargar la lista de eventos segun la categoria." +
                    "Volviendo a la lista general de eventos!!");
                lbTittleFilter.Text = "Todas las actividades";
                loadEventsListView();
            }
            else
            {
                loadListListView();
                selected_option = 4;
            }
        }

        /// <summary>
        /// collects the events according to the type filter + the user's mood
        /// and load them into the listView
        /// If the list is empty, notify the user
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id_user"></param>
        private void loadDataWithFilterTypeAndMood(String type, int id_user)
        {
            events = eventController.loadDataWithFilterTypeAndMood(type, id_user);
            if (events == null)
            {
                MessageBox.Show("No se ha podido cargar la lista de eventos segun la categoria." +
                    "Volviendo a la lista general de eventos!!");
                lbTittleFilter.Text = "Actividades filtradas por estado de animo";
                loadEventsListView();
            }
            else
            {
                loadListListView();
                selected_option = 4;
            }
        }

        /// <summary>
        /// collects the events according to the location and loads them in the listview
        /// If the list is empty, notify the user
        /// </summary>
        /// <param name="location"></param>
        private void loadDataWithFilterLocation(String location)
        {
            events = eventController.loadDataWithFilterLocation(location);
            if (events == null)
            {
                MessageBox.Show("No se ha podido cargar la lista de eventos segun la ciudad." +
                    "Volviendo a la lista general de eventos!!");
                lbTittleFilter.Text = "Todas las actividades";
                loadEventsListView();
            }
            else
            {
                loadListListView();
                selected_option = 3;
            }
        }

        /// <summary>
        /// collects the events according to the location + the mood of the user and loads them in the listview
        /// If the list is empty, notify the user
        /// </summary>
        /// <param name="location"></param>
        /// <param name="id_user"></param>
        private void loadDataWithFilterLocationAndMood(String location, int id_user)
        {
            events = eventController.loadDataWithFilterLocationAndMood(location, id_user);
            if (events == null)
            {
                MessageBox.Show("No se ha podido cargar la lista de eventos segun la ciudad." +
                    "Volviendo a la lista general de eventos!!");
                lbTittleFilter.Text = "Actividades filtradas por estado de animo";
                loadEventsListView();
            }
            else
            {
                loadListListView();
                selected_option = 3;
            }
        }

        /// <summary>
        /// collects the events according to the location, type and mood of the user and loads them in the listview
        /// If the list is empty, notify the user
        /// </summary>
        /// <param name="location"></param>
        /// <param name="type"></param>
        /// <param name="id_user"></param>
        private void loadDataWithFilterLocationTypeAndMood(String location, String type, int id_user)
        {
            events = eventController.loadDataWithFilterAndMood(location, type, id_user);
            if (events == null)
            {
                MessageBox.Show("No se ha podido cargar la lista de eventos " +
                    "Volviendo a la lista general de eventos!!");
                lbTittleFilter.Text = "Actividades filtradas por estado de animo";
                loadEventsListView();
            }
            else
            {
                loadListListView();
                selected_option = 5;
            }
        }

        /// <summary>
        /// collects the events according to the location + type and loads them in the listview
        /// If the list is empty, notify the user
        /// </summary>
        /// <param name="location"></param>
        /// <param name="type"></param>
        private void loadDataWithFilterLocationType(String location, String type)
        {
            events = eventController.loadDataWithFilter(location, type);
            if (events == null)
            {
                MessageBox.Show("No se ha podido cargar la lista de eventos " +
                    "Volviendo a la lista general de eventos!!");
                lbTittleFilter.Text = "Todas las actividades";
                loadEventsListView();
            }
            else
            {
                loadListListView();
                selected_option = 5;
            }
        }

        /// <summary>
        /// When the user presses the button, it redirects the user to the next window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void consultProfile(object sender, EventArgs e)
        {
            Profile profile = new Profile(user);
            profile.ShowDialog();
        }

        /// <summary>
        /// Collect the data of the event that we select to display it later in the following window
        /// When the window is opened later it closes, if there is any modification of any event update
        /// the listView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            String mood = listItem.SubItems[10].Text;
            int id_user = Convert.ToInt32(listItem.SubItems[11].Text);
            int id_event = Convert.ToInt32(listItem.SubItems[12].Text);
            InfoEvents infoEvents = new InfoEvents(id_event, name, description, city, direction, date, time, duration, n_participants, n_maxParticipants, type, mood, id_user, user);
            infoEvents.ShowDialog();
            updateListView();
        }

        /// <summary>
        /// method to stay in the list of events that the user is currently.
        /// If the user is in their activities and deletes one, the updated list that will be shown later will be this
        /// </summary>
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
                    loadEventsListView();
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

        /// <summary>
        /// It changes of window when the user presses the button to add event.
        /// when the window closes it updates the list view with the new event created
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addEvent(object sender, EventArgs e)
        {
            AddEvents subir = new AddEvents(user);
            subir.ShowDialog();
            selected_option = 2;
            lbTittleFilter.Text = "Actividades filtradas por estado de animo";
            updateListView();
        }

        /// <summary>
        /// It changes of window when the user presses the button to consult grafic.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void consultGraphicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraficoMood gm = new GraficoMood(user);
            gm.Show();
        }

        /// <summary>
        /// Clear the listview to show the events that a person has created
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listOnePersonActivities_Click(object sender, EventArgs e)
        {
            listViewEvent.Items.Clear();
            lbTittleFilter.Text = "Actividades creadas por mi";
            listOnePersonActivities();
        }

        /// <summary>
        /// Take the events that a person has created and show them
        /// If the list is empty, the program notifies you
        /// </summary>
        private void listOnePersonActivities()
        {
            events = eventController.loadOnePersonActivities(user.Id);
            if (events == null)
            {
                MessageBox.Show("No has creado ninguna actividad !!");
                lbTittleFilter.Text = "Actividades filtradas por estado de animo";
                loadEventsListView(); ;
            }
            else
            {
                loadListListView();
                selected_option = 2;
            }
        }

        /// <summary>
        /// Clear the listview to show the events that a person is registered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void activitiesRegisterOnePerson_Click(object sender, EventArgs e)
        {
            listViewEvent.Items.Clear();
            lbTittleFilter.Text = "Actividades que estoy registrado";
            activitiesRegister();
        }

        /// <summary>
        /// Take the events that a person is registered and show them
        /// If the list is empty, the program notifies you
        /// </summary>
        private void activitiesRegister()
        {
            events = eventController.loadActivitiesRegisterOnePerson(user.Id);
            if (events == null)
            {
                MessageBox.Show("No estas registrado en ninguna actividad !!");
                lbTittleFilter.Text = "Actividades filtradas por estado de animo";
                loadEventsListView();
            }
            else
            {
                loadListListView();
                selected_option = 1;
            }
        }

        /// <summary>
        /// When the user presses the button, the program asks if you agree.
        /// If the user answers yes, the program returns to the login window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
    }
}

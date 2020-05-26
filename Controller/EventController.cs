using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controller
{
    public class EventController
    {
        private EventDAO eventDao;
        private List<Event> events;

        public EventController()
        {
            eventDao = new EventDAO();
            events = new List<Event>();
        }
        /// <summary>
        /// check the moood of user and then show the activitis depend of mood of user.
        /// </summary>
        /// <param name="id_user"></param>
        /// <returns> events list Filter</returns>
        public List<Event> loadDataWithFilterMood(int id_user)
        {
            events = eventDao.loadDataWithFilterMood(id_user);
            return events;
        }
        /// <summary>
        /// load all events in the principal screen
        /// </summary>
        /// <returns>events or null if not are events</returns>
        public List<Event> loadAllEventsForAdmin()
        {
            return eventDao.loadAllEventsForAdmin();
        }
        /// <summary>
        /// filter the activitis by location or type of event
        /// </summary>
        /// <param name="location"> value textBox </param>
        /// <param name="type"> value comboBox </param>
        /// <returns>event if are exist or null if are not exist</returns>
        public List<Event> loadDataWithFilter(String location, String type)
        {
            events = eventDao.loadDataWithFilter(location,type);
            return events;
        }
        /// <summary>
        /// load events with category or location with mood of user
        /// </summary>
        /// <param name="location"> value textBox </param>
        /// <param name="type"> value comboBox </param>
        /// <param name="id_user"> id user login</param>
        /// <returns>event if are exist or null if are not exist</returns>
        public List<Event> loadDataWithFilterAndMood(String location, String type, int id_user)
        {
            events = eventDao.loadDataWithFilterAndMood(location, type, id_user);
            return events;
        }

        /// <summary>
        /// load the activitis depend of location of event
        /// </summary>
        /// <param name="location"> value textBox </param>
        /// <returns>event if are exist or null if are not exist</returns>
        public List<Event> loadDataWithFilterLocation(String location)
        {
            events = eventDao.loadDataWithFilterLocation(location);
            return events;
        }
        /// <summary>
        /// load the activities by location and mood by user
        /// </summary>
        /// <param name="location">value of textbox</param>
        /// <param name="id_user">id user login</param>
        /// <returns>event if are exist or null if are not exist</returns>
        public List<Event> loadDataWithFilterLocationAndMood(String location, int id_user)
        {
            events = eventDao.loadDataWithFilterLocationAndMood(location, id_user);
            return events;
        }
        /// <summary>
        /// load the activitis depend of type
        /// </summary>
        /// <param name="type">value of combobox</param>
        /// <returns>event if are exist or null if are not exist</returns>
        public List<Event> loadDataWithFilterType(String type)
        {
            events = eventDao.loadDataWithFilterType(type);
            return events;
        }
        /// <summary>
        /// load the activitis depend of type and mood
        /// </summary>
        /// <param name="type"> value of combobox</param>
        /// <param name="id_user">id user of login</param>
        /// <returns>event if are exist or null if are not exist</returns>
        public List<Event> loadDataWithFilterTypeAndMood(String type, int id_user)
        {
            events = eventDao.loadDataWithFilterTypeAndMood(type, id_user);
            return events;
        }
        /// <summary>
        /// loads the activities that a user has created
        /// </summary>
        /// <param name="id_user">id user of login</param>
        /// <returns>event if are exist or null if are not exist</returns>
        public List<Event> loadOnePersonActivities(int id_user)
        {
            events = eventDao.loadOnePersonActivities(id_user);
            return events;
        }
        /// <summary>
        /// load activtis thah user are registered
        /// </summary>
        /// <param name="id_user"> id user login </param>
        /// <returns>event if are exist or null if are not exist</returns>
        public List<Event> loadActivitiesRegisterOnePerson(int id_user)
        {
            return eventDao.loadActivitiesRegisterOnePerson(id_user);
        }
        /// <summary>
        /// check the user are not registered in the activity
        /// </summary>
        /// <param name="id_event">id of event</param>
        /// <param name="id_user">od user of login</param>
        /// <returns>true if are registered or false if are not registered</returns>
        public Boolean checkRegister(int id_event, int id_user)
        {
            return eventDao.checkRegister(id_event, id_user);
        }
        /// <summary>
        /// register the user in that event
        /// </summary>
        /// <param name="fecha">value of datapicker</param>
        /// <param name="id_event">value of id event</param>
        /// <param name="id_user">id user of login</param>
        /// <returns>true if are registered in event or false in case of error</returns>
        public Boolean registerEvent(DateTime fecha, int id_event, int id_user, int n_participants)
        {
            return eventDao.registerEvent(fecha, id_event, id_user, n_participants);
        }
        /// <summary>
        /// delete the user when he dont want take a part in event
        /// </summary>
        /// <param name="id_event">value selected in listbox</param>
        /// <param name="id_user">id user of login</param>
        /// <returns>true if correctly or false in case of error</returns>
        public Boolean deleteRegisterEvent(int id_event, int id_user, int n_participants)
        {
            return eventDao.deleteRegisterEvent(id_event, id_user, n_participants);
        }
        /// <summary>
        /// add a event 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="city"></param>
        /// <param name="direction"></param>
        /// <param name="date"></param>
        /// <param name="duration"></param>
        /// <param name="num_participants"></param>
        /// <param name="num_participants_max"></param>
        /// <param name="type"></param>
        /// <param name="mood"></param>
        /// <param name="id_user"></param>
        /// <returns>true if the params are correctly or false in case of error</returns>
        public Boolean addEvent(string name, string description, string city, string direction, string date, string duration, int num_participants, int num_participants_max, string type, int mood, int id_user)
        {
            Event newEvent = new Event(name, description, city, direction, date, duration, num_participants, num_participants_max, type, mood, id_user);
            return eventDao.addEvent(newEvent);
        }
        /// <summary>
        /// modify the event
        /// </summary>
        /// <param name="name"> value textBox</param>
        /// <param name="description"> value textBox </param>
        /// <param name="city"> value textBox</param>
        /// <param name="direction"> value textBox</param>
        /// <param name="date">value textBox </param>
        /// <param name="duration"> value textBox</param>
        /// <param name="num_max"> value textBox </param>
        /// <param name="type"> value comboBox</param>
        /// <param name="mood">value comboBox</param>
        /// <param name="id">id event</param>
        /// <returns>true if modify are correctly or false in case of error</returns>
        public Boolean modifyEvent(string name, string description, string city, string direction, string date, string duration, int num_max, string type, int mood, int id)
        {
            Event eventModify = new Event(id,name, description, city, direction, date, duration, num_max, type, mood);
            return eventDao.modifyEvent(eventModify);
        }
        /// <summary>
        /// delete the event
        /// </summary>
        /// <param name="id"> id event </param>
        /// <returns>true if delete are succesfully or false in case of error</returns>
        public Boolean deleteEvent(int id)
        {
            Boolean flag = eventDao.deleteEvent(id);
            return flag;

        }
        /// <summary>
        /// check the character is only a number
        /// </summary>
        /// <param name="pe"></param>
        public void validateNumbers(KeyPressEventArgs pe)
        {
            if (char.IsDigit(pe.KeyChar))
            {
                pe.Handled = false;
            }
            else if (char.IsControl(pe.KeyChar))
            {
                pe.Handled = true;
            }
            else
            {
                pe.Handled = true;
            }
        }
        
    }
}

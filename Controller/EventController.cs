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
        /// <returns>events</returns>
        public List<Event> loadDataWithFilterMood(int id_user)
        {
            events = eventDao.loadDataWithFilterMood(id_user);
            return events;
        }
        /// <summary>
        /// load all events in the principal scren
        /// </summary>
        /// <returns>events or null if not are events</returns>
        public List<Event> loadAllEventsForAdmin()
        {
            return eventDao.loadAllEventsForAdmin();
        }
        /// <summary>
        /// filter the activitis by location or type of event
        /// </summary>
        /// <param name="location"></param>
        /// <param name="type"></param>
        /// <returns>event if are exist or null if are not exist</returns>
        public List<Event> loadDataWithFilter(String location, String type)
        {
            events = eventDao.loadDataWithFilter(location,type);
            return events;
        }
        /// <summary>
        /// load events with category or location with mood of user
        /// </summary>
        /// <param name="location"></param>
        /// <param name="type"></param>
        /// <param name="id_user"></param>
        /// <returns>event if are exist or null if are not exist</returns>
        public List<Event> loadDataWithFilterAndMood(String location, String type, int id_user)
        {
            events = eventDao.loadDataWithFilterAndMood(location, type, id_user);
            return events;
        }

        /// <summary>
        /// load the activitis depend of location of event
        /// </summary>
        /// <param name="location"></param>
        /// <returns>event if are exist or null if are not exist</returns>
        public List<Event> loadDataWithFilterLocation(String location)
        {
            events = eventDao.loadDataWithFilterLocation(location);
            return events;
        }
        /// <summary>
        /// load the activities by location and mood by user
        /// </summary>
        /// <param name="location"></param>
        /// <param name="id_user"></param>
        /// <returns>event if are exist or null if are not exist</returns>
        public List<Event> loadDataWithFilterLocationAndMood(String location, int id_user)
        {
            events = eventDao.loadDataWithFilterLocationAndMood(location, id_user);
            return events;
        }

        public List<Event> loadDataWithFilterType(String type)
        {
            events = eventDao.loadDataWithFilterType(type);
            return events;
        }

        public List<Event> loadDataWithFilterTypeAndMood(String type, int id_user)
        {
            events = eventDao.loadDataWithFilterTypeAndMood(type, id_user);
            return events;
        }

        public List<Event> loadOnePersonActivities(int id_user)
        {
            events = eventDao.loadOnePersonActivities(id_user);
            return events;
        }

        public List<Event> loadActivitiesRegisterOnePerson(int id_user)
        {
            return eventDao.loadActivitiesRegisterOnePerson(id_user);
        }

        public Boolean checkRegister(int id_event, int id_user)
        {
            return eventDao.checkRegister(id_event, id_user);
        }

        public Boolean registerEvent(DateTime fecha, int id_event, int id_user)
        {
            return eventDao.registerEvent(fecha, id_event, id_user);
        }

        public Boolean updateNumMax(int num_participants, int id)
        {
            return eventDao.updateNumParticipants(num_participants, id);
        }

        public Boolean deleteRegisterEvent(int id_event, int id_user)
        {
            return eventDao.deleteRegisterEvent(id_event, id_user);
        }

        public Boolean addEvent(string name, string description, string city, string direction, string date, string duration, int num_participants, int num_participants_max, string type, int mood, int id_user)
        {
            Event newEvent = new Event(name, description, city, direction, date, duration, num_participants, num_participants_max, type, mood, id_user);
            return eventDao.addEvent(newEvent);
        }

        public Boolean modifyEvent(string name, string description, string city, string direction, string date, string duration, int num_max, string type, int mood, int id)
        {
            Event eventModify = new Event(id,name, description, city, direction, date, duration, num_max, type, mood);
            return eventDao.modifyEvent(eventModify);
        }

        public Boolean deleteEvent(int id)
        {
            Boolean flag = eventDao.deleteEvent(id);
            return flag;

        }
        
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

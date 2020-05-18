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
        private List<String> datosComboBox;

        public EventController()
        {
            eventDao = new EventDAO();
            events = new List<Event>();
        }

        public List<Event> cargarDatos()
        {
            events = eventDao.cogerDatos();
            return events;
        }

        public List <String> cargarDatosComboBox()
        {
            datosComboBox = eventDao.cogerDatosComboBox();
            return datosComboBox;
        }

        public List<Event> cargarDatosConFiltro(String location, String type)
        {
            events = eventDao.cogerDatosConFiltroLugarTipo(location,type);
            return events;
        }

        public List<Event> cargarDatosConFiltroCiudad(String location)
        {
            events = eventDao.cogerDatosConFiltroCiudad(location);
            return events;
        }

        public List<Event> cargarDatosConFiltroCategoria(String type)
        {
            events = eventDao.cogerDatosConFiltroCategoria(type);
            return events;
        }

        public List<Event> cargarDatosUnaPersona(int id_user)
        {
            events = eventDao.cogerActividadesDeUnaPersona(id_user);
            return events;
        }

        public Boolean addEvent(string name, string description, string location, string date, int num_participants, int num_participants_max, string type, int id_user)
        {
            return eventDao.addEvent(name,description,location,date,num_participants,num_participants_max,type,id_user);
        }

        public Boolean registerEvent(string fecha, int id_event, int id_user)
        {
            return eventDao.registerEvent(fecha, id_event, id_user);
        }

        public Boolean deleteRegisterEvent(int id_event, int id_user)
        {
            return eventDao.deleteRegisterEvent(id_event, id_user);
        }

        public Boolean modifyEvent(String name, String description, String location, DateTime date, int num_max, String type, int id)
        {
            return eventDao.modifyEvent(name,description,location,date,num_max,type,id);
        }

        public Boolean deleteEvent(int id)
        {
            Boolean flag = eventDao.deleteEvent(id);
            return flag;

        }

        public Boolean updateNumMax(int num_participants, int id)
        {
            return eventDao.updateNumParticipants(num_participants, id);
        }

        public Boolean checkRegister(int id_event, int id_user)
        {
            return eventDao.checkRegister(id_event,id_user);
        }

        public void validarnumeros(KeyPressEventArgs pe)
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

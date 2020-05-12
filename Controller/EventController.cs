using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<Event> cargarDatosUnaPersona(int id_user)
        {
            events = eventDao.cogerActividadesDeUnaPersona(id_user);
            return events;
        }
    }
}

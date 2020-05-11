using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Event
    {
        private int id;
        private String name;
        private String description;
        private String location;
        private String date;
        private String type;
        private int numMaxParticipantes;
        private int id_user;

        public Event(int id, String name, String description, String location, String date,
            String type, int numMaxParticipantes)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.location = location;
            this.date = date;
            this.type = type;
            this.numMaxParticipantes = numMaxParticipantes;
            //this.id_user = id_user;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Location { get => location; set => location = value; }
        public string Date { get => date; set => date = value; }
        public string Type { get => type; set => type = value; }
        public string Type1 { get => type; set => type = value; }
        public int NumMaxParticipantes { get => numMaxParticipantes; set => numMaxParticipantes = value; }
        public int Id_user { get => id_user; set => id_user = value; }
    }
}

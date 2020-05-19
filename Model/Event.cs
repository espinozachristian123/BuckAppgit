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
        private String city;
        private String direction;
        private String date;
        private String duration;
        private String type;
        private int numParticipants;
        private int numMaxParticipantes;
        private int id_user;
        private int mood;

        public Event(int id, String name, String description, String city, String direction, String date, String duration, int numParticipants,
         int numMaxParticipantes, String type, int mood, int id_user)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.city = city;
            this.direction = direction;
            this.date = date;
            this.duration = duration;
            this.numParticipants = numParticipants;
            this.numMaxParticipantes = numMaxParticipantes;
            this.type = type;
            this.mood = mood;
            this.id_user = id_user;
        }

        public Event(string name, string description, string city, string direction, string date, 
            string duration, int num_participants, int num_participants_max, string type, int mood, int id_user)
        {
            this.name = name;
            this.description = description;
            this.city = city;
            this.direction = direction;
            this.date = date;
            this.duration = duration;
            this.numParticipants = num_participants;
            this.numMaxParticipantes = num_participants_max;
            this.type = type;
            this.mood = mood;
            this.id_user = id_user;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string City { get => city; set => city = value; }
        public string Date { get => date; set => date = value; }
        public string Type { get => type; set => type = value; }
        public int NumMaxParticipantes { get => numMaxParticipantes; set => numMaxParticipantes = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        public int NumParticipants { get => numParticipants; set => numParticipants = value; }
        public String Duration { get => duration; set => duration = value; }
        public string Direction { get => direction; set => direction = value; }
        public int Mood { get => mood; set => mood = value; }
    }
}

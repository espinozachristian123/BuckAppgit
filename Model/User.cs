using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        private int id;
        private String username;
        private String password;
        private String rol;
        private String email;

        public User()
        {
            
        }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public User(int id, string username, string password, string rol, string email)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.rol = rol;
            this.email = email;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Rol { get => rol; set => rol = value; }
        public string Email { get => email; set => email = value; }
        public int Id { get => id; set => id = value; }

        public String userToString()
        {
            return "User {id:" + Id + "username: " + Username + "password: " + Password + "rol: " + Rol + "email: " + email + "}";
        }
    }
}

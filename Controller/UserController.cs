using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class UserController
    {
        private UserDAO model;
        private User user;

        public UserController()
        {
            model = new UserDAO();
        }
        
        public String validateUser(String username, String password)
        {
            String rol = String.Empty;
            User userValidate = new User(username,password);
            Boolean flag = model.loginUser(userValidate);
            if (flag)
            {
                if (model.Rol.Equals("admin"))
                {
                    rol = "admin";
                }
                else if (model.Rol.Equals("user"))
                {
                    rol = "user";
                    user = new User(model.Id, username, password, model.Rol, model.Email);
                }
            }
            else
            {
                rol = "";
            }

            return rol;
        }

        public User User { get => user; set => user = value; }





    }
}

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
        
        public User validateUser(String username, String password)
        {
            User userValidate = new User(username,password);
            Boolean flag = model.loginUser(userValidate);
            if (flag)
            {
                user = new User(model.Id, username, password, model.Rol, model.Email);
            }
            else
            {
                user = null;
            }

            return user;
        }

        public Boolean validateRegister(String username, String password, String email)
        {
            Boolean flag = model.register(username,password,email);
            return flag;
        }

        public bool modifyUser(string newName, string newPass, string newEmail, int id_user)
        {
            return model.modifyUser(newName, newPass, newEmail,id_user);
        }
        
        public bool sameName(string newName)
        {
            return model.UserEquals(newName);
        }

        public Boolean sameEmail(String email)
        {
            return model.takeUser(email);
        }

        public bool modifyNames(string newName, int id_user)
        {
            return model.modifyName(newName, id_user);
        }

        public bool modifyEmail(string newEmail, int id)
        {
            return model.modifyEmail(newEmail, id);
        }

        public bool modifyPass(string newPass, int id)
        {
            return model.modifyPassword(newPass, id);
        }

        public User User { get => user; set => user = value; }

    }
}

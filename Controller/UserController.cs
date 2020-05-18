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

        public bool modifiuser(string newName, string newPass, string newEmail, int id_user)
        {
            return model.modifyUser(newName, newPass, newEmail,id_user);
        }
        public bool modifynames(string newName,int id_user)
        {
            return model.modifyname(newName,id_user);
        }

        public Boolean sameEmail(String email)
        {
            return model.takeUser(email);
        }

        public User User { get => user; set => user = value; }

        public bool sameName(string newName)
        {
            return model.UserEquals(newName);
        }

        public bool modifycorreo(string newEmail, int id)
        {
            return model.modifyemail(newEmail, id);
        }

        public bool modifypass(string newPass, int id)
        {
            return model.modifypassword(newPass, id);
        }
    }
}

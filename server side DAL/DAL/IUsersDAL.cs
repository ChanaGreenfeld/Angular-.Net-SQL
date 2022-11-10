using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;

namespace DAL
{
    public interface IUsersDAL
    {
        public List<UsersTbl> GetAll();
        public UsersTbl GetUserById(int id);
        public UsersTbl GetUserByPassword(string password);
        public List<UsersTbl> AddUser(UsersTbl newUser);
        public List<UsersTbl> UpDateUser(int id, UsersTbl UpDateUser);
        public List<UsersTbl> DeleteUser(int id);
    }
}

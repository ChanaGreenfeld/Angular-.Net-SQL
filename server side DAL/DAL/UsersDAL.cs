using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;
using System.Linq;

namespace DAL
{
    public class UsersDAL : IUsersDAL
    {

        Toys_dbContext use;
        public UsersDAL(Toys_dbContext user)
        {
            this.use = user;
        }
       
        public List<UsersTbl> AddUser(UsersTbl newUser)
        {
            use.UsersTbls.Add(newUser);
            use.SaveChanges();
            return use.UsersTbls.ToList();
        }

        public List<UsersTbl> DeleteUser(int id)
        {
            use.UsersTbls.Remove(use.UsersTbls.Find(id));
            use.SaveChanges();
            return use.UsersTbls.ToList();
        }

        public List<UsersTbl> GetAll()
        {
            return use.UsersTbls.ToList();
        }

        public UsersTbl GetUserById(int id)
        {
            return use.UsersTbls.Find(id);
        }

        public UsersTbl GetUserByPassword(string password)
        {
            return use.UsersTbls.ToList().Find(x=>x.Passworduser==password);
        }

        public List<UsersTbl> UpDateUser(int id, UsersTbl UpDateUser)
        {
            UsersTbl us = use.UsersTbls.Find(id);
            us.Nameuser = UpDateUser.Nameuser;
            us.Passworduser = UpDateUser.Passworduser;
            us.Phoneuser = UpDateUser.Phoneuser;
            us.Addressuser = UpDateUser.Addressuser;
            use.SaveChanges();
            return use.UsersTbls.ToList();
        }

       
    }
}

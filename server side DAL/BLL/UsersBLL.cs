using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using DTO;
using DAL;
using AutoMapper;

namespace BLL
{
    public class UsersBLL : IUsersBLL
    {
        IUsersDAL user;
        IMapper imapper;
        public UsersBLL(IUsersDAL users)
        {
            this.user = users;
            var con = new MapperConfiguration(co => co.AddProfile<Navigation>());
            imapper = con.CreateMapper();
        }

        public List<UsersDTO> AddUser(UsersDTO newUser)
        {
            UsersTbl use = imapper.Map<UsersDTO, UsersTbl>(newUser);
            List<UsersTbl> users = user.AddUser(use);
            return imapper.Map<List<UsersTbl>, List<UsersDTO>>(users);
        }

        public List<UsersDTO> DeleteUser(int id)
        {
            List<UsersTbl> use = user.DeleteUser(id);
            return imapper.Map<List<UsersTbl>, List<UsersDTO>>(use);
        }

        public List<UsersDTO> GetAll()
        {
            List<UsersTbl> listuse = user.GetAll();
            return imapper.Map<List<UsersTbl>, List<UsersDTO>>(listuse);
        }

        public UsersDTO GetUserById(int id)
        {
            UsersTbl use = user.GetUserById(id);
            return imapper.Map<UsersTbl, UsersDTO>(use);
        }

        public UsersDTO GetUserByPassword(string password)
        {
            UsersTbl use = user.GetUserByPassword(password);
            return imapper.Map<UsersTbl, UsersDTO>(use);
        }

        public List<UsersDTO> UpDateUser(int id, UsersDTO UpDateUser)
        {
            UsersTbl d = imapper.Map<UsersDTO, UsersTbl>(UpDateUser);
            List<UsersTbl> use = user.UpDateUser(id, d);
            return imapper.Map<List<UsersTbl>, List<UsersDTO>>(use);
        }
    }
}

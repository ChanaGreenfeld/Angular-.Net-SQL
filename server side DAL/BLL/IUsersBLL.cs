using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using DTO;
using AutoMapper;

namespace BLL
{
    public interface IUsersBLL
    {
        public List<UsersDTO> GetAll();
        public UsersDTO GetUserById(int id);
        public UsersDTO GetUserByPassword(string password);
        public List<UsersDTO> AddUser(UsersDTO newUser);
        public List<UsersDTO> UpDateUser(int id, UsersDTO UpDateUser);
        public List<UsersDTO> DeleteUser(int id);
    }
}

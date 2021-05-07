﻿using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackingSystem.BLL.DTO;

namespace TaskTrackingSystem.BLL
{
    public interface IUserService : IDisposable
    {
        IEnumerable<UserDTO> GetAllUsers();
        UserDTO GetUser(int? id);
        IEnumerable<UserDTO> Find(Func<UserDTO, bool> func);
        UserDTO GetUser(string login);
        void AddUser(UserDTO user, string password);
        void EditUser(UserDTO userE);
        void DeleteUser(UserDTO user);
        void AddToProject(UserDTO user, ProjectDTO project);
    }
}
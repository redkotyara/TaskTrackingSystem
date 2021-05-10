﻿using System;
using System.Collections.Generic;
using System.Linq;
using TaskTrackingSystem.DAL.Models;
using TaskTrackingSystem.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TaskTrackingSystem.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public DatabaseContext db { get; set; }

        public UserRepository(DatabaseContext context)
        {
            db = context;
        }

        public void Create(User item)
        {
            db.Users.Add(item);
            db.SaveChanges();
        }

        public void Delete(User item)
        {
            db.Users.Remove(item);
            db.SaveChanges();
        }

        public void Edit(User item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public User Get(string name)
        {
            if (name == null)
                return null;
            else
                return db.Users.Find(name);
        }

        public IEnumerable<User> GetAll() => db.Users.Include(x => x.Projects);
    }
}

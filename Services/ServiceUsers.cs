﻿using Microsoft.EntityFrameworkCore;
using Services.Models;

namespace Services.Services
{
    public interface IServiceUsers
    {
        UserContext? Context { get; set; }

        public User? Create(User? user);
        public IEnumerable<User?> Read();
        public User? Update(User? user);
        public bool Delete(int id);
        public User? GetUserById(int id);
    }
    public class ServiceUsers : IServiceUsers
    {
        public UserContext? Context { get; set; }

        public User? Create(User? user)
        {
            Context?.Users.Add(user);
            Context.SaveChanges();
            return user;
        }

        public bool Delete(int id)
        {
            try
            {
                Context.Users.Remove(Context?.Users.Find(id));
                Context?.SaveChanges();
                return true;
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public User? GetUserById(int id)
        {
            return Context?.Users.Find(id);
        }

        public IEnumerable<User>? Read()
        {
            return Context?.Users.ToList();
        }

        public User? Update(User? user)
        {
            Context.Entry(user).State = EntityState.Modified;
            Context?.SaveChanges();
            return user;
        }
    }
}

using InstaMockApp.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaMockApp.Services
{
    class UserService
    {
        public List<User> _userList = new List<User>
            {
                new User {Id = 1, Name = "hey let's talk", Description = "hey let's talk"},
                new User {Id = 2, Name = "hey let's talk", Description = "hey let's talk"},
                new User {Id = 3, Name = "hey let's talk", Description = "hey let's talk"},
                new User {Id = 4, Name = "hey let's talk", Description = "hey let's talk"},
                new User {Id = 5, Name = "hey let's talk", Description = "hey let's talk"},
                new User {Id = 6, Name = "hey let's talk", Description = "hey let's talk"},
                new User {Id = 7, Name = "hey let's talk", Description = "hey let's talk"},
                new User {Id = 8, Name = "hey let's talk", Description = "hey let's talk"},
                new User {Id = 9, Name = "hey let's talk", Description = "hey let's talk"},

            };

        public User GetUser(int userId)
        {
            return _userList.SingleOrDefault(u => u.Id == userId);
        }
    }
}


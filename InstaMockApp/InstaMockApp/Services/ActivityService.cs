using InstaMockApp.Modals;
using System.Collections.Generic;

namespace InstaMockApp.Services
{
    class ActivityService
    {
        public IEnumerable<Activity> GetActivities()
        {
            return new List<Activity>
            {
                new Activity {UserId = 1, Description = "hey let's talk"},
                new Activity {UserId = 2, Description = "hey let's talk"},
                new Activity {UserId = 3, Description = "hey let's talk"},
                new Activity {UserId = 4, Description = "hey let's talk"},
                new Activity {UserId = 5, Description = "hey let's talk"},
                new Activity {UserId = 6, Description = "hey let's talk"},
                new Activity {UserId = 7, Description = "hey let's talk"},
                new Activity {UserId = 8, Description = "hey let's talk"},
                new Activity {UserId = 9, Description = "hey let's talk"},

            };
        }
    }
}

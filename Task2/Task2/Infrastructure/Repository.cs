using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.Infrastructure
{
    public static class Repository
    {
        private static int currentId;

        public static List<User> Users { get; } = new List<User>();

        public static async Task Add(User user)
        {           
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
                user.Id = ++currentId;
                Users.Add(user);
            });
        }

        public static void Delete(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                Users.Remove(user);
            }          
        }
    }
}
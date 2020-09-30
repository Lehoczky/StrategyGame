using System.Collections.Generic;
using backend.Models;

namespace backend.Data
{
    public class MockUserRepository : IUserRepository
    {
        public IEnumerable<User> GetAllUsers()
        {
            return new List<User> {
                new User{Id=1, Name="MockUser", Password="asd"},
                new User{Id=2, Name="MockUser2", Password="asdasd"},
                new User{Id=3, Name="MockUser3", Password="dsa"},
            };
        }

        public User GetUserById(int id)
        {
            return new User{Id=1, Name="MockUser", Password="asd"};
        }
    }
}
using System.Collections.Generic;
using backend.Models;

namespace backend.Data
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
    }
}
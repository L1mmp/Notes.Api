using Notes.Domian.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domian.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<int> Add(User user);
        List<User> GetAll();
        User GetById(int id);
    }
}

using AutoMapper;
using Notes.DataAccess.DataAccess;
using Notes.Domian.Models;
using Notes.Domian.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        ApplicationDbContext _dbContext;
        IMapper _mapper;

        public UserRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _dbContext = applicationDbContext;
            _mapper = mapper;
        }

        public List<User> GetAll()
        {
            var users = _dbContext.Users.ToList();
            List<User> _users = new List<User>();   

            foreach (var user in users)
            {
                _users.Add(_mapper.Map<User>(user));
            }
            return _users;
        }

        public User GetById(int id)
        {
           return _mapper.Map<User>(_dbContext.Users.Find(id));
        }

        public async Task<int> Add(User user)
        {
            var _user = _mapper.Map<Entites.User>(user);
            var result = await _dbContext.Users.AddAsync(_user);

            await _dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }
    }
}

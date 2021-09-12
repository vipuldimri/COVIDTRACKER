using Entities.DTO;
using Entities.Models;
using Interfaces;
using System.Collections.Generic;
using System.Linq;
namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users;
        private int MaxId = 0;

        public UserRepository()
        {
            _users = new List<User>();
        }

        public int RegisterNormalUser(NormalUser user)
        {
            int id = 0;
            if (MaxId == 0)
                id = 1;
            else
                id = MaxId + 1;

            user.UserId = id;
            _users.Add(user);
            MaxId++;
            return id;
        }

        public int RegisterHealthWorkerUser(HealthWorker user)
        {
            int id = 0;
            if (MaxId == 0)
                id = 1;
            else
                id = MaxId + 1;
            user.UserId = id;
            _users.Add(user);
            MaxId++;
            return id;
        }

        public bool CheckUserByPhone(string PhoneNo)
        {
            var user = _users.SingleOrDefault(x => x.PhoneNo == PhoneNo);
            if (user == null)
                return false;
            else
                return true;
        }

        public User GetUserById(int UserId)
        {
           return  _users.SingleOrDefault(x => x.UserId == UserId);
        }

        public void UpdateUserResult(int userId , string result)
        {
            var user = _users.SingleOrDefault(x => x.UserId == userId);
            user.Result = result;
        }
    }
}

using Entities.DTO;
using Entities.Models;

namespace Interfaces
{
    public interface IUserRepository
    {
        int RegisterNormalUser(NormalUser user);
        int RegisterHealthWorkerUser(HealthWorker user);
        bool CheckUserByPhone(string PhoneNo);
        User GetUserById(int UserId);
        void UpdateUserResult(int userId, string result);
    }
}

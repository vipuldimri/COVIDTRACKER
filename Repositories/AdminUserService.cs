using Entities;
using Entities.DTO;
using Entities.Models;
using Interfaces;

namespace Repositories
{
    public class AdminUserService : IAdminUserService
    {
        private readonly IUserRepository _userRepository;
        public AdminUserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int Register(HealthWorker healthworker)
        {
            if (_userRepository.CheckUserByPhone(healthworker.PhoneNo))
            {
                throw new BussinessException("Phone no already registered");
            }

            healthworker.UserType = UserType.HealthWorker;
            int id  = _userRepository.RegisterHealthWorkerUser(healthworker);
            return id;
        }

        public void UpdateCovidResult(UpdateCovidResultInputDTO updateCovidResultInputDTO)
        {
            var User = _userRepository.GetUserById(updateCovidResultInputDTO.UserId);
            if (User == null)
            {
                throw new BussinessException("User not found");
            }

            var AdminUser = _userRepository.GetUserById(updateCovidResultInputDTO.AdminId);
            if (AdminUser == null)
            {
                throw new BussinessException("Admin User not found");
            }

            if (AdminUser.UserType != UserType.HealthWorker)
            {
                throw new BussinessException("You are not authorized to perform this operation");
            }

            _userRepository.UpdateUserResult(updateCovidResultInputDTO.UserId , updateCovidResultInputDTO.Result);
        }
    }
}

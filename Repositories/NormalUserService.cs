using Entities;
using Entities.DTO;
using Entities.Models;
using Interfaces;


namespace Repositories
{
    public class NormalUserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public NormalUserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int Register(NormalUser normalUser)
        {
            if (_userRepository.CheckUserByPhone(normalUser.PhoneNo))
            {
                throw new BussinessException("Phone no already registered");
            }

            normalUser.UserType = UserType.Normal;

            return _userRepository.RegisterNormalUser(normalUser);
        }

        public int CalCulateRisk(selfAssessmentInputDTO selfAssessmentInputDTO)
        {
            var User = _userRepository.GetUserById(selfAssessmentInputDTO.UserId);
            if (User  == null)
            {
                throw new BussinessException("User not found");
            }

            if (User.Result.ToLower() == "Positive".ToLower())
            {
                return 100;
            }

            //Will improve below logic

            if ((selfAssessmentInputDTO.Symptoms == null ||
                selfAssessmentInputDTO.Symptoms.Count == 0) &&
                !selfAssessmentInputDTO.ContactWithCovidPatient &&
                !selfAssessmentInputDTO.TravelHistory
                )
            {
                return 5;
            }

            else if ((
                selfAssessmentInputDTO.Symptoms.Count == 2) &&
               (selfAssessmentInputDTO.ContactWithCovidPatient ||
               selfAssessmentInputDTO.TravelHistory)
              )
            {
                return 75;
            }
            else if ((
             selfAssessmentInputDTO.Symptoms.Count == 1) &&
            (selfAssessmentInputDTO.ContactWithCovidPatient ||
            selfAssessmentInputDTO.TravelHistory)
           )
            {
                return 50;
            }

            else  if ((
                 selfAssessmentInputDTO.Symptoms.Count > 2) &&
                (selfAssessmentInputDTO.ContactWithCovidPatient ||
                selfAssessmentInputDTO.TravelHistory)
               )
            {
                return 95;
            }

            throw new BussinessException("Invalid");
        }

    }
}

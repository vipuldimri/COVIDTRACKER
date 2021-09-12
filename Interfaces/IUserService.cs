using Entities.DTO;
using Entities.Models;


namespace Interfaces
{
    public interface IUserService
    {
        int Register(NormalUser normalUser);
        int CalCulateRisk(selfAssessmentInputDTO selfAssessmentInputDTO);
    }
}

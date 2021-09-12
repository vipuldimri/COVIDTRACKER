
using Entities.DTO;
using Entities.Models;

namespace Interfaces
{
    public interface IAdminUserService
    {
        int Register(HealthWorker healthworker);
        void UpdateCovidResult(UpdateCovidResultInputDTO updateCovidResultInputDTO);
    }
}

using Entities;
using Entities.DTO;
using Entities.Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace COVIDTRACKER.Controllers
{    

    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminUserService _adminUserService;
        public AdminController(IAdminUserService adminUserService)
        {
            _adminUserService = adminUserService;
        }

        [HttpPost("RegisterAdmin")]
        public IActionResult RegisterAdmin([FromBody] UserInputDTO userInputDTO)
        {
            try
            {
                HealthWorker newUser = new HealthWorker()
                {
                    Name = userInputDTO.Name,
                    PhoneNo = userInputDTO.PhoneNo,
                    PinCode = userInputDTO.PinCode
                };
                int id = _adminUserService.Register(newUser);

                return Ok(new { adminId = id });
            }
            catch (BussinessException ex)
            {
                return BadRequest(ex.CustomMessage);
            }

        }

        [HttpPost("updateCovidResult")]
        public IActionResult updateCovidResult([FromBody] UpdateCovidResultInputDTO updateCovidResultInputDTO)
        {
            try
            {
                _adminUserService.UpdateCovidResult(updateCovidResultInputDTO);
                return Ok(new { updated = true });
            }
            catch (BussinessException ex)
            {
                return BadRequest(ex.CustomMessage);
            }
        }
    }
}
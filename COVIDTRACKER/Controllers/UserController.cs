using Entities;
using Entities.DTO;
using Entities.Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace COVIDTRACKER.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserInputDTO userInputDTO)
        {
            try
            {
                NormalUser newUser = new NormalUser(){
                    Name = userInputDTO.Name,
                    PhoneNo = userInputDTO.PhoneNo,
                    PinCode = userInputDTO.PinCode
                };

                int Id = _userService.Register(newUser);
                return Ok(new { userId = Id });
            }
            catch (BussinessException ex)
            {
                return BadRequest(ex.CustomMessage);
            }
        }

        [HttpPost("SelfAssessment")]
        public IActionResult SelfAssessment([FromBody] selfAssessmentInputDTO selfAssessmentInputDTO)
        {
            try
            {
                int riskPercentage = _userService.CalCulateRisk(selfAssessmentInputDTO);
                return Ok(new { riskPercentage = riskPercentage });
            }
            catch (BussinessException ex)
            {
                return BadRequest(ex.CustomMessage);
            }
        }


    }
}
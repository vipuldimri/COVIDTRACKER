using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO
{
    public class selfAssessmentInputDTO
    {
        [Required]
        public int UserId { get; set; }
        public List<string> Symptoms { get; set; }
        [Required]
        public bool TravelHistory { get; set; }
        [Required]
        public bool ContactWithCovidPatient { get; set; }

    }
}

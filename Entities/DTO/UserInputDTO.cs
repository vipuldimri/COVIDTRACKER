
using System.ComponentModel.DataAnnotations;


namespace Entities.DTO
{
    public class UserInputDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string PhoneNo { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(6)]
        public string PinCode { get; set; }
    }
}


namespace Entities.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string PinCode{ get; set; }
        public UserType UserType { get; set; }
        public string Result { get; set; }
        public User(UserType userType)
        {
            this.UserType = userType;
        }
    }
    public class NormalUser : User
    {
        
        public NormalUser() : base(UserType.Normal)
        {

        }
    }

    public class HealthWorker : User
    {
        public HealthWorker() : base(UserType.HealthWorker)
        {
        }
    }
}

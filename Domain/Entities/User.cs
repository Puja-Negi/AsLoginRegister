using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
   public enum UserRole
    {
        Admin,
        Driver,
        Passenger
    }

    public class User
    {
        [Key]
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? UserPhoto { get; set; }
        public string PermanentAddress { get; set; } = string.Empty;

       //[RegularExpression(@"^(\+977)?9[0-9]{9}$", ErrorMessage = "Invalid phone number. Please provide a valid phone number.")]
        public string PhoneNumber { get; set; } = string.Empty;
        //[EnumDataType(typeof(UserRole))]
        public UserRole Role { get; set; }
        //public string Role { get; set; }
        public bool Status { get; set; }
        public bool IsVerified { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; }
    }
}

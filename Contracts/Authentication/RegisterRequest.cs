
using Domain.Entities;

namespace Contracts.Authentication
{
    public record RegisterRequest(
       string FirstName,
       string LastName,
       string UserPhoto,
       string PermanentAddress,
       string PhoneNumber,
       string Password,
       UserRole Role
    );
}

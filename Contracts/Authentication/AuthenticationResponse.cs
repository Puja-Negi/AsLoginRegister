
using Domain.Entities;

namespace Contracts.Authentication
{
    public record AuthenticationResponse(
       Guid UserId,
       string FirstName,
       string LastName,
       string? UserPhoto,
       string PermanentAddress,
       string PhoneNumber,
       UserRole Role,
       DateTime CreatedDate,
       string Token);
   
}
    
using Application.Authentication.Result;
using Domain.Entities;
using Domain.Errors.Services;
using MediatR;

namespace Application.Authentication.Commands
{
    public record RegisterCommand(
       string FirstName,
       string LastName,
       string UserPhoto,
       string PermanentAddress,
       string PhoneNumber,
       string Password, 
       DateTime CreatedDate,
       UserRole Role) : IRequest<ServiceResult<AuthenticationResult>>;
}
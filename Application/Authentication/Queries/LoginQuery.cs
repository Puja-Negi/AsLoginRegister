using Application.Authentication.Result;
using Domain.Errors.Services;
using MediatR;

namespace Application.Authentication.Queries
{
    public record LoginQuery(
       string PhoneNumber,
       string Password) : IRequest<ServiceResult<AuthenticationResult>>;
}

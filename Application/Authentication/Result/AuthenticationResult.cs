using Domain.Entities;

namespace Application.Authentication.Result
{
    public record AuthenticationResult(
       User User,
       string Token);
}

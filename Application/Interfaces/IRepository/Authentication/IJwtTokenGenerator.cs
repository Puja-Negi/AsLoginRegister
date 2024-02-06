using Domain.Entities;

namespace Application.Interfaces.IRepository.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
using Domain.Entities;

namespace Application.Interfaces.IRepository.Persistence
{
    public interface IUserRepository
    {
        User Add(User user);
        User GetUserByPhoneNumber(string phoneNumber);
    }
}

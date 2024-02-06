using Application.Interfaces.IRepository.Persistence;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
      //  private static readonly List<User> users = new List<User>();
        private readonly AutoDbContext _dbContext;

        public UserRepository(AutoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public User GetUserByPhoneNumber(string phoneNumber)
        {
            return _dbContext.Users.SingleOrDefault(u => u.PhoneNumber == phoneNumber);
        }
    }
}

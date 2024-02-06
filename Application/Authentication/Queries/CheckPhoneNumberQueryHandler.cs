using Application.Interfaces.IRepository.Persistence;
using MediatR;

namespace Application.Authentication.Queries
{
    public class CheckPhoneNumberQueryHandler : IRequestHandler<CheckPhoneNumberQuery, bool>
    {
        private readonly IUserRepository _userRepository;

        public CheckPhoneNumberQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(CheckPhoneNumberQuery query, CancellationToken cancellationToken)
        {
            var VerifyPhoneNumber =  _userRepository.GetUserByPhoneNumber(query.PhoneNumber);
            if (VerifyPhoneNumber == null) 
            {
                return false;
            }
            return true ;
        }
    }
}
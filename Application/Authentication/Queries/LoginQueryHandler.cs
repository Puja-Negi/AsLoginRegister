using Application.Authentication.Queries;
using Application.Authentication.Result;
using Application.Interfaces.IRepository.Authentication;
using Application.Interfaces.IRepository.Persistence;
using Domain.Entities;
using Domain.Errors;
using Domain.Errors.Services;
using ErrorOr;
using MediatR;

namespace AutoBooking.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler :IRequestHandler<LoginQuery, ServiceResult<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ServiceResult<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //1. Validate the user exists
            if (_userRepository.GetUserByPhoneNumber(query.PhoneNumber) is not User user)
            {
                return ServiceResult<AuthenticationResult>.Failure(ErrorResponse.InvalidPhoneNumber());
            }
            if (user.Password != query.Password)
            {
                return ServiceResult<AuthenticationResult>.Failure(ErrorResponse.InvalidPassword());
            }
            
            //3.Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return ServiceResult<AuthenticationResult>.Success(new AuthenticationResult(user, token));
        }
    }
}
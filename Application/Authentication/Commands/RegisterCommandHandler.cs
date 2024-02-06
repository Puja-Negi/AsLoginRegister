

using Application.Authentication.Commands;
using Application.Authentication.Result;
using Application.Interfaces.IRepository.Authentication;
using Application.Interfaces.IRepository.Persistence;
using Domain.Entities;
using Domain.Errors;
using Domain.Errors.Services;
using MediatR;

namespace Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ServiceResult<AuthenticationResult>>
    {
        //  private readonly IFirebaseService _firebaseService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(
            //     IFirebaseService firebaseService,
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            // _firebaseService = firebaseService;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ServiceResult<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            //1. Validate the user doesn't exist
            if (_userRepository.GetUserByPhoneNumber(command.PhoneNumber) is not null)
            {
                  return ServiceResult<AuthenticationResult>.Failure(ErrorResponse.DuplicatePhoneNumber());
            }

            //2.Create user(generate unique ID) & Persist to DB
            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                UserPhoto = command.UserPhoto,
                PermanentAddress = command.PermanentAddress,
                PhoneNumber = command.PhoneNumber,
                Password = command.Password,
                CreatedDate = command.CreatedDate,
                Role = command.Role
            };

            _userRepository.Add(user);

            //3.Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return ServiceResult<AuthenticationResult>.Success(new AuthenticationResult(user, token));
        }
    }
}
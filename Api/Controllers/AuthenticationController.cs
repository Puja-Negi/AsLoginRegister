using Application.Authentication.Commands;
using Application.Authentication.Queries;
using Application.Authentication.Result;
using Contracts.Authentication;
using Domain.Errors.Services;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrueDinner.Contracts.Authentication;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public AuthenticationController(
            ISender mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("check-phoneNumber")]
        public async Task<ActionResult<bool>> CheckPhoneNumber(string phoneNumber)
        {
            var result = await _mediator.Send(new CheckPhoneNumberQuery(phoneNumber));
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            ServiceResult<AuthenticationResult> authResult = await _mediator.Send(command);
            
             if (authResult.isSuccess)
             {
                 /*var authenticationResult = authResult.data;
                 var response = new AuthenticationResponse(
                     authenticationResult.User.UserId,
                     authenticationResult.User.FirstName,
                     authenticationResult.User.LastName,
                     authenticationResult.User.UserPhoto,
                     authenticationResult.User.PermanentAddress,
                     authenticationResult.User.PhoneNumber,
                     authenticationResult.User.Role,
                     authenticationResult.User.CreatedDate,
                     authenticationResult.Token);*/

                 return Ok(_mapper.Map<AuthenticationResponse>(authResult.data));
             }
             else
             {
                 return BadRequest(authResult.errorResponse);
             }
            /* else
             {
                 if (authResult.errorResponse.Type == ErrorType.DuplicatePhoneNumber)
                 {
                     return BadRequest("PhoneNumber is already in use.");
                 }
                 else
                 {
                     return Problem();
                 }
             }*/
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            ServiceResult<AuthenticationResult> authResult = await _mediator.Send(query);

            if (authResult.isSuccess)
            {
                return Ok(_mapper.Map<AuthenticationResponse>(authResult.data));
            }
            else
            {
                return BadRequest(authResult.errorResponse);
            }
        }
    }
}

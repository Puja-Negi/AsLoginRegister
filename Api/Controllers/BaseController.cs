using Application.Authentication.Result;
using Domain.Errors.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;
using static Google.Apis.Auth.OAuth2.Web.AuthorizationCodeWebApp;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        /*public bool ValidatePhoneNumber(string phoneNumber)
        {
            string pattern = @"^(\+[0-9]{9})$";
            bool isValidPhoneNumber = Regex.IsMatch(phoneNumber, pattern);
            return isValidPhoneNumber;
        }*/
    }
}
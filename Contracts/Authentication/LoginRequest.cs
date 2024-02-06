using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueDinner.Contracts.Authentication
{
    public record LoginRequest(
       string PhoneNumber,
       string Password);
}

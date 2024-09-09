using Infracstructure.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ITokenService
    {
        string GeneratePasswordResetToken(User user);
        string GenerateJwtToken(User user);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        //string GenerateEmailConfirmationToken(User user);

    }
}

using System;
using System.Linq;
using System.Security.Claims;

namespace Catalogue.Extensions
{
    public static class ClaimsPrincipalExtentions
    {
        public static string GetCustomerId(this ClaimsPrincipal claims)
        {
            try
            {
                return claims.Claims.FirstOrDefault(w => w.Type == ClaimTypes.Sid)?.Value;
            }
            catch
            {
                throw new SystemException("User is not found");
            }
        }
    }
}

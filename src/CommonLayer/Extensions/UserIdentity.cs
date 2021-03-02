using System;
using System.Linq;
using System.Security.Claims;


namespace CommonLayer.Extensions
{
    public static class UserIdentity
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            var claims = principal.Claims;

            if(claims.Any(x => x.Type.Equals(ClaimTypes.NameIdentifier)))
            {
                return claims.Where(x => x.Type.Equals(ClaimTypes.NameIdentifier)).First().Value;
            }

            return null;
        }

        public static string GetRole(this ClaimsPrincipal principal)
        {
            var claims = principal.Claims;

            //var claims = User.Claims.Select(claim => new { claim.Type, claim.Value }).ToArray();

            if (claims.Any(x => x.Type.Equals(ClaimTypes.Role)))
            {
                return claims.Where(x => x.Type.Equals(ClaimTypes.Role)).First().Value;
            }

            return null;
        }

        public static int GetSalaVentaId(this ClaimsPrincipal principal)
        {
            var claims = principal.Claims;

            //var claims = User.Claims.Select(claim => new { claim.Type, claim.Value }).ToArray();

            if (claims.Any(x => x.Type.Equals("SalaVentaId")))
            {
                return Convert.ToInt32(claims.Where(x => x.Type.Equals("SalaVentaId")).First().Value);
            }

            return 0;
        }



    }
}

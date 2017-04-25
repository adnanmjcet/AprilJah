using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace ApiLayer.Helpers
{
    public static class IdentityExtensions
    {
        public static int GetUserID(this IIdentity identity)
        {
            if (identity == null)
                return 0;

            var claims = identity as ClaimsIdentity;

            if (claims.FindFirst(ClaimTypes.NameIdentifier) == null)
                return 0;

            return Convert.ToInt32(claims.FindFirst(ClaimTypes.NameIdentifier).Value);
        }


        public static Int64 GetRoleID(this IIdentity identity)
        {
            if (identity == null)
                return 0;

            var claims = identity as ClaimsIdentity;

            return Convert.ToInt64(claims.FindFirst("RoleID").Value);
        }

        

    }
}
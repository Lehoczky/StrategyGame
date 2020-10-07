using System;
using System.Security.Claims;

namespace backend.Controllesrs
{
    public class Helpers
    {
        public static int IdForUser(ClaimsPrincipal user)
        {
            return Int32.Parse(user.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}
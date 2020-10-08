using System;
using System.Security.Claims;
using backend.Exceptions;
using backend.Models;

namespace backend.Helpers
{
    public class Helpers
    {
        public static int IdForUser(ClaimsPrincipal user)
        {
            return Int32.Parse(user.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        public static void Pay(ApplicationUser user, int cost)
        {
            if (cost > user.Country.Pearls)
            {
                throw new NotEnoughPearlsException();
            }
            user.Country.Pearls -= cost;
        }
    }
}
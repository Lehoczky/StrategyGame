using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using backend.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace backend.Data
{
    public interface IAuthRepository
    {
        Task<TokenResponseDto> Register(AuthFormDto formData);
        Task<TokenResponseDto> Login(AuthFormDto formData);
    }

    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<TokenResponseDto> Login(AuthFormDto formData)
        {
            var user = await _userManager.FindByNameAsync(formData.UserName);
            System.Console.WriteLine(user);
            if (user == null)
                throw new ArgumentException("User with this name does not exist");

            var result = await _userManager.CheckPasswordAsync(user, formData.Password);
            if (!result)
                throw new ArgumentException("Incorrect password");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, formData.UserName)
            };

            var token = createJwtToken(claims);
            return new TokenResponseDto { Access = token };
        }

        public async Task<TokenResponseDto> Register(AuthFormDto formData)
        {
            if (formData == null)
                throw new NullReferenceException("Form data is null");

            var identityUser = new IdentityUser { UserName = formData.UserName };
            var result = await _userManager.CreateAsync(identityUser, formData.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);
                var errorMessage = String.Join("\n", errors);
                throw new ArgumentException("User with this name already exist");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, identityUser.Id),
                new Claim(ClaimTypes.Name, formData.UserName)
            };

            var token = createJwtToken(claims);
            return new TokenResponseDto { Access = token };
        }

        private string createJwtToken(IEnumerable<Claim> claims)
        {
            var encryptionKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("very_long_security_key"));
            var token = new JwtSecurityToken
            (
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(encryptionKey, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
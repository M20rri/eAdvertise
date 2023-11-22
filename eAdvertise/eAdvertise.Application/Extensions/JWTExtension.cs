using eAdvertise.Application.DTOs.Authenticate;
using eAdvertise.Domain.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eAdvertise.Application.Extensions
{
    public static class JWTExtension
    {
        public static Task<SingInToken> GenerateTokenAsync(this Token tokenDto, JWTSettings _jwtSetting)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSetting.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserName", tokenDto.UserName),
                    new Claim("Roles", tokenDto.Roles),
                    new Claim("UserId", tokenDto.Id)
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _jwtSetting.Audience,
                Issuer = _jwtSetting.Issuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Task.FromResult(new SingInToken
            {
                Id = tokenDto.Id,
                Token = tokenHandler.WriteToken(token),
                Username = tokenDto.UserName
            });
        }
    }
}

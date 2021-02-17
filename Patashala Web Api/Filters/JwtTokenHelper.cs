using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Patashala_Web_Api.Config;
using Patashala_Web_Api.Models;
using Patashala_Web_Api.DTO;
using Microsoft.IdentityModel.Tokens;

namespace Patashala_Web_Api.Filters
{
    public class JwtTokenHelper
    {
        public TokenDTO CreateToken(AuthModel authApp)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var issuedAt = DateTime.UtcNow;
            var expires = DateTime.UtcNow.AddDays(30);
            var claimsIdentity = new ClaimsIdentity(new GenericIdentity(authApp.Name), new[]
            {
                new Claim("appToken", authApp.AppToken, ClaimValueTypes.String),
            });

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(GlobalConfig.Secret));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //create the token
            var token = tokenHandler.CreateJwtSecurityToken(
                GlobalConfig.Issuer,
                GlobalConfig.Audience,
                claimsIdentity,
                issuedAt,
                expires,
                signingCredentials: signingCredentials);

            return new TokenDTO
            {
                Token = tokenHandler.WriteToken(token),
                Expires = expires,
            };
        }

    }
}
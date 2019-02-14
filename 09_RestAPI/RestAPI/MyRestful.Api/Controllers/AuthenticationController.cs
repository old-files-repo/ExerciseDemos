using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MuRestful.Core.Domains;
using MyRestful.Api.ViewModels;
using MyRestful.Infrastructure.Repositories;
using MyRestful.Infrastructure.UnitOfWork;

namespace MyRestful.Api.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Add()
        {
            var authorizationHeader = Request.Headers["Authorization"].First();
            var key = authorizationHeader.Split(' ')[1];
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(key)).Split(':');
            var serverSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:ServerSecret"]));
            if (credentials[0] == "username" && credentials[1] == "password")
            {
                var result = new
                {
                    token = GenerateToken(serverSecret)
                };

                return Ok(result);
            }

            return BadRequest();
        }

        private string GenerateToken(SecurityKey key)
        {
            var now = DateTime.UtcNow;
            var issuer = _configuration["JWT:Issuer"];
            var audience = _configuration["JWT:Audience"];
            var identity = new ClaimsIdentity();
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateJwtSecurityToken(issuer, audience, identity, now,
                now.Add(TimeSpan.FromHours(1)), now, signingCredentials);
            var encodedJwt = handler.WriteToken(token);
            return encodedJwt;
        }
    }
}

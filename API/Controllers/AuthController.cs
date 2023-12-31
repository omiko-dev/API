﻿using API.Data;
using API.Helper;
using API.Models;
using API.Models.User;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly UserDbContext _userDb;
        private readonly IMapper _mapper;

        public AuthController(IConfiguration configuration, UserDbContext userDb, IMapper _mapper)
        {
            _configuration = configuration;
            _userDb = userDb;
            this._mapper = _mapper;
        }



        [HttpPost("Register")]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(UserDto), 200)]
        public async Task<ActionResult> Register(RegisterDto newUser)
        {
            if (newUser.Name == null)
            {
                return BadRequest("Please Enter Name");
            }

            if (await _userDb.Users.AnyAsync(u => u.Email == newUser.Email))
            {
                return BadRequest("Enter Another Email");
            };


            var user = _mapper.Map<User>(newUser);

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.PasswordHash);
            user.Role = "user";

            await _userDb.AddAsync(user);
            await _userDb.SaveChangesAsync();

            return Ok(newUser);

        }


        [HttpPost("Login")]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<ActionResult> Login(LoginDto _user)
        {

            var user = await _userDb.Users.FirstOrDefaultAsync(u => u.Email == _user.Email);

            if (user == null)
            {
                return BadRequest("Email Is Incorrect");
            }

            if (!BCrypt.Net.BCrypt.Verify(_user.Password, user.PasswordHash))
            {
                return BadRequest("Invalid Password");
            }

            var Token = token(user);

            //var refreshToken = createRefreshToken();
            //SetRefreshToken(refreshToken);

            //user.refreshToken = refreshToken.refreshToken;
            //user.tokenCreate = refreshToken.TokenCreate;
            //user.tokenExpires = refreshToken.TokenExpires;

            await _userDb.SaveChangesAsync();
            return Ok(Token);

        }

        //[HttpPost("Refresh-Token")]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(typeof(string), 200)]
        //public async Task<ActionResult> RefreshToken([FromQuery] string refreshToken, [FromBody] bool allow)
        //{
        //    var user = await _userDb.Users.FirstOrDefaultAsync(u => u.refreshToken == refreshToken);

        //    if (user == null)
        //    {
        //        return BadRequest("Invalid Refresh Token");
        //    }

        //    await Console.Out.WriteLineAsync("work");

        //    if (user?.tokenExpires < DateTime.Now)
        //    {
        //        return BadRequest("Token Expires");
        //    }

        //    var Token = token(user!);

        //    var _refreshToken = createRefreshToken();
        //    SetRefreshToken(_refreshToken);

        //    user!.refreshToken = _refreshToken.refreshToken;
        //    user.tokenCreate = _refreshToken.TokenCreate;
        //    user.tokenExpires = _refreshToken.TokenExpires;

        //    await _userDb.SaveChangesAsync();


        //    return Ok(Token);
        //}

        //private RefreshToken createRefreshToken()
        //{

        //    var refreshToken = new RefreshToken
        //    {
        //        refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
        //        TokenExpires = DateTime.Now.AddDays(7)
        //    };
        //    return refreshToken;


        //}
        //private void SetRefreshToken(RefreshToken refreshToken)
        //{
        //    var cookieOption = new CookieOptions
        //    {
        //        HttpOnly = false,
        //        Expires = refreshToken.TokenExpires,
        //        Secure = true,
        //        SameSite = SameSiteMode.None

        //    };
        //    Response.Cookies.Append("Refresh_Token", refreshToken.refreshToken, cookieOption);

        //}

        private string token(User user)
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration.GetSection("JWT:Token").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken
                (
                   claims: claims,
                   expires: DateTime.Now.AddHours(1),
                   signingCredentials: cred
                );

            var Jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Jwt;
        }

    }
}

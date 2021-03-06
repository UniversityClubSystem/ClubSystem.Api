﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ClubSystem.Api.Extensions;
using ClubSystem.Lib.Models;
using Microsoft.Extensions.Configuration;

namespace ClubSystem.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            _jwtTokenGenerator = new JwtTokenGenerator(configuration);
        }

        [HttpGet, Authorize]
        public IActionResult GetAllUsers()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(_userManager.Users.ToList());
        }

        [HttpPost("login")]
        public async Task<object> Login([FromBody] User user) // TODO: LoginDto model
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.PasswordHash, false, false);

            if (!result.Succeeded) return BadRequest("Invalid Credentials");

            var appUser = _userManager.Users.SingleOrDefault(r => r.UserName == user.UserName);
            return _jwtTokenGenerator.GenerateJwtToken(user.UserName, appUser);
        }

        [HttpPost]
        public async Task<object> Register([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newUser = new User { UserName = user.UserName, Email = user.Email };
            var result = await _userManager.CreateAsync(newUser, user.PasswordHash);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(newUser, false);
                return _jwtTokenGenerator.GenerateJwtToken(user.UserName, newUser);
            }

            foreach (var responseError in result.Errors)
            {
                ModelState.AddModelError("errors", responseError.Description);
            }

            return BadRequest(ModelState);
        }
    }
}
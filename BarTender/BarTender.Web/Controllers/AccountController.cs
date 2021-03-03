namespace BarTender.Web.Controllers
{
    using AutoMapper;
    using BarTender.Data.Models;
    using BarTender.Web.Helpers;
    using BarTender.Web.Models.Account.InputModels;
    using BarTender.Web.Models.Account.ViewModels;
    using BarTender.Web.Models.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    public class AccountController : ApiController
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly JwtSettings jwtSettings;
        private readonly IMapper mapper;

        public AccountController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IOptions<JwtSettings> jwtSettings,
            IMapper mapper) 
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.jwtSettings = jwtSettings.Value;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<object> Login([FromBody] LoginInputModel model)
        {
            var user = userManager.Users.SingleOrDefault(r => r.Email == model.Email);
            if (user is null)
            {
                return BadRequest(new BadRequestViewModel
                {
                    Message = "Incorrect e-mail or password"
                });
            }

            var result = await signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);

            if (result.Succeeded)
            {
                return new AuthenticationViewModel
                {
                    Message = "You have successfully logged in",
                    Token = GenerateJwtToken(user)
                };
            }

            return BadRequest(new BadRequestViewModel
            {
                Message = "Incorrect e-mail or password"
            });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<object> Register([FromBody] RegisterInputModel model)
        {
            var user = this.mapper.Map<User>(model);

            if (userManager.Users.Any(u => u.Email == model.Email))
            {
                return BadRequest(new BadRequestViewModel
                {
                    Message = "This email is already taken. Please try with another one"
                });
            }

            if (userManager.Users.Any(u => u.UserName == model.Username))
            {
                return BadRequest(new BadRequestViewModel
                {
                    Message = "This username is already taken. Please try with another one "
                });
            }

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded) 
            {
                var addToRoleResult = await userManager.AddToRoleAsync(user, "User");
                if (addToRoleResult.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);

                    return new AuthenticationViewModel
                    {
                        Message = "You have successfully registered",
                        Token = GenerateJwtToken(user)
                    };
                }
            }

            return BadRequest(new BadRequestViewModel
            {
                Message = "Somethink went wrong. Please check your form and try again"
            });
        }

        private string GenerateJwtToken(User user) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, this.userManager.IsInRoleAsync(user, "Administrator").GetAwaiter().GetResult() ? "Administrator" : "User")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }

}


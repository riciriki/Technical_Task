using Azure.Core;
using Loyalty_campaigns.Business_Layer.Interfaces;
using Loyalty_campaigns.DTOs;
using Loyalty_campaigns.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Unicode;

namespace Loyalty_campaigns.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IConfiguration _configuration;

        public AuthController(IEmployeeService employeeService, IConfiguration configuration)
        {
            _employeeService = employeeService;
            _configuration = configuration;
        }

        [HttpPost("register_employee")]
        public async Task<ActionResult<Employee>> RegisterEmployee([FromBody] EmployeeDTO newEmployee) 
        {
            CreatePasswordHash(newEmployee.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var result= await _employeeService.AddEmployee(newEmployee, passwordHash, passwordSalt);

            return Ok(result);
        }

        [HttpPost("login_employee")]
        public async Task<ActionResult<string>> Login(LoginDTO employeeLogin)
        {
            Employee employee = await _employeeService.CheckEmployeeCredentials(employeeLogin.Username);
            if (employee == null || !VerifyPasswordHash(employeeLogin.Password, employee.PasswordHash, employee.PasswordSalt))
            {
                return BadRequest("Wrong credentials.");
            }
            string token = CreateToken(employee);
            Console.WriteLine(User.FindFirst(ClaimTypes.Name));
            return Ok(token);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(Employee user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Agnet"),//change
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            /*var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);*/
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
 
                SigningCredentials = new SigningCredentials((key), SecurityAlgorithms.HmacSha256Signature)
            };

            //return jwt;
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

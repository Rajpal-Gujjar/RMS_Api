using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RMSApi.Business.IServices;
using RMSApi.Common.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtAuthController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IJobSeekerServices _jobSeekerServices;
        private readonly IAdminServices _adminServices;

        public JwtAuthController(IConfiguration config, IJobSeekerServices jobSeekerServices, IAdminServices adminServices)
        {
            _configuration = config;
            _jobSeekerServices = jobSeekerServices;
            _adminServices = adminServices;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AdminDTO adminDTO)
        {
            if (adminDTO != null && adminDTO.UserName != null && adminDTO.Password != null)
            {
                var user = GetAdmin(adminDTO.UserName, adminDTO.Password);

                if (user != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserName", user.UserName.ToString()),
                        new Claim("Password", user.Password),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("JobSeeker")]
        public async Task<IActionResult> PostJobSeeker(JobSeekerDTO jobSeekerData)
        {
            if (jobSeekerData != null && jobSeekerData.Email != null && jobSeekerData.Password != null)
            {
                var user = await GetUser(jobSeekerData.Email, jobSeekerData.Password);

                if (user != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Email", user.Email.ToString()),
                        new Claim("Password", user.Password),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private AdminDTO GetAdmin(string userName, string password)
        {
            return _adminServices.GetAdmin(userName, password);
        }

        private async Task<JobSeekerDTO> GetUser(string email, string password)
        {
            return _jobSeekerServices.Get(email, password);
        }
    }
}

using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userData)
        {
            // validate request

            userData.Username = userData.Username.ToLower();
            if (await _repo.UserExistsAsync(userData.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = userData.Username
            };
            var createUser = await _repo.Register(userToCreate, userData.Password);

            return StatusCode(201);
        }
    }
}
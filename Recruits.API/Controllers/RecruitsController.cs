using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recruits.API.Models;
using Recruits.API.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recruits.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitsController : ControllerBase
    {
        private readonly ITokenRepository _tokenRepository;

        public RecruitsController(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }


        // GET: api/<UsersController>
        [HttpGet]
        public List<string> Get()
        {
            var recruits = new List<string>
        {
            "John Doe",
            "Jane Doe",
            "Junior Doe"
        };

            return recruits;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Users usersdata)
        {
            var token = _tokenRepository.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}

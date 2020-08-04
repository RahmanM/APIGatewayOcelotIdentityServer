using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiGrateway.WebApi.Users.Controllers
{
    //[Authorize(Policy = "PublicSecure")]
    [Authorize()]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private static readonly string[] Users = new[]
        {
            "Rahman", "Hosha", "Roaya", "Cyrus"
        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<UserModal> Get()
        {
            var list = new List<UserModal>();
            list.Add(new UserModal { Id = 1, Name = "Rahman", Date = DateTime.Now.AddDays(100) });
            list.Add(new UserModal { Id = 2, Name = "Yama", Date = DateTime.Now.AddDays(200) });
            list.Add(new UserModal { Id = 3, Name = "Roya", Date = DateTime.Now.AddDays(10) });
            list.Add(new UserModal { Id = 4, Name = "Hosha", Date = DateTime.Now.AddDays(600) });
            return list;
        }
    }
}

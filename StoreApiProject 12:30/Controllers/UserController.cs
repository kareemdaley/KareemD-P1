using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreateAPI.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository _repository;

        public UserController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: /api/orders/?name= "???"
        [HttpGet]
        public async Task<IActionResult> GetAllByNameAsync(
            //[FromQuery] string name
            )
        {
            IEnumerable<User> Users = await _repository.GetUsersAsync();



            return new JsonResult(Users);
        }

        //==============POST==============//
        [HttpPost]
        public async Task<IActionResult> AddNewUserAsync([FromQuery] string name)
        {
            IEnumerable<User> Users = await _repository.AddNewUserAsync(name);



            return new JsonResult(Users);
        }


    }
}
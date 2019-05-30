using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Interfaces;
using TaskManagerAPI.Model;

namespace TaskManagerAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    // [ApiController]
    public class UserController : Controller
    {
        //object that take the interface of the repository
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //Get: api/user
        [HttpGet]
        public async Task<IActionResult> get()
        {
            return new ObjectResult(await _userRepository.GetAllUsers());
        }

        //GET: api/User/username
        [HttpGet("{username}", Name = "Get")]
        public async Task<IActionResult> Get(string username)
        {
            var User = await _userRepository.GetUser(username);

            if (User == null)
            {
                return new NotFoundResult();
            }

            return new ObjectResult(User);

        }

        //POST: api/user
        //Create user
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            await _userRepository.Create(user);
            return new OkObjectResult(user);
        }

        //PUT: api/user/5
        //Update to MongoDb's user
        [HttpPut("{username}")]
        public async Task<IActionResult> Put(string username, [FromBody] User user)
        {
            var userValidation = await _userRepository.GetUser(username);

            if(userValidation == null)
            {
                return new NotFoundResult();
            }

            user.Id = userValidation.Id;

            await _userRepository.UpdateUser(user);

            return new OkObjectResult(user);
        }

        // DELETE: api/ApiWithActions/5
        //Delete user from MongoDb
        [HttpDelete("{username}")]
        public async Task<IActionResult> Delete(string username)
        {
            var userFromDb = await _userRepository.GetUser(username);

            if(userFromDb == null)
            {
                return new NotFoundResult();
            }

            await _userRepository.DeleteUser(username);

            return new OkResult();
        }

    }
}

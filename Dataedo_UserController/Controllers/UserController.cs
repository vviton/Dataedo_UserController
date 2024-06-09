using Dataedo_UserController.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Dataedo_UserController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(uint id)
        {
            var userDeleteResult = await _userRepository.DeleteAsync(id);
            if (userDeleteResult != 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Pr45_Api_Lisitskiy.Context;
using Pr45_Api_Lisitskiy.Models;

namespace Pr45_Api_Lisitskiy.Controllers
{
    [Route("api/UsersController")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class UsersController : Controller
    {
        [Route("SingIn")]
        [HttpPost]
        [ProducesResponseType(typeof(List<Tasks>), 200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public ActionResult SignIn([FromForm] string Login, [FromForm] string Password)
        {
            if (Login == null || Password == null)
            {
                return StatusCode(403);
            }
            try
            {
                Users User = new UsersContext().Users.Where(x => x.Login == Login && x.Password == Password).First();
                return Json(User);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}


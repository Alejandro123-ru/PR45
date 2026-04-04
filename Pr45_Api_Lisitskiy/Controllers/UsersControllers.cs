using Microsoft.AspNetCore.Mvc;
using Pr45_Api_Lisitskiy.Context;
using Pr45_Api_Lisitskiy.Models;

namespace Pr45_Api_Lisitskiy.Controllers
{
    public class UsersControllers
    {
        [Route("api/UsersController")]
        [ApiExplorerSettings(GroupName = "v2")]
        public class TasksController : Controller
        {
            ///<summary>
            ///Авторизация пользователя
            ///</summary>
            ///<param name="Login">Логин пользователя</param>
            ///<param name="Password">Пароль пользователя</param>
            ///<remarks>Данный метод предназначен для авторизации пользователя на сайте</remarks>
            ///<response code="200">Пользователь успешно авторизован</response>
            ///<response code="403">Ошибка запроса, данные не указаны</response>
            ///<response code="500">При выполнении запроса возникли ошибки</response>

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
                    return Json(User); // возвращаем ответ в виде JSON
                }
                catch
                {
                    return StatusCode(500);
                }
            }
        }
    }
}

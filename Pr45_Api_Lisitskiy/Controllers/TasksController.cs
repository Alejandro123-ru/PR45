using Microsoft.AspNetCore.Mvc;
using Pr45_Api_Lisitskiy.Context;
using Pr45_Api_Lisitskiy.Models;

namespace Pr45_Api_Lisitskiy.Controllers
{
    [Route("api/TasksController")]
    public class TasksController : Controller
    {
        ///<summary>
        ///Получение списка задач
        ///</summary>
        ///<remarks>Данный метод получает список задач, находящийся в базе данных</remarks>
        /// <response code="200">Список успешно получен</response>
        ///<response code="500">При выполнении запроса возникли ошибки</response>

        [Route("list")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Tasks>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List()
        {
            try
            {
                // получаем список задач из базы данных
                IEnumerable<Tasks> Tasks = new TaskContext().Tasks;
                return Json(Tasks); // возвращаем ответ в виде JSON
            }
            catch
            {
                return StatusCode(500);
            }
        }

        //Получение задачи
        //</summary>
        //<remarks>Данный метод получает задачу, находящуюся в базе данных</remarks>
        // <response code="200">Задача успешно получена</response>
        // <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("item")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Tasks>), 200)]
        [ProducesResponseType(500)]
        public ActionResult Item(int Id)
        {
            try
            {
                // Получаем задачу по коду
                Tasks Task = new TaskContext().Tasks.Where(x => x.Id == Id).First();
                return Json(Task); // возвращаем ответ в виде Json
            }
            catch (Exception exp)
            {
                return StatusCode(500); // если возникли неполадки, выдаём 500 ошибку (ошибку сервера)
            }
            
        }
    }
}

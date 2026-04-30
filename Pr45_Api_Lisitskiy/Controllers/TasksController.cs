using Microsoft.AspNetCore.Mvc;
using Pr45_Api_Lisitskiy.Context;
using Pr45_Api_Lisitskiy.Models;

namespace Pr45_Api_Lisitskiy.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class TasksController : Controller
    {
        [Route("list")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Tasks>), 200)]
        [ProducesResponseType(500)]
        public ActionResult List()
        {
            try
            {
                using var context = new TaskContext(); 
                IEnumerable<Tasks> Tasks = context.Tasks.ToList();
                return Json(Tasks);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Route("item")]
        [HttpGet]
        [ProducesResponseType(typeof(Tasks), 200)] 
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult Item(int Id)
        {
            try
            {
                using var context = new TaskContext();
                Tasks Task = context.Tasks.FirstOrDefault(x => x.Id == Id);

                if (Task == null)
                    return NotFound();

                return Json(Task);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Route("Add")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)] 
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult Add([FromForm]Tasks task)
        {
            try
            {
                TaskContext taskContext = new TaskContext();
                taskContext.Tasks.Add(task);
                taskContext.SaveChanges();

                return StatusCode(200);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Route("Update/{id}")]
        [HttpPut]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult Update(int id, [FromForm] Tasks updatedTask)
        {
            try
            {
                using var taskContext = new TaskContext();

                var existingTask = taskContext.Tasks.FirstOrDefault(x => x.Id == id);

                if (existingTask == null)
                {
                    return NotFound($"Задача с Id = {id} не найдена");
                }

                if (!string.IsNullOrEmpty(updatedTask.Name))
                    existingTask.Name = updatedTask.Name;

                if (!string.IsNullOrEmpty(updatedTask.Priority))
                    existingTask.Priority = updatedTask.Priority;

                if (updatedTask.DateExecute != default(DateTime))
                    existingTask.DateExecute = updatedTask.DateExecute;

                if (!string.IsNullOrEmpty(updatedTask.Comment))
                    existingTask.Comment = updatedTask.Comment;

                existingTask.Done = updatedTask.Done;

                taskContext.Tasks.Update(existingTask);
                taskContext.SaveChanges();

                return Ok(existingTask); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Внутренняя ошибка сервера: {ex.Message}");
            }
        }
    }
}

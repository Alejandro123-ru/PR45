namespace Pr45_Api_Lisitskiy.Models
{
    /// <summary>
    /// Класс задач
    /// </summary>
    public class Tasks
    {
        /// <summary>
        /// Код задачи
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование задачи
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Приоритет задачи
        /// </summary>
        public string Priority { get; set; }
        /// <summary>
        /// Дата выполнения задачи
        /// </summary>
        public DateTime DateExecute { get; set; }
        /// <summary>
        /// Комментарий к задаче
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Выполнение задачи
        /// </summary>
        public bool Done { get; set; }

    }
}



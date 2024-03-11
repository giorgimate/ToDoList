using System.ComponentModel.DataAnnotations;

namespace ToDoList_Backend.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsFinished { get; set; }
    }
}

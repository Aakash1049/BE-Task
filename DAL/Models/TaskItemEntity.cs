using System.ComponentModel.DataAnnotations;

namespace Task_Management_Application.Model
{
    public class TaskItemEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int TaskId { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
    }
}

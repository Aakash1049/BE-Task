using System.ComponentModel.DataAnnotations;

namespace BAL.Model
{
    public class TaskItemDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public int TaskId { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
    }
}

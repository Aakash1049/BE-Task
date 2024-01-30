using System;
using System.Collections.Generic;

namespace Task_Management_Application.Models;

public partial class TaskItemEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }
}

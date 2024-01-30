using BAL.Model;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management_Application.Model;

namespace BAL.Interfaces
{
    public interface ITaskService
    {
        Task<PaginatedResponse<TaskItemDto>> GetTasksAsync(PaginationParameters paginationParameters);
        Task<TaskItemDto> AddTaskAsync(TaskItemDto taskItem);
        Task<TaskItemDto> UpdateTaskAsync(int id,TaskItemDto taskItem);
        Task<bool> DeleteTaskAsync(int id);

    }
}

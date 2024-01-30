using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management_Application.Model;

namespace DAL.Interfaces
{
    public interface ITaskRepository
    {
        Task<(int TotalCount, List<TaskItemEntity> Items)> GetTasksAsync(PaginationParameters paginationParameters);
        Task<TaskItemEntity> AddNewTaskAsync(TaskItemEntity taskItemEntity);

        Task<TaskItemEntity> UpdateTaskAsync(TaskItemEntity taskItemEntity);

        Task<TaskItemEntity> GetByTaskIdAsync(int id);

        Task<bool> DeleteTaskAsync(int id);
    }
}

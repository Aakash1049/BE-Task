using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management_Application.Model;

namespace DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(int TotalCount, List<TaskItemEntity> Items)> GetTasksAsync(PaginationParameters paginationParameters)
        {
            var items = await _context.TaskItemEntities
            .OrderBy(i => i.Id)
            .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
            .Take(paginationParameters.PageSize)
                    .ToListAsync();

            var totalCount = _context.TaskItemEntities.Count();

            return (TotalCount: totalCount, Items: items); ;
        }

        public async Task<TaskItemEntity> AddNewTaskAsync(TaskItemEntity taskItemEntity)
        {
            _context.TaskItemEntities.Add(taskItemEntity);
            await _context.SaveChangesAsync();
            return taskItemEntity;
        }

        public async Task<TaskItemEntity> UpdateTaskAsync(TaskItemEntity taskItemEntity)
        {
            _context.Entry(taskItemEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return taskItemEntity;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var taskItem = await _context.TaskItemEntities.FindAsync(id);

            _context.TaskItemEntities.Remove(taskItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TaskItemEntity> GetByTaskIdAsync(int id)
        {
            return await _context.TaskItemEntities.FindAsync(id);
        }
    }
}

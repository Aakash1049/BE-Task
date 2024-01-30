using AutoMapper;
using BAL.Interfaces;
using BAL.Model;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management_Application.Model;

namespace BAL.Services
{
    public class TaskService : ITaskService
    {

        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse<TaskItemDto>> GetTasksAsync(PaginationParameters paginationParameters)
        {

            var (totalCount, items) = await _taskRepository.GetTasksAsync(paginationParameters);

            var paginatedResponse = new PaginatedResponse<TaskItemDto>
            {
                TotalCount = totalCount,
                PageNumber = paginationParameters.PageNumber,
                PageSize = paginationParameters.PageSize,
                Data = _mapper.Map<List<TaskItemDto>>(items)
            };

            return paginatedResponse;
        }

        public async Task<TaskItemDto> AddTaskAsync(TaskItemDto taskItem)
        {
            var newTask = await _taskRepository.AddNewTaskAsync(_mapper.Map<TaskItemEntity>(taskItem));
            return _mapper.Map<TaskItemDto>(newTask);
        }

        public async Task<TaskItemDto> UpdateTaskAsync(int id, TaskItemDto taskItem)
        {

            if (id != taskItem.Id)
            {
                throw new Exception("Task Id MisMatch");
            }

            var updatedTask = await _taskRepository.UpdateTaskAsync(_mapper.Map<TaskItemEntity>(taskItem));
            return _mapper.Map<TaskItemDto>(updatedTask);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var taskItem = await _taskRepository.GetByTaskIdAsync(id);
            if (taskItem == null)
            {
                throw new Exception("Data Not Found");
            }
            return await _taskRepository.DeleteTaskAsync(id);
        }
    }
}

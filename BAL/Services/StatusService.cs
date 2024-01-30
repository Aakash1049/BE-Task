using AutoMapper;
using BAL.Interfaces;
using BAL.Model;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management_Application.Model;

namespace BAL.Services
{
    public class StatusService : IStatusService
    {

        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;

        public StatusService(IStatusRepository statusRepository ,IMapper mapper)
        {
            _statusRepository = statusRepository;
            _mapper = mapper;
        }

        public async Task<List<TaskStatusDto>> GetStatusesAsync()
        {
            var status = await _statusRepository.GetStatusAsync();
            return _mapper.Map<List<TaskStatusDto>>(status);
        }
    }
}

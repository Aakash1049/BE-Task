using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Model;
using Task_Management_Application.Model;

namespace BAL.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskItemEntity, TaskItemDto>().ReverseMap();
            CreateMap<TaskStatusEntity, TaskStatusDto>().ReverseMap();
        }
    }
}

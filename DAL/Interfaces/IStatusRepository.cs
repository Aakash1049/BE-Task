using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management_Application.Model;

namespace DAL.Interfaces
{
    public interface IStatusRepository
    {
        Task<List<TaskStatusEntity>> GetStatusAsync();
    }
}

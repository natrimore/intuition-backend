using Intuition.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intuition.Services
{
    public interface IRecordService
    {
        Task<RecordViewModel> AddAsync(Guid userId, string data); 
        
        Task<RecordViewModel> AddAsync(RecordToAddDTO record);

        Task<IList<RecordViewModel>> GetAllAsync();

        Task<RecordViewModel> GetByDateAsync(DateTime date);
    }
}

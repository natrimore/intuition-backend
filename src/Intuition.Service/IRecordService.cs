using Intuition.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intuition.Services
{
    public interface IRecordService
    {
        Task<RecordViewModel> AddAsync(Guid userId, string data); 
        
        Task<RecordViewModel> AddAsync(RecordToAddDTO record);

        Task<List<RecordDetailsViewModel>> GetByDateAsync(DateTime date);
    }
}

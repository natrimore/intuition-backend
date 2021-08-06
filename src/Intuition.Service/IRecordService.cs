using Intuition.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intuition.Services
{
    public interface IRecordService
    {
        Task<RecordViewModel> AddData();

        Task<IList<RecordViewModel>> GetAllAsync();

        Task<RecordViewModel> GetByDateAsync(DateTime date);
    }
}

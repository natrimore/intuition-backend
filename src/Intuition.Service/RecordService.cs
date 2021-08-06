using Intuition.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intuition.Services
{
    public class RecordService : IRecordService
    {
        public Task<RecordViewModel> AddData()
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<RecordViewModel>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<RecordViewModel> GetByDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}

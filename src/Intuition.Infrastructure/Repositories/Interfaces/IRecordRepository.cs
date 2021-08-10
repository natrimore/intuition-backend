using Intuition.Domains.Records;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Intuition.Infrastructures.Repositories.Interfaces
{
    public interface IRecordRepository
    {
        Task<Record> FindByDateAsync(Guid userId, DateTime date);

        Task<bool> CreateAsync(Record entity);

        Task<bool> UpdateAsync(Record entity);

        List<Record> Get(Expression<Func<Record, bool>> predicate, int? skip = null, int? take = null);

        Task<List<Record>> GetAsync(Expression<Func<Record, bool>> predicate, int? skip = null, int? take = null);

        Task<bool> SaveChangesAsync();

    }
}

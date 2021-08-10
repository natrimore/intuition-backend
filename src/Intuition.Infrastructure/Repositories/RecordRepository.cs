using Intuition.Domains.Records;
using Intuition.Infrastructures.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Intuition.Infrastructures.Repositories
{
    public class RecordRepository : IRecordRepository, IDisposable
    {
        private readonly RecordContext _context;

        public RecordRepository(RecordContext context)
        {
            _context = context;
        }

        public Task<Record> FindByDateAsync(Guid userId, DateTime date)
        {
            return 
                _context
                .Records
                .SingleOrDefaultAsync(w => w.UserId == userId && w.Date == date);
        }

        public async Task<bool> UpdateAsync(Record entity)
        {
            var _entity = await _context.Records.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (_entity == null)
            {
                return false;
            }
            else
            {
                _context.Entry(_entity).CurrentValues.SetValues(entity);
                return await SaveChangesAsync();
            }

        }

        public Task<bool> CreateAsync(Record entity)
        {
            _context.Records.Add(entity);

            return SaveChangesAsync();
        }

        public List<Record> Get(Expression<Func<Record, bool>> predicate, int? skip = null, int? take = null)
        {
            var query = _context.Records.Where(predicate);

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            var entities = query.ToList();

            return entities;
        }

        public Task<List<Record>> GetAsync(Expression<Func<Record, bool>> predicate, int? skip = null, int? take = null)
        {
            var query = _context.Records
                    .Where(predicate);

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        #region Dispose
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~RecordRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

using AutoMapper;
using Intuition.Infrastructures.Repositories.Interfaces;
using Intuition.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intuition.Services
{
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _repository;
        private readonly IMapper _mapper;
        public RecordService(IRecordRepository repository, IMapper mapper)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<RecordViewModel> AddAsync(Guid userId, string data)
        {
            var today = DateTime.Today;

            var record = await _repository.FindByDateAsync(userId, today);

            if (record == null)
            {
                record = new Domains.Records.Record()
                {
                    Data = data,
                    UserId = userId,
                    Date = today
                };

                await _repository.CreateAsync(record);
            }
            else
            {

                var newData = await SyncAsync(record.Data, data);

                record.Data = newData;

                await _repository.UpdateAsync(record);
            }

            return _mapper.Map<RecordViewModel>(record);
        }

        public async Task<string> SyncAsync(string entityData, string externalData)
        {

            var internalDetailsTask = GetListOfRecordAsync(entityData);

            var externalDetailsTask = GetListOfRecordAsync(externalData);

            await Task.WhenAll(internalDetailsTask, externalDetailsTask);

            var internalDetails = internalDetailsTask.Result;

            var externalDetails = externalDetailsTask.Result;

            internalDetails.Union(externalDetails);

            return MakeData(internalDetails);
        }

        private string MakeData(List<RecordDetailsViewModel> details)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var detail in details)
            {
                var text = String.Join("|", new { detail.Date, detail.TotalAttempts, detail.CorrectAnswers });
                sb.Append(text);
                sb.Append(';');
            }

            return sb.ToString();
        }

        private Task<List<RecordDetailsViewModel>> GetListOfRecordAsync(string data)
        {
            var recordDetails = new List<RecordDetailsViewModel>();

            var task = Task<List<RecordDetailsViewModel>>.Run(() =>
            {
                var externalSplittedValue = data.Split(";");

                foreach (var detail in externalSplittedValue)
                {
                    var splittedValue = detail.Split('|');

                    var record = new RecordDetailsViewModel()
                    {
                        Date = DateTime.Parse(splittedValue[0]),
                        TotalAttempts = Convert.ToInt32(splittedValue[1]),
                        CorrectAnswers = Convert.ToInt32(splittedValue[2])
                    };

                    recordDetails.Add(record);
                }

                return recordDetails;
            });

            return task;
        }

        public Task<RecordViewModel> AddAsync(RecordToAddDTO record)
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

using Entities.Models;
using prueba.Repositories;
using System.Collections.Generic;

namespace prueba.Services
{
    public class QueueService : IQueueService
    {
        private readonly IQueueRepository _QueueRepository;

        public QueueService(IQueueRepository queueRepository)
        {
            _QueueRepository = queueRepository;
        }

        public IEnumerable<Queue> GetQueueById(int id)
        {
            return _QueueRepository.FindByCondition(x => x.Id== id); 
        }

        public IEnumerable<Queue> GetQueues()
        {
            throw new System.NotImplementedException();
        }
    }
}

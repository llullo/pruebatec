using AutoMapper;
using Entities.Models;
using prueba.Models;
using prueba.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace prueba.Services
{
    public class QueueService : IQueueService
    {
        private readonly IQueueRepository _QueueRepository;
        private readonly IMapper _mapper;


        public QueueService(IQueueRepository queueRepository, IMapper mapper)
        {
            _QueueRepository = queueRepository;
            _mapper= mapper;
        }

        public QueueDTO GetQueueById(int id)
        {
            var queue = _mapper.Map<QueueDTO>(_QueueRepository.FindByCondition(x => x.Id== id).FirstOrDefault());
            return queue;
        }

        public List<QueueDTO> GetQueues()
        {
            var queues = _QueueRepository.FindAll();
            List<QueueDTO> qList = new List<QueueDTO>();
            foreach (var q in queues)
            {
                var qDTO = _mapper.Map<QueueDTO>(q);
                qList.Add(qDTO);
            }
            return qList;
        }
    }
}

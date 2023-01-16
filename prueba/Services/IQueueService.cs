using Entities.Models;
using prueba.Models;
using System.Collections.Generic;

namespace prueba.Services
{
    public interface IQueueService
    {
        QueueDTO GetQueueById(int id);
        List<QueueDTO> GetQueues();
    }
}

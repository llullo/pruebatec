using Entities.Models;
using System.Collections.Generic;

namespace prueba.Services
{
    public interface IQueueService
    {
        IEnumerable<Queue> GetQueueById(int id);
        IEnumerable<Queue> GetQueues();
    }
}

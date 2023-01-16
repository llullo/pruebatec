using Entities.Models;

namespace prueba.Repositories
{
    public interface IQueueRepository :IRepositoryBase<Queue>
    {
        void Save();
    }
}

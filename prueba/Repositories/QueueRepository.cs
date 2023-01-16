using Entities;
using Entities.Models;

namespace prueba.Repositories
{
    public class QueueRepository : RepositoryBase<Queue>, IQueueRepository
    {
        private RepositoryContext _context;

        public QueueRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _context = repositoryContext;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

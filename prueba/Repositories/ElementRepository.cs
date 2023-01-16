using Entities;
using Entities.Models;

namespace prueba.Repositories
{
    public class ElementRepository : RepositoryBase<Element>, IElementRepository
    {
        private RepositoryContext _context;
        public ElementRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _context = repositoryContext;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

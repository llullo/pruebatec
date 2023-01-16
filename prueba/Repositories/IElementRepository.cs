using Entities.Models;

namespace prueba.Repositories
{
    public interface IElementRepository : IRepositoryBase<Element>
    {
        void Save();
    }
}

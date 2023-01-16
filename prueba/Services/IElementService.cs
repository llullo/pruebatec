using Entities.Models;
using prueba.Models;
using System.Collections.Generic;

namespace prueba.Services
{
    public interface IElementService
    {
        ElementDTO GetElementById(int id);
        List<ElementDTO> GetElements();
        List<ElementDTO> GetElementsByQueueId(int queueId);
        List<ElementDTO> GetRemainingsElements(int queueId);

        void CreateElement(ElementDTO element);
        void UpdateElement(ElementDTO element);
        void DeleteElement(ElementDTO element);
    }
}

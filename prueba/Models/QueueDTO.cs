using System.Collections.Generic;

namespace prueba.Models
{
    public class QueueDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ElementDTO> Elements { get; set; }
    }
}

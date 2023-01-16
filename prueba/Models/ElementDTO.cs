using prueba.Models.Enums;
using System;

namespace prueba.Models
{
    public class ElementDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StateEnum? State { get; set; }

        public int? QueueId { get; set; }
        public DateTime? StartDate { get; set; }
    }
}

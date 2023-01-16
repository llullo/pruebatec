using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Elements")]
    public class Element
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int State { get; set; }

        [ForeignKey(nameof(Queue))]
        public int QueueId { get; set; }
    }
}

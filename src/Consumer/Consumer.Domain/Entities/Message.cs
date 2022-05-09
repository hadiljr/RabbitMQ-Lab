using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Domain.Entities
{
    public class Message
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Value { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITest.Models
{
    public class ToDoLists
    {
        public string id { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(1)]
        public string description { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string title { get; set; }
    }
}

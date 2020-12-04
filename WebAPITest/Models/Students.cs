using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITest.Models
{
    public class Students
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Subjects> SubjectsList { get; set; }
    }
}

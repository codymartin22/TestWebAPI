using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITest.Models
{
    public class CityInfo
    {
        public int Id { get; set; }
        public int CityID { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public float lon { get; set; }
        public float lat { get; set; }
    }
}

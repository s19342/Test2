using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.DTOs.Requests
{
    public class PlayerRequest
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public int numOnShirt { get; set; }
        public string comment { get; set; }
    }
}

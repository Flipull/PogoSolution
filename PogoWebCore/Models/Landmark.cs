using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoWebCore.Models
{
    public class Landmark
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Lattitude { get; set; }
    }
}

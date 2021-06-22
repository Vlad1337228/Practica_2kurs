using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicka.Model
{
    public class Offer
    {
        public int id { get; set; }
        public Byte[] imageBytes { get; set; }
        public string country { get; set; }
        public int price_min { get; set; }
        public int count_variable { get; set; }
    }
}

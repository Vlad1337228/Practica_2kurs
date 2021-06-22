using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicka.Model
{
    public class Voucher
    {
        public int id { get; set; }
        public int sold { get; set; }
        public DateTime send { get; set; }
        public DateTime back { get; set; }
        public string excursion { get; set; }
        public string eating { get; set; }
        public string city { get; set; }
        public string country { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicka.Model
{
    public class User
    {
        public int id { get; set; }
        public int id_voucher { get; set; } 
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public short count_vouchers { get; set; }
        public short sale { get; set; } = 0;

    }
}

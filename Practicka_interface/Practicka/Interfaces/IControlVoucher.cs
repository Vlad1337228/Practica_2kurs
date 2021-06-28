using Practicka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicka.Interfaces
{
    public interface IControlVoucher
    {
        void ReturnVouchers(string country, string dep, string back, string min, string max,string city,string eat, int sale);
         void ReturnVoucher(int id_voucher);
    }
}

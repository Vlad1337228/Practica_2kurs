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
        List<Voucher> ReturnVouchers();
         Voucher ReturnVoucher(int id_voucher);
    }
}

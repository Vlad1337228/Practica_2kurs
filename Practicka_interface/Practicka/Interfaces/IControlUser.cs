using Practicka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicka.Interfaces
{
    public interface IControlUser
    {
        void RegisterUser(string name, string email, string pass);
        bool ReturnUser(string s ,string str);
    }
}

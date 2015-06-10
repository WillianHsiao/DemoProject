using DAL.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public interface ILoginRepository
    {
        LoginInfoModel LoginInfo(string Account, string Password);

        LoginInfoModel LoginInfo(Guid PK);
    }
}

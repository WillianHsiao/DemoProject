using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Service.Model;

namespace DAL.Service
{
    public interface IUserDataRepository
    {
        UserData UserData(Guid PK);
        bool UpdateUserData(UserData user);
    }
}

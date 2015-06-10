using DAL.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public class BLogin :ILoginRepository {
        protected TestDataBaseEntities db = new TestDataBaseEntities();
        public LoginInfoModel LoginInfo(string Account, string Password) {
            var query = from l in db.Logins
                        where l.Account == Account && l.Password == Password
                        select l;
            if (query.Any())
                return query.Select(q => new LoginInfoModel { PK = q.PK, UserPK = q.UserPK, Account = q.Account, Password = q.Password, UserType = q.UserData.IsEmployee ? UserType.Employee : UserType.Custom }).First();
            return null;
        }

        public LoginInfoModel LoginInfo(Guid PK)
        {
            var query = from l in db.Logins
                        where l.PK == PK
                        select l;
            if (query.Any())
                return query.Select(q => new LoginInfoModel { PK = q.PK, UserPK = q.UserPK, Account = q.Account, Password = q.Password, UserType = q.UserData.IsEmployee ? UserType.Employee : UserType.Custom }).First();
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Service.Model;

namespace DAL.Service
{
    public class BUserData : IUserDataRepository
    {
        protected TestDataBaseEntities db = new TestDataBaseEntities();

        public UserData UserData(Guid PK) {
            var query = from l in db.UserDatas
                        where l.PK == PK
                        select l;
            if (query.Any())
                return query.FirstOrDefault();
            return null;
        }

        public bool UpdateUserData(UserData user) {
            var bResult = false;
            try {
                var query = from u in db.UserDatas
                            where u.PK == user.PK
                            select u;
                foreach (var u in query) {
                    u.Name = user.Name;
                    u.M_TEL = user.M_TEL;
                    u.H_TEL = user.H_TEL;
                    u.EMAIL = user.EMAIL;
                    u.ADDR = user.ADDR;
                }
                bResult = db.SaveChanges() > 0;
            }
            catch {
                bResult = false;
            }
            return bResult;
        }
    }
}

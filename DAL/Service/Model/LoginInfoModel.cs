using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service.Model
{
    public class LoginInfoModel
    {
        public Guid PK {
            get;
            set;
        }

        public Guid UserPK {
            get;
            set;
        }

        public string Account {
            get;
            set;
        }

        public string Password {
            get;
            set;
        }

        public UserType UserType {
            get;
            set;
        }
    }

    public enum UserType {
        Employee,
        Custom
    }
}

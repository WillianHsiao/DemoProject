using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Service.Custom;
using DAL.Service.Employee;

namespace DAL.Service
{
    public static class BFactory
    {
        public static IUserDataRepository CreateUserData(string AreaName) {
            IUserDataRepository result;
            switch (AreaName) {
                case "Custom":
                    result = new CustUserData();
                    break;
                case "Employee":
                    result = new EmpUserData();
                    break;
                default:
                    result = new BUserData();
                    break;
            }

            return result;
        }

        public static IProductRepository CreateProduct(string AreaName) {
            IProductRepository result;
            switch (AreaName) {
                case "Employee":
                    result = new EmpProduct();
                    break;
                default:
                    result = new BProduct();
                    break;
            }
            return result;
        }

        public static ILoginRepository CreateLogin() {
            ILoginRepository result;
            result = new BLogin();
            return result;
        }

        public static IOrderRepository CreateOrder(string AreaName) {
            IOrderRepository result;
            switch (AreaName) {
                case "Custom":
                    result = new CustOrder();
                    break;
                case "Employee":
                    result = new EmpOrder();
                    break;
                default:
                    result = new BOrder();
                    break;
            }
            return result;
        }
    }
}

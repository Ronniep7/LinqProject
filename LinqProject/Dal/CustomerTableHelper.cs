using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinqProject.Dal
{
    public class CustomerTableHelper
    {
        public static List<Customer> GetCustomers()
        {
            string connect = Dal.DALUtils.Connection();
            List<Customer> CusList;
            DataXDataContext nw = new DataXDataContext(connect);
            var resultLambda = nw.Customers.Select(x => x);
            CusList = resultLambda.ToList();
            return CusList;
        }

        public static bool Insert(string strCusName, string strSubType,string strAge)
        {
            string connect = Dal.DALUtils.Connection();
            DataXDataContext nw = new DataXDataContext(connect);
            Customer NewCustomer = new Customer();
            NewCustomer.Name = strCusName;
            NewCustomer.Subscription_Type = strSubType;
            NewCustomer.Age_ = int.Parse(strAge);
            bool InsertGood = false;
            if (NewCustomer != null)
            {
                InsertGood = true;
            }
            nw.Customers.InsertOnSubmit(NewCustomer);
            nw.SubmitChanges();

            return InsertGood;
        }

        public static bool CusExist(string Customer)
        {
            string connect = Dal.DALUtils.Connection();
            List<Customer> CusList2;
            DataXDataContext nw = new DataXDataContext(connect);
            var LambToList = nw.Customers.Select(x => x);
            CusList2 = LambToList.ToList();
            bool exist = false;
            foreach (var item in CusList2)
            {

                if (item.Name == Customer)
                    exist = true;

            }
            return (exist);
        }



    }
}
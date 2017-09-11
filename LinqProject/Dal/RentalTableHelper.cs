using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinqProject.Dal
{
    public class RentalTableHelper
    {
        public static List<Rental> GetRentals()
        {
            string connect = Dal.DALUtils.Connection();
            List<Rental> RenList;
            DataXDataContext nw = new DataXDataContext(connect);
            var resultLambda = nw.Rentals.Select(x => x);
            RenList = resultLambda.ToList();
            return RenList;
        }
        public static bool RentalExist(int MovieID)
        {
            List<Rental> ex = Dal.RentalTableHelper.GetRentals();
            bool exist = ex.Exists(item => item.MovieID == MovieID);

            return (exist);
        }
        public static bool Insert(int movid, int cusid)
        {

            string connect = Dal.DALUtils.Connection();
            DataXDataContext nw = new DataXDataContext(connect);
            Rental NewRental = new Rental();
            NewRental.MovieID = movid;
            NewRental.CustomerID = cusid;
            bool InsertGood = false;
            if (NewRental != null)
            {
                InsertGood = true;
            }
            nw.Rentals.InsertOnSubmit(NewRental);
            nw.SubmitChanges();

            return InsertGood;
        }

        public static int GetID(string MovieName)
        {
            int MoviD = 0;
            string connect = Dal.DALUtils.Connection();
            DataXDataContext nw = new DataXDataContext(connect);
            var resultLambda = nw.Movies.Where(x => x.Name == MovieName).Select(x => x.Id);
            foreach (var item in resultLambda)
            {
                MoviD = item;

            }
            return MoviD;
        }

        public static int GetCusID(string CustomerName)
        {
            int CusiD = 0;
            string connect = Dal.DALUtils.Connection();
            DataXDataContext nw = new DataXDataContext(connect);
            var resultLambdaCus = nw.Movies.Where(x => x.Name == CustomerName).Select(x => x.Id);
            foreach (var item in resultLambdaCus)
            {
                CusiD = item;

            }
            return CusiD;
        }

    }
}
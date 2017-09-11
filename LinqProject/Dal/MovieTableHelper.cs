using LinqProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinqProject.Dal
{
    public class MovieTableHelper
    {

        public static List<Movie> GetMovies()
        {
            string connect = Dal.DALUtils.Connection();
            List<Movie> MovList;
            DataXDataContext nw = new DataXDataContext(connect);
            var resultLambda = nw.Movies.Select(x => x);
            MovList = resultLambda.ToList();
            return MovList;
        }

        public static bool Insert(string strMovieName, string strCategoryName)
        {
            
            string connect = Dal.DALUtils.Connection();
            DataXDataContext nw = new DataXDataContext(connect);
            Movie NewMovie = new Movie();
            NewMovie.Name = strMovieName;
            NewMovie.Category = strCategoryName;
            bool InsertGood = false;
            if (NewMovie!=null)
            {
                InsertGood = true;
            }
            nw.Movies.InsertOnSubmit(NewMovie);
            nw.SubmitChanges();

            return InsertGood;
        }

        public static bool MovExist (string Movie)
        {
            string connect = Dal.DALUtils.Connection();
            List<Movie> MovList2;
            DataXDataContext nw = new DataXDataContext(connect);
            var LambToList = nw.Movies.Select(x => x);
            MovList2 = LambToList.ToList();
            bool exist = false;
            foreach (var item in MovList2)
            {

                if (item.Name == Movie)
                    exist = true;

            }
            return (exist);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinqProject.Controllers
{
    public class RentalController : Controller
    {
        // GET: Rental
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateNewRentals(string CustomerName, string MovieName)
        {
            bool isfree = true;
            string Messege = "";
            if (CustomerName == "")
            {
                Messege = "Please Enter A Customer(Server)";
                isfree = false;
            }
            else if (MovieName == "")
            {
                Messege = "Please Enter A Movie(Server)";
                isfree = false;
            }
            else
            {
                bool Movex = Dal.MovieTableHelper.MovExist(MovieName);
                bool Cusex = Dal.CustomerTableHelper.CusExist(CustomerName);
                if (Movex == false)
                {
                    Messege = "Movie NOT Exist";
                    isfree = false;
                }
                if (Cusex == false)
                {
                    Messege = "customer NOT Exist";
                    isfree = false;

                }
                if (Movex == true && Cusex == true)
                {
                    int Idofmov = Dal.RentalTableHelper.GetID(MovieName);
                    bool ex = Dal.RentalTableHelper.RentalExist(Idofmov);

                    if (ex)
                    {
                        Messege = "Movie Already Rented";
                        isfree = false;

                    }
                    else
                    {
                        int cusResult = Dal.RentalTableHelper.GetCusID(CustomerName);

                        bool insertsuccess = Dal.RentalTableHelper.Insert(Idofmov, cusResult);
                        if (insertsuccess)
                        {
                            Messege = "Movie Rented successfully";

                        }
                        else
                        {
                            Messege = "Movie Rent Failed ";

                        }


                    }



                }


            }

            var obj = new { Messege1 = Messege, isfree1 = isfree };

            return Json(obj);
        }
    }
}
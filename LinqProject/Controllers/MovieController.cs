using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinqProject.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            List<Movie> lis = Dal.MovieTableHelper.GetMovies();

            return View(lis);
        }
        public ActionResult New()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult MovieSave(string Moviename, string CatName)
        {
            bool isvalid = Moviename == "" || CatName == "Select";
            if (isvalid)
            {

                if (Moviename == "")
                {
                    ViewBag.NameERROR = "Please Enter A Movie Name(SERVER)";
                    return View("New");
                }
                
                ViewBag.ERROR = "Please Fill In All The Details(server)";

                return View("New");
            }
            else
            {
                bool Exist = Dal.MovieTableHelper.MovExist(Moviename);

                if (Exist)
                {
                    ViewBag.ERROR = "Movie Already Exist(server)";
                    return View("New");
                }
                else
                {
                    bool Insert = Dal.MovieTableHelper.Insert(Moviename, CatName);

                    if (Insert)
                    {
                        return RedirectToAction("Index", "Movie");
                    }
                    else
                    {
                        ViewBag.ERROR = "Insert Failed";
                        return View("New");
                    }


                }

            }

            
               
        }
        
    }
}
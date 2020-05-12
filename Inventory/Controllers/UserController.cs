using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Inventory.Models;
using Inventory.App_Code;
namespace Inventory.Controllers
{
    public class UserController : Controller
    {
        api.UserController user = new api.UserController();
        List<ModelBooks> lstBooks = new List<ModelBooks>();
        public ModelBooks modelBooks = new ModelBooks();
        // GET: User
        public ActionResult Index(String Search)
        {
            lstBooks = new List<ModelBooks>();
           if(!String.IsNullOrEmpty(Search))
            {
                lstBooks = user.Get(Search);
            }
           else
            {
                lstBooks = user.Get();
            }
            return View(lstBooks);
        }
        public ActionResult Create(ModelBooks _modelBooks)
        {


            return View();
        }
        public ActionResult Edit(ModelBooks _modelBooks)
        {
            return View();
        }
        public ActionResult New(ModelBooks _modelBooks)
        {
            modelBooks = _modelBooks;
            ViewBag.Message = user.Create(modelBooks);

            return View("Index");
        }
        public ActionResult EditBook(ModelBooks _modelBooks)
        {
            modelBooks = _modelBooks;
            ViewBag.Message = user.Create(modelBooks);

            return View("Index");
        }
        public ActionResult Delete(Int32 Id)
        {
            user.Delete(Id);
            return View("Index");
        }
        public ActionResult Search(String Search)
        {
            return View("Index");
        }
       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetGuru.Models;
using BudgetGuru;

namespace BudgetGuru.Controllers
{


    public class MovieController : Controller
    {
        private BudgetDBEntities _db = new BudgetDBEntities();
        // GET: Movie
        public ActionResult Index()
        {
            return View(_db.Movies.ToList());
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            var movieToDisplay = (from m in _db.Movies
                               where m.Id == id
                               select m).First();
            return View(movieToDisplay);
            
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude ="Id")]Movie movieToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            _db.Movies.Add(movieToCreate);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            var movieToEdit = (from m in _db.Movies
                               where m.Id == id
                               select m).First();
            return View(movieToEdit);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(Movie movieToEdit)
        {
            var originalMovie = (from m in _db.Movies
                                 where m.Id == movieToEdit.Id
                                 select m).First();

            if (!ModelState.IsValid)
                return View(originalMovie);

            _db.Entry(originalMovie).CurrentValues.SetValues(movieToEdit);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            var movieToDelete = (from m in _db.Movies
                               where m.Id == id
                               select m).First();
            return View(movieToDelete);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(Movie movieToDelete)
        {
            var originalMovie = (from m in _db.Movies
                                where m.Id == movieToDelete.Id
                                select m).First();

            if (!ModelState.IsValid)
                return View(originalMovie);

            _db.Movies.Remove(originalMovie);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

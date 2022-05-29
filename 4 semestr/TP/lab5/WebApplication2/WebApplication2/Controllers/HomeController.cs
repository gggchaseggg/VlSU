using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DAO;
using WebApplication2.Models;
using MySql.Data.MySqlClient;


namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        NewsDAO newsDAO = new NewsDAO();

        // GET: Home
        public ActionResult Index()
        {
            return View(newsDAO.GetAllNews());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View(newsDAO.GetNews(id));
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "ID")] News news)
        {
            try
            {
                if (newsDAO.AddNews(news))
                    return RedirectToAction("Index");
                else
                    return View("Create");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(News news)
        {
            try
            {
                // TODO: Add update logic here
                //View(newsDAO.GetNews(news.ID));
                if (newsDAO.EditNews(news))
                {
                    return RedirectToAction("Index");
                } else
                {
                    return View("Edit");
                }
                
            }
            catch
            {
                return View("Edit");
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (newsDAO.DeleteNews(id))
                {
                    return RedirectToAction("Index");
                } else
                {
                    return View("Delete");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}

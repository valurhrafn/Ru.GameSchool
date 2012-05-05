﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ru.GameSchool.DataLayer.Repository;

namespace Ru.GameSchool.Web.Controllers
{
    public class LevelController : BaseController
    {
        //
        // GET: /Level/

        [Authorize(Roles = "Student")]
        public ActionResult Get(int id)
        {
            return View();
        }


        //[Authorize(Roles = "Teacher")]
        public ActionResult Create()
        //public ActionResult Create(int CoureId)
        {
            //ViewBag.categoryId =
            ViewBag.CourseList = new SelectList(CourseService.GetCourses(), "CourseId", "Name"); 
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public ActionResult Create(Level level)
        {
            if (ModelState.IsValid)
            {

                level.CreateDateTime = DateTime.Now;

                LevelService.CreateLevel(level);
                
            }

            return RedirectToAction("Edit", new { Id = level.LevelId });
        }



        //[Authorize(Roles = "Teacher")]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var model = LevelService.GetLevel(id.Value);
                return View(model);
            }

            return View();
        }


        [HttpPost]
        //[Authorize(Roles = "Teacher")]
        public ActionResult Edit(Level model, int? id)
        {
            if (ModelState.IsValid)
            {
                var level = LevelService.GetLevel(model.LevelId);

                if (TryUpdateModel(level))
                {
                    LevelService.UpdateLevel(level);
                }
            }

            return View(model);
        }
        /*
        public ActionResult Statistics(int id)
        {
            return View();
        }*/

    }
}

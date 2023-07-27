using Academic.Core;
using Academic.Core.Repositories;
using Academic.Core.Repositories.Interfaces;
using Academic.Domian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Academic.Web.Controllers
{
    public class TeacherCourseController : Controller
    {
        [AutenticatedFilter]
        // GET: TeacherCourse
        public async Task<ActionResult> Index()
        {
            ICourseRepository _courseRepository = new CourseRepository();
            var teacherCourse =await  _courseRepository.GetAllbyTeacher(1);
            return View(new {teacherCourses = teacherCourse});
        }

        // GET: TeacherCourse/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TeacherCourse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherCourse/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherCourse/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TeacherCourse/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherCourse/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeacherCourse/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

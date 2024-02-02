using EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainProjectMVC.Controllers
{
    public class StudValuesController : Controller
    {
        private readonly IStudentsRepository _Result;
        private readonly string _connectionstring;
        public StudValuesController(IStudentsRepository res, IConfiguration configuration)
        {
            _Result = res;
            _connectionstring = configuration.GetConnectionString("DbConnection");
        }

        // GET: StudValuesController
        public ActionResult Index()
        {
            var Results = _Result.GetAllDetails();
            return View("List",Results);
        }

        // GET: StudValuesController/Details/5
        public ActionResult Details(long id)
        {
            var pro = _Result.GetbyID(id);
            return View("Details", pro);
        }

        // GET: StudValuesController/Create
        //both create and edit in single view control for GET method
        public ActionResult Create(long ? id)
        {
            if (id.HasValue)
            {
                var final = _Result.GetbyID(id.Value);
              
                return View("Create", final);
            }
            else
            {
                var final = new StudentDetails();
                return View ("Create", final);
            }
        }

        // POST: StudValuesController/Create
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        //both create and edit in single view control for POST method
        public ActionResult Creates(StudentDetails final)
        {
            try
            {
                if(final.StudentID==0)
                {
                    _Result.Insert(final);

                }
                else
                {
                    _Result.Update(final.StudentID, final);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: StudValuesController/Delete/5
        public ActionResult Delete(int id)
        {
            var pro = _Result.GetbyID(id);
            return View("Delete", pro);
        }

        // POST: StudValuesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deleteid(int StudentID)
        {

            try
            {
                _Result.Delete(StudentID);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        [Route("~/api/subjects")]
        public ActionResult Sub()
        {
            try
            {
                var sub = Allsubject();
                return Ok(sub.ToList());
            }
            catch(Exception )
            {
                return View();
            }
        }

        private List<SubjectsModel>Allsubject()
        {
            List<SubjectsModel> subjects = new List<SubjectsModel>();
            SubjectsModel detail = new SubjectsModel();
            detail.ID = 1;
            detail.Subjectname = "CSE";
            subjects.Add(detail);
            SubjectsModel result = new SubjectsModel();
            result.ID = 2;
            result.Subjectname = "Physics";
            subjects.Add(result);
            SubjectsModel final = new SubjectsModel();
            final.ID = 3;
            final.Subjectname = "Commerce";
            subjects.Add(final);
            return subjects;
        }
    }
}

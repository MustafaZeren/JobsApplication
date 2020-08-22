using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsApplication.Models;
using JobsApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobsApplication.Controllers
{
    public class JobsController : Controller
    {
        private readonly Service jobService;

        public JobsController(Service jobService)
        {
            this.jobService = jobService;
        }

        // GET: Jobs
        public ActionResult Index()
        {
            return View(jobService.Get());
        }

        // GET: Jobs
        public ActionResult IndexSortByMonths()
        {
            return View(jobService.Get());
        }

        // GET: Jobs
        public ActionResult IndexSortByWeeks()
        {
            return View(jobService.Get());
        }



        // GET: Jobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                jobService.Create(job);
                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = jobService.Get(id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var job = jobService.Get(id);

                if (job == null)
                {
                    return NotFound();
                }

                jobService.Remove(job.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
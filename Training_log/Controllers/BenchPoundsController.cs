using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training_log.Models;
using Training_log.ViewModels;

namespace Training_log.Controllers
{
    public class BenchPoundsController : Controller
    {
        // GET: BenchPounds
        public ActionResult Index()
        {
            using (Weight_TrainingDBEntitiesCTX db = new Weight_TrainingDBEntitiesCTX())
            {
                var liftBench = db.Benches;
                var benchVMList = new List<LiftsVM>();

                foreach (var lift in liftBench)
                {
                    var benchVM = new LiftsVM();
                    benchVM.Date = lift.DateOfLift;
                    benchVM.WeightLifted = lift.WeightKG;
                    benchVM.Reps = lift.Repetitions;

                    benchVMList.Add(benchVM);
                }
                return View(benchVMList);
            }

                
            
        }
    }
}
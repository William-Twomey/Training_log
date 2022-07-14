using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training_log.Models;
using Training_log.ViewModels;

namespace Training_log.Controllers
{
    public class DeadliftPoundsController : Controller
    {
        // GET: Weights
        public ActionResult Index()
        {
            using(Weight_TrainingDBEntitiesCTX db = new Weight_TrainingDBEntitiesCTX())
            {
                var liftDead = db.Deadlifts;

                var liftView = new List<LiftsVM>();

                foreach (var lift in liftDead)
                {
                    var deadVM = new LiftsVM();
                    
                    deadVM.Id = lift.Id;
                    deadVM.Date = lift.DateOfLift;
                    deadVM.WeightLifted = lift.WeightKG * 2.205;
                    deadVM.Reps = lift.Repetitions;

                    liftView.Add(deadVM);
                }
                return View(liftView);

            }
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training_log.Models;
using Training_log.ViewModels;

namespace Training_log.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using(Weight_TrainingDBEntitiesCTX db = new Weight_TrainingDBEntitiesCTX())
            {
                var squatLift = db.Squats;
                var benchLift = db.Benches;
                var deadLift = db.Deadlifts;


                foreach(var squat in squatLift)
                {
                    var squatVM = new LiftsVM();

                    squatVM.Date = squat.DateOfLift;
                    var squatDate = squat.DateOfLift.ToString("dd/MM/yyyy");


                    squatVM.WeightLifted = squat.WeightKG;
                    squatVM.Reps = squat.Repetitions;

                    ViewBag.SquatLiftDate = squatDate;
                    ViewBag.SquatLiftWeight = squatVM.WeightLifted;
                    ViewBag.SquatLiftReps = squatVM.Reps;
                    
                }

                foreach (var bench in benchLift)
                {
                    var benchVM = new LiftsVM();

                    benchVM.Date = bench.DateOfLift;
                    benchVM.WeightLifted = bench.WeightKG;
                    benchVM.Reps = bench.Repetitions;
                    
                    //Converting to date format dd/mm/yyyy to get rid of timestamp
                    var benchDate = bench.DateOfLift.ToString("dd/MM/yyyy");

                    ViewBag.BenchLiftDate = benchDate;
                    ViewBag.BenchLiftWeight = benchVM.WeightLifted;
                    ViewBag.BenchLiftReps = benchVM.Reps;

                }

                foreach (var dead in deadLift)
                {
                    var deadVM = new LiftsVM();

                    deadVM.Date = dead.DateOfLift;
                    //Converting to date format dd/mm/yyyy to get rid of timestamp
                    var deadDate = dead.DateOfLift.ToString("dd/MM/yyyy");
                    
                    deadVM.WeightLifted = dead.WeightKG;
                    deadVM.Reps = dead.Repetitions;

                    ViewBag.DeadLiftDate = deadDate;
                    ViewBag.DeadLiftWeight = deadVM.WeightLifted;
                    ViewBag.DeadLiftReps = deadVM.Reps;

                }
            }
            return View();
        }
    }
}
                    
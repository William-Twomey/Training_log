using System.Collections.Generic;
using System.Web.Mvc;
using Training_log.Models;
using Training_log.ViewModels;

namespace Training_log.Controllers
{
    public class SquatPoundsController : Controller
    {

        // GET: SquatPounds
        public ActionResult Index()
        {
            using (Weight_TrainingDBEntitiesCTX db = new Weight_TrainingDBEntitiesCTX())
            {
                var liftSquat = db.Squats;

                var liftView = new List<LiftsVM>();

                foreach (var lift in liftSquat)
                {
                    var squatVM = new LiftsVM();

                    squatVM.Id = lift.Id;
                    squatVM.Date = lift.DateOfLift;
                    squatVM.WeightLifted = lift.WeightKG * 2.205;
                    squatVM.Reps = lift.Repetitions;

                    liftView.Add(squatVM);
                }
                return View(liftView);

            }
        }
    }
}

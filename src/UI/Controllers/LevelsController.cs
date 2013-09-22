using System.Linq;
using System.Web.Mvc;
using Mono.CSharp;
using TryCSharp.Models;

namespace TryCSharp.Controllers
{
    public abstract class EvaluatorController : Controller
    {
        private static readonly string EVALUATOR_KEY = "evaluator";
        private static readonly CompilerContext context = new CompilerContext(new CompilerSettings(), new ConsoleReportPrinter());

        public Evaluator EvaluatorSession { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            EvaluatorSession = this.ControllerContext.HttpContext.Session[EVALUATOR_KEY] as Evaluator;

            if (EvaluatorSession == null)
            {
                this.ControllerContext.HttpContext.Session[EVALUATOR_KEY] = new Evaluator(context);
                EvaluatorSession = this.ControllerContext.HttpContext.Session[EVALUATOR_KEY] as Evaluator;
            }
        }
    }

    public class LevelsController : EvaluatorController
    {

        public ActionResult Index()
        {
            var model = Tutorial.TutorialData().Steps.First(step => step.Level == 1 && step.Challenge == 1);

            return View(model);
        }

        public ActionResult Next(int level, int challenge)
        {
            int index =
                Tutorial.TutorialData()
                        .Steps.Select((step, i) => new { Index = i, Step = step }).First(indexedStep => indexedStep.Step.Level == level && indexedStep.Step.Challenge == challenge).Index;

            index++;

            var nextChallenge = Tutorial.TutorialData().Steps.ToArray()[index];

            return new JsonResult() { Data = nextChallenge, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Previous(int level, int challenge)
        {
            int index =
                Tutorial.TutorialData()
                        .Steps.Select((step, i) => new { Index = i, Step = step }).First(indexedStep => indexedStep.Step.Level == level && indexedStep.Step.Challenge == challenge).Index;

            index--;

            var previousChallenge = Tutorial.TutorialData().Steps.ToArray()[index];

            return new JsonResult() { Data = previousChallenge, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult Terminal(string command, int level, int challenge)
        {
            object result;
            bool result_set;
            EvaluatorSession.Evaluate(command, out result, out result_set);

            return new JsonResult() { Data = new { result = result, result_set = result_set } };
        }
    }
}

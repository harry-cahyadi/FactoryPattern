using Experiment.Lib.Core;
using Experiment.Lib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Experiment.Web.Controllers
{
    public class ExperimentController : Controller
    {
        private IFactory<IModule> _moduleFactory;
        private IModule _module;

        public ExperimentController(IFactory<IModule> moduleFactory)
        {
            _moduleFactory = moduleFactory;
            _module = moduleFactory.GetInstance(DI.DependencyVersion);
        }

        // GET: Experiment
        public ActionResult Index()
        {
            var model = new Models.Experiment { Something = _module.PrintSomething() };

            return View(model);
        }

        public ActionResult SwitchModule(string version)
        {
            DI.DependencyVersion = version;

            _module = _moduleFactory.GetInstance(version);

            var model = new Models.Experiment { Something = _module.PrintSomething() };

            return View("Index", model);
        }
    }
}
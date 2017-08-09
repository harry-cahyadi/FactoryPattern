using Experiment.Lib.Core;
using Experiment.Lib.Interface;
using Experiment.Web.Models;
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
        private IFactory<IOtherModule> _otherModuleFactory;
        private IModule _module;
        private IOtherModule _otherModule;

        public ExperimentController(
            IFactory<IModule> moduleFactory,
            IFactory<IOtherModule> otherModuleFactory)
        {
            _moduleFactory = moduleFactory;
            _otherModuleFactory = otherModuleFactory;
            _module = moduleFactory.GetInstance(DI.GetDependencyVersion<IModule>());
            _otherModule = otherModuleFactory.GetInstance(DI.GetDependencyVersion<IOtherModule>());
        }

        // GET: Experiment
        public ActionResult Index()
        {
            var model = new Models.Experiment {
                Something = _module.PrintSomething(),
                SomethingElse = _otherModule.PrintSomethingElse()
            };

            return View(model);
        }

        public JsonResult SwitchModule(DependencyManifest manifest)
        {
            if (manifest == null || manifest.Dependencies == null || !manifest.Dependencies.Any())
                return Json(new { success = false, ActiveVersions = DI.DependencyVersions }, JsonRequestBehavior.AllowGet);

            var dependenciesVersions = new Dictionary<string, string>();

            foreach (var dependency in manifest.Dependencies)
                dependenciesVersions.Add(dependency.Namespace, dependency.Version);

            DI.DependencyVersions = dependenciesVersions;

            return Json(new { ActiveVersions = DI.DependencyVersions }, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Experiment.Web.Models
{
    public class DependencyManifest
    {
        public List<Dependency> Dependencies { get; set; }
    }

    public class Dependency
    {
        public string Namespace { get; set; }

        public string Version { get; set; }
    }
}
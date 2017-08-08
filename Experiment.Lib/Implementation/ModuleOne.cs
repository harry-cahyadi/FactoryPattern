using Experiment.Lib.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Experiment.Lib.Implementation
{
    public class ModuleOne : IModule
    {
        public string PrintSomething()
        {
            return "This is ModuleOne";
        }
    }
}

using Experiment.Lib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiment.Lib.Implementation
{
    public class OtherModuleOne : ModuleOne, IOtherModule
    {
        public string PrintSomethingElse()
        {
            return "This is something else from OtherModuleOne";
        }
    }
}

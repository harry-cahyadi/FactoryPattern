using System;
using System.Collections.Generic;
using System.Text;

namespace Experiment.Lib.Interface
{
    public interface IFactory<T> where T : class
    {
        T GetInstance(string version = "default");
    }
}

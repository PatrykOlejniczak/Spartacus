using System.Collections.Generic;
using Spartacus.Common;

namespace Spartacus.Generator.Terms
{
    public interface ITermCalculator
    {
        void Calculate(List<Example> examples);
    }
}
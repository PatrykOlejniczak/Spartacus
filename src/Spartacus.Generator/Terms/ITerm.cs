using Spartacus.Common;
using System.Collections.Generic;

namespace Spartacus.Generator.Terms
{
    public interface ITerm
    {
        void Calculate(List<Example> examples);
    }
}
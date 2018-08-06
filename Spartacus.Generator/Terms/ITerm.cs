using System.Collections.Generic;
using Spartacus.Common;

namespace Spartacus.Generator.Terms
{
    public interface ITerm
    {
        void Calculate(List<Example> examples);
    }
}
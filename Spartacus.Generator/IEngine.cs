using System.Collections.Generic;
using Spartacus.Common;

namespace Spartacus.Generator
{
    public interface IEngine
    {
        List<Example> Generate(GenerateParameter parameters);
    }
}
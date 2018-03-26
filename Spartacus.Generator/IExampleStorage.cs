using System.Collections.Generic;
using Spartacus.Common;

namespace Spartacus.Generator
{
    public interface IExampleStorage
    {
        void Save(IList<Example> examples, string fileName);
    }
}
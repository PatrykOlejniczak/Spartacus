using System.Collections.Generic;
using Spartacus.Common;

namespace Spartacus.Generator.Storage
{
    public interface IStorage
    {
        void Save(List<Example> examples);
    }
}
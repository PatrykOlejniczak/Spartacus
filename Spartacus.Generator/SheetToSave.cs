using Spartacus.Common;
using System.Collections.Generic;

namespace Spartacus.Generator
{
    public class SheetToSave
    {
        public string SheetName { get; set; }

        public List<Example> Examples { get; set; }
    }
}
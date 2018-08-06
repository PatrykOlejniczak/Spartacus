using Spartacus.Common;
using System.Collections.Generic;

namespace Spartacus.Generator.Storage.Excel
{
    public class Sheet
    {
        public string Name { get; set; }

        public List<Example> Data { get; set; }
    }
}
﻿using System.Collections.Generic;
using Spartacus.Common;

namespace Spartacus.Generator
{
    public class SheetToSave
    {
        public string SheetName { get; set; }

        public List<Example> Examples { get; set; }
    }
}
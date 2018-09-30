using Spartacus.Common.Types;

namespace Spartacus.Common.Extensions
{
    public static class ExampleTypeExtenions
    {
        public static string Check(this ExampleType exampleType, ExampleType expected)
        {
            return exampleType == expected ? "0" : "1";
        }
    }
}
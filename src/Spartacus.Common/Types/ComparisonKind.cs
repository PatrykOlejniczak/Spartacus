using System.ComponentModel;

namespace Spartacus.Common.Types
{
    public enum ComparisonKind
    {
        [Description("<")]
        Less,
        [Description("<=")]
        LessOrEqual,
        [Description("=")]
        Equal,
        [Description(">=")]
        GreaterOrEqual,
        [Description(">")]
        Greater,
        [Description("!=")]
        NotEqual
    }
}

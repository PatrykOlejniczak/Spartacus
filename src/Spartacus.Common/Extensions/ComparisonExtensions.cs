using Spartacus.Common.Types;
using System;

namespace Spartacus.Common.Extensions
{
    public static class ComparisonExtensions
    {
        public static bool Verify(this ComparisonKind comparisonKind, double leftPart, double rightPart)
        {
            switch (comparisonKind)
            {
                case ComparisonKind.Less:
                    return leftPart < rightPart;
                case ComparisonKind.LessOrEqual:
                    return leftPart <= rightPart;
                case ComparisonKind.Equal:
                    return Math.Abs(leftPart - rightPart) < Double.Epsilon;
                case ComparisonKind.GreaterOrEqual:
                    return leftPart >= rightPart;
                case ComparisonKind.Greater:
                    return leftPart > rightPart;
                case ComparisonKind.NotEqual:
                    return Math.Abs(leftPart - rightPart) > Double.Epsilon;
                default:
                    throw new ArgumentOutOfRangeException(nameof(comparisonKind), comparisonKind, null);
            }
        }
    }
}
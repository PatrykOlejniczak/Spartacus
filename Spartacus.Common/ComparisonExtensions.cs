using System;

namespace Spartacus.Common
{
    public static class ComparisonExtensions
    {
        public static bool Verify(this Comparison comparison, double leftPart, double rightPart)
        {
            switch (comparison)
            {
                case Comparison.Less:
                    return leftPart < rightPart;
                case Comparison.LessOrEqual:
                    return leftPart <= rightPart;
                case Comparison.Equal:
                    return Math.Abs(leftPart - rightPart) < Double.Epsilon;
                case Comparison.GreaterOrEqual:
                    return leftPart >= rightPart;
                case Comparison.Greater:
                    return leftPart > rightPart;
                case Comparison.NotEqual:
                    return Math.Abs(leftPart - rightPart) > Double.Epsilon;
                default:
                    throw new ArgumentOutOfRangeException(nameof(comparison), comparison, null);
            }
        }
    }
}
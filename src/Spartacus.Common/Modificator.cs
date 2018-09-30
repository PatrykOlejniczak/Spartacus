namespace Spartacus.Common
{
    public class Modificator
    {
        public double Weight { get; } = 1;
        public double Shift { get; } = 0;

        public Modificator()
        { }

        public Modificator(double weight, double shift)
        {
            Weight = weight;
            Shift = shift;
        }
    }
}
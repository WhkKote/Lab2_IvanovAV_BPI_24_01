using System;

namespace Lab2_IvanovAV_BPI_24_01
{
    public class Formula1 : Formula
    {
        public double A { get; set; }
        public int F { get; set; }

        public Formula1(double a, int f) : base("p1.png")
        {
            A = a;
            F = f;
        }

        public override double Calculate()
        {
            return Math.Sin(F * A);
        }
    }
}
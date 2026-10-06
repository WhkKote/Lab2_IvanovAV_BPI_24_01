using System;

namespace Lab2_IvanovAV_BPI_24_01
{
    public class Formula2 : Formula
    {
        public double A { get; set; }
        public double B { get; set; }
        public int F { get; set; }

        public Formula2(double a, double b, int f) : base("p2.png")
        {
            A = a;
            B = b;
            F = f;
        }

        public override double Calculate()
        {
            return Math.Cos(F * A) + Math.Sin(F * B);
        }
    }
}
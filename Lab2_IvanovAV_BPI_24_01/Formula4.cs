using System;

namespace Lab2_IvanovAV_BPI_24_01
{
    public class Formula4 : Formula
    {
        public double A { get; set; }
        public int C { get; set; }
        public int D { get; set; }

        public Formula4(double a, int c, int d) : base("p4.png")
        {
            A = a;
            C = c;
            D = d;
        }

        public override double Calculate()
        {
            double result = 0;

            for (int i = 0; i <= D; i++)
                result += Math.Pow(C + A, i);

            return result;
        }
    }
}
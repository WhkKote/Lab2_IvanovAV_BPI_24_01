using System;

namespace Lab2_IvanovAV_BPI_24_01
{
    public class Variant4Formula : Formula
    {
        public int N { get; set; }
        public int K { get; set; }
        public double X { get; set; }
        public double F { get; set; }
        public double Y { get; set; }

        public Variant4Formula(int n, int k, double x, double f, double y) : base("p5.png")
        {
            N = n;
            K = k;
            X = x;
            F = f;
            Y = y;
        }

        public override double Calculate()
        {
            double result = 0;
            double sinX = Math.Sin(X);

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= K; j++)
                {
                    result += (sinX * Math.Pow(X, i) + Math.Pow(F, j) * Math.Pow(Y, j)) / (i * j);
                }
            }

            return result;
        }
    }
}
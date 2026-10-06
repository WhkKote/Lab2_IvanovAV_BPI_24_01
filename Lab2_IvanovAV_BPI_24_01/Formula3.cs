namespace Lab2_IvanovAV_BPI_24_01
{
    public class Formula3 : Formula
    {
        public double A { get; set; }
        public double B { get; set; }
        public int C { get; set; }
        public int D { get; set; }

        public Formula3(double a, double b, int c, int d) : base("p3.png")
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public override double Calculate()
        {
            return C * A * A + D * B * B;
        }
    }
}
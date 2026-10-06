namespace Lab2_IvanovAV_BPI_24_01
{
    public abstract class Formula
    {
        public string Source { get; set; }

        protected Formula(string source)
        {
            Source = source;
        }

        public abstract double Calculate();
    }
}
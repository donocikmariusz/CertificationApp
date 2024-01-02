namespace CertificationApp
{
    public class Statistics
    {
        public float DailyMin { get; private set; }
        public float DailyMax { get; private set; }
        public float Average
        {
            get
            {
                return this.Sum / this.Count;
            }
        }
        public float Sum { get; private set; }
        public string SumAssessment { get; set; }
        public int Count { get; private set; }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.DailyMax = float.MinValue;
            this.DailyMin = float.MaxValue;
        }

        public void AddKilometers(float kilometers)
        {
            this.Count++;
            this.Sum += kilometers;
            this.DailyMin = Math.Min(kilometers, this.DailyMin);
            this.DailyMax = Math.Max(kilometers, this.DailyMax);
        }
    }
}

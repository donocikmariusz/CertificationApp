
namespace CertificationApp
{
    public class Statistics
    {
        public float dailyMin { get; private set; }
        public float dailyMax { get; private set; }
        public float Average {       
            get
            {
                return this.Sum / this.Count;
            }
        }
        public float Sum { get; private set; }
        public string SumAssesment { get; set; }
        public int Count { get; private set; }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.dailyMax = float.MinValue;
            this.dailyMin = float.MaxValue;
        }

        public void AddKilometers(float kilometers)
        {
            this.Count++;
            this.Sum += kilometers;
            this.dailyMin = Math.Min(kilometers, this.dailyMin);
            this.dailyMax = Math.Max(kilometers, this.dailyMax);
        }

    }
}


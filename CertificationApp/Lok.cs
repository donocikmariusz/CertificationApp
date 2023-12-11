
using System.ComponentModel;

namespace CertificationApp
{
    public class Lok
    {
        private List<float> kilometers = new List<float>();

        public Lok(string type, string serialNumber)
        {
            this.Type = type;
            this.SerialNumber = serialNumber;
        }

        public string Type { get; private set; }
        public string SerialNumber { get; private set; }

        public void AddKilometer(float kilometer)
        {

            if (kilometer > 0)
            {
                this.kilometers.Add(kilometer);
            }
            else if (kilometer < 0)
            {
                Console.WriteLine("Kilometry przejechane się już nie odprzejadą");
            }
            else
            {
                Console.WriteLine("Bez sensu dodawać kilometry jak ich wartosć to 0");
            }
        }
        public void AddKilometer(string kilometer)
        {
            if (float.TryParse(kilometer, out float result))
            {
                this.AddKilometer(result);
            }
            else
            {
                Console.WriteLine("String is not float");
            }
        }


        public Statistics GetStatistics()
        {
            var statistics = new Statistics();
            statistics.Average = 0;
            statistics.Sum = 0;
            statistics.dailyMax = float.MinValue;
            statistics.dailyMin = float.MaxValue;

            foreach (var kilometer in this.kilometers)
            {
                statistics.dailyMax = Math.Max(statistics.dailyMax, kilometer);
                statistics.dailyMin = Math.Min(statistics.dailyMin, kilometer);
                statistics.Sum += kilometer;
            }

            statistics.Average = statistics.Sum / this.kilometers.Count;

            return statistics;

        }
    }
}

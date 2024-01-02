namespace CertificationApp
{
    public abstract class LokBase : ILok
    {
        public delegate void KilometersAddedDelegate(object sender, EventArgs args);
        public event KilometersAddedDelegate KilometersAdded;

        public LokBase(string type, string serialNumber)
        {
            this.Type = type;
            this.SerialNumber = serialNumber;
        }
        public string Type { get; private set; }
        public string SerialNumber { get; private set; }
        public abstract void AddKilometer(float kilometer);

        public abstract Statistics GetStatistics();

        public void AddKilometer(int kilometer)
        {
            float kilometerAsFloat = kilometer;
            this.AddKilometer(kilometerAsFloat);
        }

        public void AddKilometer(string kilometer)
        {
            if (float.TryParse(kilometer, out float result))
            {
                this.AddKilometer(result);
            }
            else
            {
                throw new Exception();
            }
        }

        public void ShowStatistics()
        {
            var stat = GetStatistics();
            if (stat.Count != 0)
            {
                Console.WriteLine($"Min: {stat.dailyMin}");
                Console.WriteLine($"Max: {stat.dailyMax}");
                Console.WriteLine($"Average: {stat.Average:N1}");
                Console.WriteLine($"Sum km for: {this.Type}-{this.SerialNumber} is: {stat.Sum}");
                Console.WriteLine($"Comment: {stat.SumAssesment}");
            }
            else
            {
                Console.WriteLine("Not possible to show statistics for 0 values..");
            }
        }

        protected void OnKilometersAdded()
        {
            if (KilometersAdded != null)
            {
                KilometersAdded(this, new EventArgs());
            }
        }
    }
}


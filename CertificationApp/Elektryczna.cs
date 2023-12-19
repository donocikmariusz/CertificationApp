namespace CertificationApp
{
    public class Elektryczna : LokBase
    {
        public override event KilometersAddedDelegate KilometersAdded;

        private List<float> kilometers = new List<float>();
        public Elektryczna(string type, string serialNumber)
            : base(type, serialNumber)
        {
        }

        public string Type { get; private set; }
        public string SerialNumber { get; private set; }


        public override void AddKilometer(float kilometer)
        {
            if (kilometer > 0)
            {
                this.kilometers.Add(kilometer);
               
                if (KilometersAdded != null)
                {
                    KilometersAdded(this, new EventArgs());
                }
            }
            else if (kilometer < 0)
            {
                throw new Exception("Kilometry przejechane się już nie odprzejadą");
            }
            else
            {
                throw new Exception("Bez sensu dodawać kilometry jak ich wartosć to 0");
            }
        }

        public override void AddKilometer(int kilometer)
        {
            float kilometerAsFloat = kilometer;
            this.AddKilometer(kilometerAsFloat);
        }

        public override void AddKilometer(string kilometer)
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
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var kilometers in this.kilometers)
            {
                statistics.AddKilometers(kilometers);
            }

            return statistics;
        }
    }
}

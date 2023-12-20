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
            switch (statistics.Sum)

            {
                case var km when km >= 0 && km < 25:
                    statistics.SumAssesment = "Nic się nie narobił";
                    break;

                case var km when km >= 25 && km < 125:
                    statistics.SumAssesment = "Cos tam się narobił";
                    break;

                case var km when km >= 125 && km < 400:
                    statistics.SumAssesment = "Napracował się dziś";
                    break;

                case var km when km >= 400 && km < 1000:
                    statistics.SumAssesment = "Bardzo dużo się napracował";
                    break;

                case var km when km >= 1000:
                    statistics.SumAssesment = "Zagiął czasoprzestrzeń..";
                    break;

                default:
                    throw new Exception("Coś poszło nie tak...");
            }
        
            return statistics;
        }
    }
}

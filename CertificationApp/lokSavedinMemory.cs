namespace CertificationApp
{
    public class lokSavedinMemory : LokBase
    {
      
        private List<float> kilometers = new List<float>();
        public lokSavedinMemory(string type, string serialNumber)
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
                this.OnKilometersAdded();

            }
            else if (kilometer < 0)
            {
                throw new Exception("The kilometers traveled will no longer be forgotten..");
            }
            else
            {
                throw new Exception("It does not make sens to add 0 value of the kilometers..");
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
                    statistics.SumAssesment = "She did let's say no job today";
                    break;

                case var km when km >= 25 && km < 125:
                    statistics.SumAssesment = "She did some..";
                    break;

                case var km when km >= 125 && km < 400:
                    statistics.SumAssesment = "She did a good job, taxes for lazy people will be paid";
                    break;

                case var km when km >= 400 && km < 1000:
                    statistics.SumAssesment = "She did a great job";
                    break;

                case var km when km >= 1000:
                    statistics.SumAssesment = "Space-time has bent..";
                    break;

                default:
                    throw new Exception("sth went wrong...");
            }
            return statistics;
        }
    }
}

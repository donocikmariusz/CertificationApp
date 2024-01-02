namespace CertificationApp
{
    public class LokSavedInMemory : LokBase
    {
        private List<float> Kilometers = new List<float>();

        public LokSavedInMemory(string type, string serialNumber)
            : base(type, serialNumber)
        {
        }

        public override void AddKilometer(float kilometer)
        {
            if (kilometer > 0)
            {
                this.Kilometers.Add(kilometer);
                this.OnKilometersAdded();
            }
            else if (kilometer < 0)
            {
                throw new Exception("The kilometers traveled will no longer be forgotten..");
            }
            else
            {
                throw new Exception("It does not make sense to add 0 value of the kilometers..");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var kilometers in this.Kilometers)
            {
                statistics.AddKilometers(kilometers);
            }

            switch (statistics.Sum)
            {
                case var km when km >= 0 && km < 25:
                    statistics.SumAssessment = "She did let's say no job today, 800+ program is at risk!!!";
                    break;

                case var km when km >= 25 && km < 125:
                    statistics.SumAssessment = "She did some..but not to much to be able to pay for life-losers...";
                    break;

                case var km when km >= 125 && km < 400:
                    statistics.SumAssessment = "She did a good job, taxes for lazy people will be paid";
                    break;

                case var km when km >= 400 && km < 1000:
                    statistics.SumAssessment = "She did a great job. The government have take a lot of taxes and support his electorare..";
                    break;

                case var km when km >= 1000:
                    statistics.SumAssessment = "Space-time has bent..";
                    break;

                default:
                    throw new Exception("Something went wrong...");
            }
            return statistics;
        }
    }
}

namespace CertificationApp
{
    public class LokSavedInFile : LokBase
    {
        private const string FileName = "kilometers.txt";

        public LokSavedInFile(string type, string serialNumber)
            : base(type, serialNumber)
        {
            this.Type = type;
            this.SerialNumber = serialNumber;
        }

        public string Type { get; private set; }
        public string SerialNumber { get; private set; }

        public override void AddKilometer(float kilometer)
        {
            if (kilometer > 0)
            {
                this.OnKilometersAdded();
                using (var writer = File.AppendText(FileName))
                {
                    writer.WriteLine(kilometer);
                }
            }
            else if (kilometer < 0)
            {
                throw new Exception("The kilometers already traveled will no longer be forgotten..");
            }
            else
            {
                throw new Exception("It does not make sense to add 0 value of the kilometers..");
            }
        }

        public override Statistics GetStatistics()
        {
            var kilometersFromFile = this.ReadKilometersFromFile();
            var result = this.CountStatistics(kilometersFromFile);
            return result;
        }

        private List<float> ReadKilometersFromFile()
        {
            var kilometers = new List<float>();

            if (File.Exists(FileName))
            {
                using (var reader = File.OpenText(FileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        kilometers.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return kilometers;
        }

        private Statistics CountStatistics(List<float> kilometers)
        {
            var statistics = new Statistics();

            foreach (var k in kilometers)
            {
                statistics.AddKilometers(k);
            }

            switch (statistics.Sum)
            {
                case var km when km >= 0 && km < 25:
                    statistics.SumAssessment = "Fuel level probably OK";
                    break;

                case var km when km >= 25 && km < 125:
                    statistics.SumAssessment = "Warning - check fuel level";
                    break;

                case var km when km >= 125 && km < 400:
                    statistics.SumAssessment = "Fuel level has to be checked";
                    break;

                case var km when km >= 400 && km < 1000:
                    statistics.SumAssessment = "It is absolutely necessary to refill the fuel!";
                    break;

                case var km when km >= 1000:
                    statistics.SumAssessment = "What was the speed?";
                    break;

                default:
                    throw new Exception("Something went wrong...");
            }
            return statistics;
        }
    }
}

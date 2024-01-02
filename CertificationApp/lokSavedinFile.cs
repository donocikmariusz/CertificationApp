namespace CertificationApp
{
    public class LokSavedInFile : LokBase
    {
        public event KilometersAddedDelegate KilometersAdded;
        private const string fileName = "kilometers.txt";
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
                using (var writer = File.AppendText(fileName))
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
                throw new Exception("It does not make sens to add 0 value of the kilometers..");
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

            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
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
                    statistics.SumAssesment = "Fuel level probably OK";
                    break;

                case var km when km >= 25 && km < 125:
                    statistics.SumAssesment = "Warning - chech fuel level";
                    break;

                case var km when km >= 125 && km < 400:
                    statistics.SumAssesment = "Fuel level has to be checked";
                    break;

                case var km when km >= 400 && km < 1000:
                    statistics.SumAssesment = "It is absolutely necessary to refill the fuel!";
                    break;

                case var km when km >= 1000:
                    statistics.SumAssesment = "What was the speed?";
                    break;

                default:
                    throw new Exception("sth went wrong...");
            }
            return statistics;
        }

    }
}






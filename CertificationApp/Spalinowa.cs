namespace CertificationApp
{
    public class Spalinowa : LokBase
    {
        public override event KilometersAddedDelegate KilometersAdded;
        private List<float> kilometers = new List<float>();
        private const string fileName = "kilometers.txt";
        public Spalinowa(string type, string serialNumber)
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
                this.kilometers.Add(kilometer);

                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(kilometer);
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
            var result = new Statistics();

            foreach (var k in kilometers)
            {
                result.AddKilometers(k);
            }

            switch (result.Sum)

            {
                case var km when km >= 0 && km < 25:
                    result.SumAssesment = "Stan paliwa OK";
                    break;

                case var km when km >= 25 && km < 125:
                    result.SumAssesment = "Ostrzeżenie o sprawdzeniu stanu paliwa";
                    break;

                case var km when km >= 125 && km < 400:
                    result.SumAssesment = "Konieczne sprwdzenie stanu paliwa";
                    break;

                case var km when km >= 400 && km < 1000:
                    result.SumAssesment = "Konieczne uzupełenienie paliwa!";
                    break;

                case var km when km >= 1000:
                    result.SumAssesment = "To z jaką prędkością się ona porusza?";
                    break;

                default:
                    throw new Exception("Coś poszło nie tak...");
            }
            return result;
        }
    }
}






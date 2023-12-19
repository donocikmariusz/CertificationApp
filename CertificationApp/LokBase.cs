namespace CertificationApp
{
    public abstract class LokBase : ILok
    {
        public delegate void KilometersAddedDelegate(object sender, EventArgs args);
        public abstract event KilometersAddedDelegate KilometersAdded;

        private List<float> kilometers = new List<float>();
        public LokBase(string type, string serialNumber)
        {
            this.Type = type;
            this.SerialNumber = serialNumber;
        }
        public string Type { get; private set; }
        public string SerialNumber { get; private set; }
        public abstract void AddKilometer(float kilometer);
        public abstract void AddKilometer(string kilometer);
        public abstract Statistics GetStatistics();
        public abstract void AddKilometer(int kilometer);


    }
}


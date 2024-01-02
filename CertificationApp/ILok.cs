using static CertificationApp.LokBase;

namespace CertificationApp
{
    public interface ILok
    {
        public string Type { get; }
        public string SerialNumber { get; }
        void AddKilometer(float kilometer);
        void AddKilometer(string kilometer);
        void AddKilometer(int kilometer);
        Statistics GetStatistics();
        void ShowStatistics();
        event KilometersAddedDelegate KilometersAdded;
    }
}

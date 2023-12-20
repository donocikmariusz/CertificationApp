
namespace CertificationApp;
internal class Program
{

    private static void Main(string[] args)
    {
     
        bool exitApp = false;
        Console.WriteLine("Program do monitorowania przebiegów lokomotyw\n" +
    "------------------------------------------------");
        while (!exitApp)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Wybierz lokomotywę:\n" +
            "1. - Elektryczna (zapis tylko do pamięci)\n" +
            "2. - Spalinowa (zapis i odczyt do/z pliku)\n" +
            "Twój wybór: (lub 'q' lub 'Q' żeby wyjść)");
            Console.ResetColor();

            try
            {
                var wybor = Console.ReadLine().ToUpper();

                switch (wybor)
                {
                    case "1":
                        TypeElektryczna();
                        break;

                    case "2":
                        TypeSpalinowa();
                        break;

                    case "Q":
                        exitApp = true;
                        break;

                    default:
                        throw new Exception("Something went wrong...");
                }
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception złapany: {ex.Message}");
                Console.WriteLine();
                continue;
            }
        }
    }
    private void WriteMessageInConsoleInUpper(string text)
    {
        Console.WriteLine(text.ToUpper());
    }
    static string GetDataFromUser(string text)
    {
        while (true)
        {
            Console.WriteLine(text);
            string userInput = Console.ReadLine().ToUpper();

            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Pole nie może być puste");
                Console.WriteLine("");
            }

            else
            {
                return userInput;
            }
        }
    }
    private static void TypeElektryczna()
    {
        string type = GetDataFromUser("Podaj rodzaj lokomotywy: ");
        string serialNumber = GetDataFromUser("Podaj numer seryjny lokomotywy: ");
        var elektryczna = new Elektryczna(type, serialNumber);
        elektryczna.KilometersAdded += ElektrycznaKilometersAdded;

        void ElektrycznaKilometersAdded(object sender, EventArgs args)
        {
            Console.WriteLine("Dodano km");
        }

        while (true)
        {
            Console.WriteLine("Podaj kolejny przegieg km:");
            var dailykm = Console.ReadLine().ToUpper();

            if (dailykm == "Q")
            {
                break;
            }

            try
            {
                elektryczna.AddKilometer(dailykm);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Złapano exception: {ex.Message}");
            }

            finally
            {
                Console.WriteLine($"Wciśnij Q aby wyświetlić statystyki dla {elektryczna.Type} - {elektryczna.SerialNumber} i wyjść z programu)");
            }
        }

        var statistics = elektryczna.GetStatistics();
        Console.WriteLine($"Min: {statistics.dailyMin}");
        Console.WriteLine($"Max: {statistics.dailyMax}");
        Console.WriteLine($"Average: {statistics.Average:N1}");
        Console.WriteLine($"Suma kilometrów dla: {elektryczna.Type}-{elektryczna.SerialNumber} wynosi: {statistics.Sum}");
        Console.WriteLine($"Ocena: {statistics.SumAssesment}");
    }
    private static void TypeSpalinowa()
    {
        string type = GetDataFromUser("Podaj rodzaj lokomotywy: ");
        string serialNumber = GetDataFromUser("Podaj numer seryjny lokomotywy: ");
        var spalinowa = new Spalinowa(type, serialNumber);

        while (true)
        {
            Console.WriteLine("Podaj kolejny przegieg km:");
            var dailykm = Console.ReadLine().ToUpper();

            if (dailykm == "Q")
            {
                break;
            }

            try
            {
                spalinowa.AddKilometer(dailykm);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Złapano exception: {ex.Message}");
            }

            finally
            {
                Console.WriteLine($"Wciśnij Q aby wyświetlić statystyki dla {spalinowa.Type} - {spalinowa.SerialNumber} i wyjść z programu)");
            }
        }

        var statistics = spalinowa.GetStatistics();
        Console.WriteLine($"Min: {statistics.dailyMin}");
        Console.WriteLine($"Max: {statistics.dailyMax}");
        Console.WriteLine($"Average: {statistics.Average:N1}");
        Console.WriteLine($"Suma kilometrów dla: {spalinowa.Type}-{spalinowa.SerialNumber} wynosi: {statistics.Sum}");
        Console.WriteLine($"Ocena: {statistics.SumAssesment}");
    }
}


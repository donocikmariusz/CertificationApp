namespace CertificationApp;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Program do monitorowania przebiegów lokomotyw\n" +
        "------------------------------------------------ \n" +
        "Wybierz lokomotywę:\n" +
        "1. - Elektryczna\n" +
        "2. - Spalinowa\n" +
        "Twój wybór: (lub 'q' lub 'Q' żeby wyjść)");
        Console.ResetColor();

        bool exitApp = false;

        while (!exitApp)
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
                    Console.WriteLine("Something went wrong...");
                    continue;
            }
            break;
        }
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
        var elektryczna = new Lok(type, serialNumber);

        elektryczna.AddKilometer("15");
        elektryczna.AddKilometer(9f);
        elektryczna.AddKilometer(90);


        var statistics = elektryczna.GetStatistics();
        Console.WriteLine($"Min: {statistics.dailyMin}");
        Console.WriteLine($"Max: {statistics.dailyMax}");
        Console.WriteLine($"Average: {statistics.Average:N1}");
        Console.WriteLine($"Suma kilometrów dla: {elektryczna.Type}-{elektryczna.SerialNumber} wynosi: {statistics.Sum}");

    }

    private static void TypeSpalinowa()
    {
        string type = GetDataFromUser("Podaj rodzaj lokomotywy: ");
        string serialNumber = GetDataFromUser("Podaj numer seryjny lokomotywy: ");
        var spalinowa = new Lok(type, serialNumber);
    }


}


﻿
namespace CertificationApp;
internal class Program
{

    private static void Main(string[] args)
    {
        bool exitApp = false;
        Console.WriteLine("Program for monitoring the daily distances [km] of locomotives \n" +
    "------------------------------------------------");
        while (!exitApp)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Choose a locomotive:\n" +
            "1. - Electric (save to memory only)\n" +
            "2. - Diesel (save and read to/from file)\n" +
            "Your choice: (or 'q' or 'Q' to exit)");
            Console.ResetColor();

            try
            {
                var inputUser = Console.ReadLine().ToUpper();

                switch (inputUser)
                {
                    case "1":
                        EnterTypeAndSerialNumber(out string TypeInMemory, out string SerialNumberInMemory);
                        var lokInMemory = new LokSavedinMemory(TypeInMemory, SerialNumberInMemory);
                        AddKilometers(lokInMemory);
                        break;

                    case "2":
                        EnterTypeAndSerialNumber(out string TypeInFile, out string SerialNumberInFile);
                        var lokInFile = new LokSavedInFile(TypeInFile, SerialNumberInFile);
                        AddKilometers(lokInFile);
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
                Console.WriteLine($"Exception catched: {ex.Message}");
                Console.WriteLine();
                continue;
            }
        }
    }

    private static void EnterTypeAndSerialNumber(out string type, out string serialNumber)
    {
        type = GetDataFromUser("Enter type of locomotive ex (SP32, EP08, EP09, SU46): ");
        serialNumber = GetDataFromUser("Enter locomotive serial number: ");
    }

    private static void AddKilometers(ILok lok)
    {       
        lok.KilometersAdded += KmAdded;
        EnterKilometers(lok);
        lok.ShowStatistics();
    }

    static void KmAdded(object sender, EventArgs args)
    {
        Console.WriteLine($"Km Added");
    }

    static string GetDataFromUser(string text)
    {
        while (true)
        {
            Console.WriteLine(text);
            string userInput = Console.ReadLine().ToUpper();

            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Field cannot be empty");
                Console.WriteLine("");
            }

            else
            {
                return userInput;
            }
        }
    }
    private static void EnterKilometers(ILok lok)
    {
        while (true)
        {
            Console.WriteLine("Enter another distance of (km)");
            var dailykm = Console.ReadLine().ToUpper();

            if (dailykm == "Q")
            {
                break;
            }

            try
            {
                lok.AddKilometer(dailykm);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"exception catched: {ex.Message}");
            }

            finally
            {
                Console.WriteLine($"Press Q to show statistics for {lok.Type} - {lok.SerialNumber} and exit the program)");
            }
        }
    }
}



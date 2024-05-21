using CaseStudyCRS1.Entities;
using CaseStudyCRS1.util;
using System.Transactions;
using CaseStudyCRS1.dao.ICarLeaseRepositoryImpl;
using System.Runtime.Intrinsics;
using CaseStudyCRS1.dao.ICarLeaseRepository;
using CaseStudyCRS1.main;
class Program
{
    static string GetMaskedInput()
    {
        string input = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            // Check if the key pressed is a valid character
            if (char.IsLetterOrDigit(key.KeyChar) || char.IsSymbol(key.KeyChar) || char.IsPunctuation(key.KeyChar))
            {
                input += key.KeyChar;
                Console.Write("*"); // Mask the input
            }
            // Allow backspace to remove characters
            else if (key.Key == ConsoleKey.Backspace && input.Length > 0)
            {
                input = input.Substring(0, input.Length - 1);
                Console.Write("\b \b"); // Remove the masked character
            }
        } while (key.Key != ConsoleKey.Enter);

        return input;
    }

    static bool AdminVerification()
    {
        Console.WriteLine("Enter Admin Username:");
        string user=Console.ReadLine();
        while(user.Equals("admin")==false)
        {
            Console.Clear();
            Console.WriteLine("Invalid Username.Reenter username");
            user = Console.ReadLine();
        }
        Console.WriteLine("Enter Password");
        int flag = 0;
        for(int i=1;i<=3;i++)
        {
           string password= GetMaskedInput();
            if (password.Equals("harshi") == true)
            {
                flag = 1;
                break;
            }
        }
        if(flag==1)
        return true;
        else
        {
            Console.WriteLine("Try after some time");
            return false;
        }
        

    }
    public static void Main(string[] args)
    {
        Console.WriteLine("WELCOME TO HARSHI'S CAR RENTAL SHOP");
        bool condition=AdminVerification();
        while (condition)
        {
            Console.WriteLine("\nSelect Your option");
            Console.WriteLine("1.Car Management\n2.CustomerManagement\n3.LeaseManagement\n4.Payment\n5.Exit");
            int option;
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid option. Please choose again.");
                continue;
            }

            switch (option)
            {
                case 1:
                    Console.Clear();
                    VehicleController.VehicleMenuDisplay();
                    break;
                case 2:
                    Console.Clear();
                    CustomerController.CustomerMenuDisplay();
                    break;
                case 3:
                    Console.Clear();
                    LeaseController.LeaseMenuDisplay();
                    break;
                case 4:
                    Console.Clear();
                    PaymentController.PaymentMenuDisplay();
                    break;
                case 5:
                    condition = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }

        }
    }
}
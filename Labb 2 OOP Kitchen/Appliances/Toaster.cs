using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen.Appliances
{
    public class Toaster : KitchenAppliance
    {
        public Toaster(string type, string brand, bool isFunctioning) : base(type, brand, isFunctioning)
        {
            TimesUsed = 5;
            Type = type;
			SweType = TranslateType(Type);
			Brand = brand;
            IsFunctioning = isFunctioning;
        }
        public Toaster()
        {
        }
        public override KitchenAppliance Use(KitchenAppliance appl)
        {
            if (appl.IsFunctioning)
            {
                Random rnd = new Random();
                int i = rnd.Next(1, 2);
                Console.WriteLine(i);
                if (appl.TimesUsed > i)
                {
                    appl.IsFunctioning = false;
                    Console.WriteLine("\t\tKAFRÄÄääS!");
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\n\t\thuvudsäkringen gick...");
                    Thread.Sleep(5000);
                    Console.WriteLine("\t\tByt huvudsäkring? [1] Ja [2] Nej");
                    Console.Write("\t\t- ");
                    string input = Console.ReadLine();
                    if (input == "1")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t\tSådärja! Återgår strax till menyn");
                        Thread.Sleep(2000);
                        return appl;
                    }
                    else
                    {
                        Console.WriteLine("\t\tNehe, då får det bli mörkt");
                        Thread.Sleep(5000);
                        Console.ForegroundColor = ConsoleColor.White;
                        return appl;
                    }
                }
                else
                {
                    Console.WriteLine("\t\t*rostar brödet*");
                    return appl;
                }
            }
            else
            {
                Console.WriteLine("\t\tApparaten är trasig, kontakta en reparatör");
                return appl;
            }
        }
    }
}

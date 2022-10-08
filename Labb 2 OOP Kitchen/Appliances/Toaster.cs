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
            TimesUsed = AroundTheCornerWarranty();
			Type = type;
			Brand = brand;
			SweType = TranslateType(Type);
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
                int i = rnd.Next(1, 3);
                Console.WriteLine(i);
                if (appl.TimesUsed > i)
                {
					appl.IsFunctioning = false;
                    Console.WriteLine("\t\tKAFRÄÄääS!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\n\t\thuvudsäkringen gick...");
                    Utility.LoadingBar();
                    Console.WriteLine("\t\tByt huvudsäkring? [1] Ja [2] Nej");
                    Console.Write("\t\t- ");
                    string input = Console.ReadLine();
                    if (input == "1")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t\tSådärja! Återgår strax till menyn");
                        Utility.LoadingBar();
                        return appl;
                    }
                    else
                    {
                        Console.WriteLine("\t\tNehe, då får det bli mörkt");
                        Utility.LoadingBar();
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
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("\t\tApparaten är trasig, kontakta en reparatör");
				Console.ForegroundColor = ConsoleColor.White;
				return appl;
            }
        }
    }
}

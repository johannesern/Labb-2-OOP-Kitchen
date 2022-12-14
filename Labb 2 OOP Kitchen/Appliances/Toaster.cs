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
			//Förklaring, se basklass
			TimesUsed = AroundTheCornerWarranty();
			Type = type;
			Brand = brand;
			SweType = TranslateType(Type);
			IsFunctioning = isFunctioning;
		}
		public Toaster()
		{
		}

		//Den enda maskinen med en egen variant av Use metoden.
		public override KitchenAppliance Use(KitchenAppliance appl)
		{
			appl.TimesUsed++;
			if (appl.IsFunctioning)
			{
				Random rnd = new Random();
				int i = rnd.Next(1, 7);
				if (appl.TimesUsed > i)
				{
					appl.IsFunctioning = false;
					Console.Clear();
					Console.WriteLine("\n\t\tKAFRÄÄääS!");
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

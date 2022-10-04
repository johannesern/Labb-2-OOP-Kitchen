using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen
{
	public class Toaster : KitchenAppliance
	{
		private int TimesUsed;
		public Toaster(string type, string brand, bool isFunctioning)
		{
			Type = type;
			Brand = brand;
			IsFunctioning = isFunctioning;
			TimesUsed = 0;
		}
		public Toaster()
		{

		}

		public override void Use()
		{			
			if (IsFunctioning)
			{
				TimesUsed++;
				Random rnd = new Random();
				if (TimesUsed > rnd.Next(1, 6))
				{
					IsFunctioning = false;
					Console.WriteLine("KAFRÄÄääS!");
					Thread.Sleep(500);
					Console.Clear();
					Console.ForegroundColor = ConsoleColor.DarkGray;
					Console.WriteLine("huvudsäkringen gick...");
					Thread.Sleep(5000);
					Console.WriteLine("Byt huvudsäkring? [1] Ja [2] Nej");
					string input = Console.ReadLine();
					if(input == "1")
					{
						Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("Sådärja! Återgår strax till menyn");
						Thread.Sleep(2000);
					}
					else
					{
						Console.WriteLine("Nehe, då får det bli mörkt");
						Thread.Sleep(5000);
						Console.ForegroundColor = ConsoleColor.White;
					}
				}
				else
				{
					Console.WriteLine("toasting");
				}
			}
			else
			{
				Console.WriteLine("Apparaten är trasig, kontakta en reparatör");
			}
		}
	}
}

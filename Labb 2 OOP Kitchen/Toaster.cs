﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen
{
	public class Toaster : KitchenAppliance
	{
		public int TimesUsed { get; set; }
		public Toaster(string type, string brand, bool isFunctioning)
		{
			Type = type;
			Brand = brand;
			IsFunctioning = isFunctioning;
			TimesUsed = 5;
		}

		public Toaster()
		{
		}

		public override int Use(int timesUsed, bool isFunctioning,)
		{			
			if (IsFunctioning)
			{
				timesUsed++;
				Random rnd = new Random();
				if (TimesUsed > rnd.Next(1, 2))
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
						return timesUsed;
					}
					else
					{
						Console.WriteLine("Nehe, då får det bli mörkt");
						Thread.Sleep(5000);
						Console.ForegroundColor = ConsoleColor.White;
						return timesUsed;
					}
				}
				else
				{
					Console.WriteLine("*rostar brödet*");
					return timesUsed;
				}
			}
			else
			{
				Console.WriteLine("Apparaten är trasig, kontakta en reparatör");
				return timesUsed;
			}
		}
	}
}

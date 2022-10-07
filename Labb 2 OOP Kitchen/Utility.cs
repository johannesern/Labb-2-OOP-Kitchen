﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen
{
	internal static class Utility
	{
		public static void PrintingOutAllAppliances(List<KitchenAppliance> applianceList)
		{
			Console.WriteLine("\n\t\tIndex\tTyp\t\tMärke\t\tFungerar?");
			int counter = 1;
			foreach (IKitchenAppliance appliance in applianceList)
			{
				string works = "";
				if (appliance.IsFunctioning)
				{
					works = "Ja";
				}
				else
				{
					works = "Nej";
				}
				Console.WriteLine();
				Console.Write("\t\t" + counter);
				if (appliance.Type.Length < 8 && appliance.Brand.Length < 8)
				{
					Console.Write("\t" + appliance.Type +
								  "\t\t" + appliance.Brand + 
								  "\t\t" + works);
				}
				else if (appliance.Type.Length > 7 && appliance.Brand.Length > 7)
				{
					Console.Write("\t" + appliance.Type +
								  "\t" + appliance.Brand +
								  "\t\t" + works);
				}
				else if (appliance.Type.Length < 8 && appliance.Brand.Length > 7)
				{
					Console.Write("\t" + appliance.Type +
								  "\t\t" + appliance.Brand +
								  "\t" + works);
				}
				else
				{
					Console.Write("\t" + appliance.Type +
								  "\t" + appliance.Brand +
								  "\t\t" + works);
				}
				counter++;
			}
			Console.WriteLine();
		}

		public static int DefiningInt()
		{
			string input = Console.ReadLine();
			int applianceIndex;
			bool run = true;
			do
			{
				bool isInt = Int32.TryParse(input, out applianceIndex);
				if (isInt)
				{
					run = false;
				}
				else
				{
					Console.WriteLine("\t\tDet där var inte ett heltal, försök igen.");
					Console.Write("\t\t- ");
					input = Console.ReadLine();

				}
			} while (run);

			return applianceIndex;
		}

		public static void LoadingBar()
		{
			Console.WriteLine();
			Console.Write("\t\t");
			for (int i = 0; i < 30; i++)
			{
				Console.Write("= ");
				Thread.Sleep(200);
			}
		}
	}
}

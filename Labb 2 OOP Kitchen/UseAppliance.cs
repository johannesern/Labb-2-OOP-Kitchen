using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen
{
	public class UseAppliance
	{
		public List<KitchenAppliance> UseAppl(List<KitchenAppliance> applianceList)
		{
			Utility.PrintingOutAllAppliances(applianceList);
			Console.WriteLine("\n\t\tVilken köksapparat vill ni använda?");
			bool run = true;
			do
			{
				Console.Write("\t\t- ");
				int applianceIndex = Utility.DefiningInt() - 1;
				switch (applianceList[applianceIndex].Type)
				{
					case "Toaster":
						{
							Toaster toaster = new Toaster();
							applianceList[applianceIndex].TimesUsed++;
							toaster.Use(applianceList[applianceIndex]);
							run = false;
							break;
						}
					case "Stove":
						{
							Stove stove = new Stove();
							applianceList[applianceIndex].TimesUsed++;
							stove.Use(applianceList[applianceIndex]);
							//stove.Use(applianceList[applianceIndex].TimesUsed, applianceList[applianceIndex].IsFunctioning);
							run = false;
							break;
						}
					case "Microwave":
						{
							Microwave microwave = new Microwave();
							applianceList[applianceIndex].TimesUsed++;
							//microwave.Use(applianceList[applianceIndex].TimesUsed, applianceList[applianceIndex].IsFunctioning);
							run = false;
							break;
						}
					case "Oven":
						{
							Oven oven = new Oven();
							applianceList[applianceIndex].TimesUsed++;
							//oven.Use(applianceList[applianceIndex].TimesUsed, applianceList[applianceIndex].IsFunctioning);
							run = false;
							break;
						}
					case "Other":
						{
							//Other oven = new Other();
							//applianceList[applianceIndex].TimesUsed++;
							//toaster.Use(applianceList[applianceIndex].TimesUsed, applianceList[applianceIndex].IsFunctioning);
							run = false;
							break;
						}
					default:
						{
							Console.WriteLine("Apparaten finns inte försök igen.");
							break;
						}
				}
			} while (run);
			return applianceList;
		}
	}
}

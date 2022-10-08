using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Labb_2_OOP_Kitchen.Appliances;

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
							toaster.Use(applianceList[applianceIndex]);
							applianceList[applianceIndex].TimesUsed++;
							run = false;
							break;
						}
					case "Stove":
						{
							Stove stove = new Stove();
							stove.Use(applianceList[applianceIndex]);
							applianceList[applianceIndex].TimesUsed++;
							run = false;
							break;
						}
					case "Microwave":
						{
							Microwave microwave = new Microwave();
							microwave.Use(applianceList[applianceIndex]);
							applianceList[applianceIndex].TimesUsed++;
							run = false;
							break;
						}
					case "Oven":
						{
							Oven oven = new Oven();
							oven.Use(applianceList[applianceIndex]);
							applianceList[applianceIndex].TimesUsed++;
							run = false;
							break;
						}
					case "Other":
						{
							KitchenAppliance otherAppliance = new OtherAppliance();
							otherAppliance.Use(applianceList[applianceIndex]);
							applianceList[applianceIndex].TimesUsed++;
							run = false;
							break;
						}
					default:
						{
							Console.WriteLine("\n\t\tApparaten finns inte försök igen.");
							break;
						}
				}
			} while (run);
			return applianceList;
		}
	}
}

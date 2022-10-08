using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Labb_2_OOP_Kitchen.Appliances;

namespace Labb_2_OOP_Kitchen
{
	public class UseAppliance
	{
		public List<KitchenAppliance> UseAppl(List<KitchenAppliance> applianceList)
		{
			Console.Clear();
			Console.WriteLine("\n\t\t========== ANVÄNDA KÖKSAPPARAT ==========");
			Utility.PrintingOutAllAppliances(applianceList);
			Console.WriteLine("\n\t\tVilken köksapparat vill ni använda?");
			bool run = true;
			do
			{
				Console.Write("\t\t- ");
				int applianceIndex = Utility.DefiningInt() - 1;
				try
				{
					switch (applianceList[applianceIndex].Type)
					{
						case "Toaster":
							{
								applianceList = UseAndUpdateThisAppliance(applianceList, applianceIndex);
								run = false;
								break;
							}
						case "Stove":
							{
								applianceList = UseAndUpdateThisAppliance(applianceList, applianceIndex);
								run = false;
								break;
							}
						case "Microwave":
							{
								applianceList = UseAndUpdateThisAppliance(applianceList, applianceIndex);
								run = false;
								break;
							}
						case "Oven":
							{
								applianceList = UseAndUpdateThisAppliance(applianceList, applianceIndex);
								run = false;
								break;
							}
						case "Other":
							{
								applianceList = UseAndUpdateThisAppliance(applianceList, applianceIndex);
								run = false;
								break;
							}
						default:
							{
								Console.WriteLine("\n\t\tApparaten finns inte, försök igen.");
								break;
							}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("\t\tDu försökte nå ett objekt utanför listan, försök igen.");
				}				
			} while (run);
			Utility.LoadingBar();
			return applianceList;
		}

		private List<KitchenAppliance> UseAndUpdateThisAppliance(List<KitchenAppliance> applianceList, int applianceIndex)
		{
			applianceList[applianceIndex] = applianceList[applianceIndex].Use(applianceList[applianceIndex]);
			return applianceList;
		}
	}
}

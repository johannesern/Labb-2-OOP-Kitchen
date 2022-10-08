using Labb_2_OOP_Kitchen.Appliances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen
{
	internal class RemoveAppliance
	{
		public static List<KitchenAppliance> RemovingAppliance(List<KitchenAppliance> applianceList)
		{
			Console.Clear();
			Console.WriteLine("\n\t\t========== TA BORT APPARAT ==========");
			Utility.PrintingOutAllAppliances(applianceList);
			Console.WriteLine("\n\t\tVilken apparat vill du ta bort? (Skriv in index för apparaten)");
			Console.Write("\t\t- ");
			int applianceIndex = Utility.DefiningInt() - 1;
			bool flag = false;
			try
			{
				Console.WriteLine("\t\tÄr du säker på att du vill ta bort\n" +
								  "\t\t" + applianceList[applianceIndex].SweType +
								  "\t" + applianceList[applianceIndex].Brand);
				Console.WriteLine("\t\t[1] Ja [2] Nej");
				Console.Write("\t\t- ");
				string removeOrNot = Console.ReadLine();
				if (removeOrNot == "1")
				{
					RemovingApplianceFromList(applianceList, applianceIndex);
					Console.WriteLine("\t\tApparaten borttagen.");
					Utility.EndOfMethod();
					return applianceList;
				}
				else
				{
					Console.WriteLine("\t\tInget borttaget");
					Utility.EndOfMethod();
					return applianceList;
				}
			}
			catch (Exception ex)
			{
				flag = true;
				Console.WriteLine("\t\tFelaktig inmatning, försök igen.");
				Utility.LoadingBar();
			}
			finally
			{
				if (flag)
				{
					RemovingAppliance(applianceList);
				}
			}
			return applianceList;
		}
		private static void RemovingApplianceFromList(List<KitchenAppliance> applianceList, int applianceIndex)
		{
			bool flag = false;
			try
			{
				applianceList.RemoveAt(applianceIndex);
			}
			catch (Exception ex)
			{
				flag = true;
				Console.WriteLine("Felaktigt inmatning, försök igen.");
			}
			finally
			{
				if (flag)
				{
					Console.Clear();
					RemovingAppliance(applianceList);
				}				
			}
		}
	}
}

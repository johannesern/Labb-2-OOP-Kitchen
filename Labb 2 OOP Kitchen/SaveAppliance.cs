using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Labb_2_OOP_Kitchen.Appliances;

namespace Labb_2_OOP_Kitchen
{
	public class SaveAppliance
	{
		private List<KitchenAppliance> kitchenApplianceList = new List<KitchenAppliance>();
		public List<KitchenAppliance> KitchenApplianceList
		{
			get { return kitchenApplianceList; }
			set { kitchenApplianceList = value; }
		}
		public void NewAppliance()
		{
			Console.WriteLine("\t\t============= LÄGG TILL NY APPARAT =============\n");
			Console.WriteLine("\t\tVilken typ av maskin vill ni lägga till:\n" +
							  "\t\t[1] Brödrost\n" +
							  "\t\t[2] Mikrovågsugn\n" +
							  "\t\t[3] Spis/Häll\n" +
							  "\t\t[4] Ugn\n" +
							  "\t\t[5] Övrig");
			Console.Write("\t\t- ");
			string machine = Console.ReadLine();
			switch (machine) 
			{
				case "1":
					{
						AddToaster();
						break;
					}
				case "2":
					{
						AddMicrowave();
						break;
					}
				case "3":
					{
						AddStove();
						break;
					}
				case "4":
					{
						AddOven();
						break;
					}
				case "5":
					{
						AddOther();
						break;
					}
				default:
					{
						Console.WriteLine("\t\tFelaktigt val försök igen");
						break;
					}
			}
		}
		private void AddMicrowave()
		{
			string type = "Mikrovågsugn";
			string brand = SettingMachineBrand();
			bool isFunctioning = SettingMachineCondition();
			Microwave newMicrowave = new Microwave(type, brand, isFunctioning);
			AddApplianceToList(newMicrowave);
		}
		private void AddOven()
		{
			string type = "Ugn";
			string brand = SettingMachineBrand();
			bool isFunctioning = SettingMachineCondition();
			Oven newOven = new Oven(type, brand, isFunctioning);
			AddApplianceToList(newOven);
		}
		private void AddStove()
		{
			string type = "Spis/Häll";
			string brand = SettingMachineBrand();
			bool isFunctioning = SettingMachineCondition();
			Oven newOven = new Oven(type, brand, isFunctioning);
			AddApplianceToList(newOven);
		}
		private void AddToaster()
		{
			string type = "Brödrost";
			string brand = SettingMachineBrand();
			bool isFunctioning = SettingMachineCondition();
			Toaster newToaster = new Toaster(type, brand, isFunctioning);
			AddApplianceToList(newToaster);
		}
		private void AddOther()
		{
			string type = "Other";
			string brand = SettingMachineBrand();
			string userInputType = SettingMachineType();
			bool isFunctioning = SettingMachineCondition();
			OtherAppliance otherAppliance = new OtherAppliance(type, userInputType, brand, isFunctioning);
			AddApplianceToList(otherAppliance);
		}
		public void AddApplianceToList(KitchenAppliance appliance)
		{
			KitchenApplianceList.Add(appliance);
		}
		public bool SettingMachineCondition()
		{
			bool run = true;
			string condition = "";
			while (run)
			{				
				Console.Write("\t\tSkick (fungerar [j] fungerar inte [n]):");
				condition = Console.ReadLine();
				if (condition.ToLower() == "j" || condition.ToLower() == "n")
				{
					run = false;
				}
				else
				{
					Console.WriteLine("\t\tNi måste välja \"j\" eller \"n\" om apparatens skick.");
					run = true;
				}
			}
			if (condition.ToLower() == "j")
			{
				return true;				
			}
			else
			{
				return false;				
			}
		}
		public string SettingMachineBrand()
		{
			string brand = "";
			bool run = true;
			while (run)
			{
				Console.Write("\t\tMärke: ");
				brand = Console.ReadLine();
				if (String.IsNullOrEmpty(brand))
				{
					Console.WriteLine("\t\tFältet får inte lämnas tomma, försök igen.");
				}
				else
				{
					run = false;
				}
			}
			return brand;
		}
		public string SettingMachineType()
		{
			string type = "";
			bool run = true;
			while (run)
			{
				Console.Write("\t\tApparat-typ: ");
				type = Console.ReadLine();
				if (String.IsNullOrEmpty(type))
				{
					Console.WriteLine("\t\tFälten får inte lämnas tomma, försök igen.");
				}
				else
				{
					run = false;
				}
			}
			return type;
		}
		public  void RemoveAppliance()
		{
			Utility.PrintingOutAllAppliances(KitchenApplianceList);
			Console.WriteLine("\n\t\tVilken apparat vill du ta bort? (Skriv in ett heltal)");
			Console.Write("\t\t- ");
			int applianceIndex = Utility.DefiningInt() - 1;
			bool flag = false;
			try
			{
				Console.WriteLine("\t\tÄr du säker på att du vill ta bort\n" +
								  "\t\t" + KitchenApplianceList[applianceIndex].Type +
								  "\t" + KitchenApplianceList[applianceIndex].Brand);
				Console.WriteLine("\t\t[1] Ja [2] Nej");
				Console.Write("\t\t- ");
				string removeOrNot = Console.ReadLine();
				if (removeOrNot == "1")
				{
					RemovingApplianceFromList(applianceIndex);
				}
				else
				{
					Console.WriteLine("\t\tInget borttaget, tryck på valfri knapp för att återgå till huvudmenyn.");
					Console.Write("\t\t- ");
				}
			}
			catch(Exception ex)
			{
				flag = true;
				Console.WriteLine("\t\tFelaktig inmatning, försök igen.");
				Console.Write("\t\t- ");				
			}
			finally
			{
				if (flag)
				{
					Console.Clear();
					RemoveAppliance();
				}
			}
		}
		private void RemovingApplianceFromList(int applianceIndex)
		{
			bool flag = false;
			try
			{
				KitchenApplianceList.RemoveAt(applianceIndex);
			}
			catch (Exception ex)
			{
				flag = true;
				Console.WriteLine("Listan är tom eller så har ni matat in ett felaktigt värde, försök igen.");
			}
			finally
			{
				if (flag)
				{
					Console.Clear();
					RemoveAppliance();
				}
			}
		}
	}
}

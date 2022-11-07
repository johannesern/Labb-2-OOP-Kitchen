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
			bool run;
			do
			{
				run = false;
				Console.Clear();
				Console.WriteLine("\n\t\t============= LÄGG TILL NY APPARAT =============\n");
				Console.WriteLine("\t\tVilken typ av maskin vill ni lägga till:\n" +
								  "\t\t[1] Brödrost\n" +
								  "\t\t[2] Mikrovågsugn\n" +
								  "\t\t[3] Spis/Häll\n" +
								  "\t\t[4] Ugn\n" +
								  "\t\t[5] Övrig\n" +
								  "\t\t[6] Avbryt");

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
					case "6":
						{

							run = false;
							break;
						}
					default:
						{
							Console.WriteLine("\t\tFelaktigt val försök igen");
							Console.ReadKey();
							run = true;
							break;
						}
				}
			} while (run);
		}
		private void AddOven()
		{
			string type = "Oven";
			string brand = SettingMachineBrand();
			bool isFunctioning = SettingMachineCondition();
			Oven newOven = new Oven(type, brand, isFunctioning);
			AddApplianceToList(newOven);
		}
		private void AddStove()
		{
			string type = "Stove";
			string brand = SettingMachineBrand();
			bool isFunctioning = SettingMachineCondition();
			Oven newOven = new Oven(type, brand, isFunctioning);
			AddApplianceToList(newOven);
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
		private void AddToaster()
		{
			string type = "Toaster";
			string brand = SettingMachineBrand();
			bool isFunctioning = SettingMachineCondition();
			Toaster newToaster = new Toaster(type, brand, isFunctioning);
			AddApplianceToList(newToaster);
		}
		private void AddMicrowave()
		{
			string type = "Microwave";
			string brand = SettingMachineBrand();
			bool isFunctioning = SettingMachineCondition();
			Microwave newMicrowave = new Microwave(type, brand, isFunctioning);
			AddApplianceToList(newMicrowave);
		}
		private void AddApplianceToList(KitchenAppliance appliance)
		{
			KitchenApplianceList.Add(appliance);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("\n\t\tApparaten tillagd!");
			Console.ForegroundColor = ConsoleColor.White;
		}
		private string SettingMachineType()
		{
			string type = "";
			bool run = true;
			while (run)
			{
				Console.Write("\t\tApparat-typ: ");
				type = Console.ReadLine();
				if (String.IsNullOrWhiteSpace(type))
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
		private string SettingMachineBrand()
		{
			string brand = "";
			bool run = true;
			while (run)
			{
				Console.Write("\t\tMärke: ");
				brand = Console.ReadLine();
				if (String.IsNullOrWhiteSpace(brand))
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
		private bool SettingMachineCondition()
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

	}
}

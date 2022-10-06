using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen
{
	public class SaveAppliance
	{
		protected List<KitchenAppliance> kitchenApplianceList = new List<KitchenAppliance>();
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

		public void AddApplianceToList(KitchenAppliance appliance)
		{
			KitchenApplianceList.Add(appliance);
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
			string type = SettingMachineType();
			string brand = SettingMachineBrand();
			bool isFunctioning = SettingMachineCondition();
			//KitchenAppliance newAppl = new KitchenAppliance(type, brand, isFunctioning);      TÄNK PÅ DENNA
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
		public void PrintingOutAllAppliances()
		{
			Console.WriteLine("\n\t\tIndex\tTyp\t\tMärke");
			int counter = 1;
			foreach (IKitchenAppliance appliance in KitchenApplianceList)
			{
				Console.WriteLine();
				Console.Write("\t\t" + counter);
				if (appliance.Type.Length < 8 && appliance.Brand.Length < 8)
				{
					Console.Write("\t" + appliance.Type +
								  "\t\t" + appliance.Brand);
				}
				else if (appliance.Type.Length > 7 && appliance.Brand.Length > 7)
				{
					Console.Write("\t" + appliance.Type +
								  "\t" + appliance.Brand);
				}
				else if (appliance.Type.Length < 8 && appliance.Brand.Length > 7)
				{
					Console.Write("\t" + appliance.Type +
								  "\t\t" + appliance.Brand);
				}
				else
				{
					Console.Write("\t" + appliance.Type +
								  "\t" + appliance.Brand);
				}
				counter++;
			}
			Console.WriteLine();
		}
		public  void RemoveAppliance()
		{
			PrintingOutAllAppliances();
			Console.WriteLine("\n\t\tVilken apparat vill du ta bort? (Skriv in ett heltal)");
			int applianceIndex = DefiningInt() - 1;
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
				Console.WriteLine("Inget borttaget, tryck på valfri knapp för att återgå till huvudmenyn.");
				Console.ReadKey();
			}
		}
		public int DefiningInt()
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
				else
				{
				}
			}
		}
	}
}

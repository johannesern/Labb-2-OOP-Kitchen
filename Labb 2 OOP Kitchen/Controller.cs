using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb_2_OOP_Kitchen.Appliances;

namespace Labb_2_OOP_Kitchen
{
	internal class Controller
	{
		//Listan som används genom programmet ligger i Saveappliance-klassen.
		protected static SaveAppliance saveAppliance = new SaveAppliance();
		
		public void Run()
		{
			//Skapar upp ett antal objekt att använda direkt.
			Oven oven = new Oven("Oven", "Bosch", false);
			saveAppliance.KitchenApplianceList.Add(oven);
			Stove stove = new Stove("Stove", "Siemens", true);
			saveAppliance.KitchenApplianceList.Add(stove);
			Toaster toaster = new Toaster("Toaster", "OBH Nordica", true);
			saveAppliance.KitchenApplianceList.Add(toaster);
			Microwave microwave = new Microwave("Microwave", "Samsung", true);
			saveAppliance.KitchenApplianceList.Add(microwave);
			OtherAppliance otherAppliance = new OtherAppliance("Other", "Elvisp", "Braun", false);
			saveAppliance.KitchenApplianceList.Add(otherAppliance);
			EnteringKitchen();
		}

		private static void EnteringKitchen()
		{
			bool showMenu = true;
			while (showMenu)
			{
				Console.Clear();
				Console.WriteLine("\n\t\t========== KÖKET ==========\n" +
								  "\n\t\tVad vill du göra?\n" +
								  "\t\t[1] Använda en köksapparat\n" +
								  "\t\t[2] Lägg till köksapparat\n" +
								  "\t\t[3] Lista köksapparater\n" +
								  "\t\t[4] Ta bort en köksapparat\n" +
								  "\t\t[5] Reparera maskinerna\n" +
								  "\t\t[6] Gå ut ur köket");
				Console.Write("\t\t- ");
				string choice = "";
				try
				{
					choice = Console.ReadLine();
					
					if (choice == "2" || choice == "6")
					{
						//Val 2 & 6 går att använda utan att kontrollera listans innehåll
						showMenu = MenuChoice(choice);
					}
					else
					{
						//Val 1, 3, 4, 5 kollar om listan har något innehåll först
						showMenu = CheckingIfListIsEmpty(choice);
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("\t\tFelaktig inmatning, försök igen.");
				}
			}
		}
		private static bool CheckingIfListIsEmpty(string choice)
		{
			if (saveAppliance.KitchenApplianceList.Count == 0)
			{
				Console.WriteLine("\n\t\tListan är tom. Börja med att lägga till några köksredskap.");
				Console.ReadKey();
				return true;
			}
			else
			{
				return MenuChoice(choice);
			}
		}

		//Menyvalet skickas in och när metoden är utförd returneras en bool
		//för om programmet ska köra vidare eller inte.
		private static bool MenuChoice(string choice)
		{
			switch (choice)
			{
				case "1":
					//Använda köksapparat
					UseAppliance();
					return true;
				case "2":
					//Lägga till apparat
					AddAppliance();
					return true;
				case "3":
					//Lista alla apparater
					ListAllAppliances();
					return true;
				case "4":
					//Ta bort apparat
					_RemoveAppliance();
					return true;
				case "5":
					//Avsluta programmet
					RepairMachines();
					return true;
				case "6":
					//Avsluta programmet
					CloseProgram();
					return false;
				default:
					//Vid felaktigt val skicka tillbaka användaren till menyn
					DefaultErrorMessage();
					return true;
			}
		}
		private static void UseAppliance()
		{
			UseAppliance useAppliance = new UseAppliance();
			saveAppliance.KitchenApplianceList = useAppliance.UseAppl(saveAppliance.KitchenApplianceList);
		}
		private static void AddAppliance()
		{
			saveAppliance.NewAppliance();
			Utility.EndOfMethod();
			Console.ReadKey();
		}
		private static void ListAllAppliances()
		{
			Console.Clear();
			Console.WriteLine("\n\t\t========== APPARATLISTA ==========");
			Utility.PrintingOutAllAppliances(saveAppliance.KitchenApplianceList);
			Console.WriteLine();
			Utility.EndOfMethod();
			Console.ReadKey();
		}
		private static void _RemoveAppliance()
		{
			saveAppliance.KitchenApplianceList = RemoveAppliance.RemovingAppliance(saveAppliance.KitchenApplianceList);
			Console.ReadKey();
		}
		private static void CloseProgram()
		{
			Console.WriteLine("\t\tDu går ut ur köket.");
			Console.ReadKey();
		}
		private static void RepairMachines()
		{
			foreach(KitchenAppliance appl in saveAppliance.KitchenApplianceList)
			{
				appl.IsFunctioning = true;
			}
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("\n\t\tAlla maskiner är lagade!");
			Console.ForegroundColor = ConsoleColor.White;
			Utility.EndOfMethod();
			Console.ReadKey();
		}
		private static void DefaultErrorMessage()
		{
			Console.WriteLine("\t\tFelaktigt val försök igen.");
			Console.Write("\t\t- ");
			Console.ReadKey();
		}
	}
}

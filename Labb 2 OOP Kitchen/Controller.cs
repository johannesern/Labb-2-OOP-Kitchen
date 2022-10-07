using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen
{
	internal class Controller
	{
		public static SaveAppliance saveAppliance = new SaveAppliance();
		public static Microwave Microwave = new Microwave();
		public static Toaster Toaster = new Toaster();
		public static Stove Stove = new Stove();
		public static Oven Oven = new Oven();

		public void Run()
		{
			Oven = new Oven("Oven", "Bosch", true);
			saveAppliance.KitchenApplianceList.Add(Oven);
			Stove = new Stove("Stove", "Siemens", true);
			saveAppliance.KitchenApplianceList.Add(Stove);
			Toaster = new Toaster("Toaster", "OBH Nordica", true);
			saveAppliance.KitchenApplianceList.Add(Toaster);
			Microwave = new Microwave("Microwave", "Samsung", true);
			saveAppliance.KitchenApplianceList.Add(Microwave);
			EnteringKitchen();
		}
		public static void EnteringKitchen()
		{
			bool showMenu = true;
			while (showMenu)
			{
				Console.Clear();
				Utility.PrintingOutAllAppliances(saveAppliance.KitchenApplianceList);
				Console.WriteLine("\n\t\t========== KÖKET ==========\n" +
								  "\n\t\tVad vill du göra?\n" +
								  "\t\t[1] Använda en köksapparat\n" +
								  "\t\t[2] Lägg till köksapparat\n" +
								  "\t\t[3] Lista köksapparater\n" +
								  "\t\t[4] Ta bort en köksapparat\n" +
								  "\t\t[5] Gå ut ur köket\n");
				Console.Write("\t\t- ");
				string choice = Console.ReadLine();
				showMenu = MenuChoice(choice);
			}
		}
		public static bool MenuChoice(string choice)
		{
			switch (choice)
			{
				case "1":
					//Använda köksapparat
					if (saveAppliance.KitchenApplianceList.Count == 0)
					{
						Console.WriteLine("\t\tListan är tom. Börja med att lägga till några köksredskap.");
						Console.Write("\t\t- ");
					}
					else
					{
						UseAppliance useAppliance = new UseAppliance();
						saveAppliance.KitchenApplianceList = useAppliance.UseAppl(saveAppliance.KitchenApplianceList);
					}
					Console.Write("\t\t- ");
					Console.ReadKey();
					return true;
				case "2":
					//Lägga till apparat
					saveAppliance.NewAppliance();
					return true;
				case "3":
					//Lista alla apparater
					if(saveAppliance.KitchenApplianceList.Count == 0)
					{
						Console.WriteLine("\t\tListan är tom. Börja med att lägga till några köksredskap.");						
					}
					else
					{
						Utility.PrintingOutAllAppliances(saveAppliance.KitchenApplianceList);
					}
					Console.Write("\t\t- ");
					Console.ReadKey();
					return true;
				case "4":
					//Ta bort apparat
					if (saveAppliance.KitchenApplianceList.Count == 0)
					{
						Console.WriteLine("\t\tListan är tom. Börja med att lägga till några köksredskap.");
						Console.Write("\t\t- ");
					}
					else
					{
						saveAppliance.RemoveAppliance();
					}
					Console.ReadKey();
					return true;
				case "5":
					//Avsluta programmet
					Console.WriteLine("\t\tDu går ut ur köket.");
					Console.ReadKey();
					return false;
				default:
					//Vid felaktigt val skicka tillbaka användaren till menyn
					Console.WriteLine("\t\tFelaktigt val försök igen.");
					Console.Write("\t\t- ");
					Console.ReadKey();
					return true;
			}
		}
	}
}

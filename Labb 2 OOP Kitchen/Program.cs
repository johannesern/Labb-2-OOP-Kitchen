namespace Labb_2_OOP_Kitchen
{
	internal class Program
	{
		public static SaveAppliance saveAppl = new SaveAppliance();

		static void Main(string[] args)
		{
			Oven oven = new Oven("Oven", "Bosch", true);
			saveAppl.KitchenApplianceList.Add(oven);
			Stove stove = new Stove("Stove", "Siemens", true);
			saveAppl.KitchenApplianceList.Add(stove);
			Toaster toaster = new Toaster("Toaster", "OBH Nordica", false);
			saveAppl.KitchenApplianceList.Add(toaster);
			Microwave microwave = new Microwave("Microwave", "Samsung", true);
			saveAppl.KitchenApplianceList.Add(microwave);
			EnteringKitchen();
		}

		public static void EnteringKitchen()
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
					UseAppliance();					
					return true;
				case "2":
					//Lägga till apparat
					saveAppl.NewAppliance();
					return true;
				case "3":
					//Lista alla apparater
					saveAppl.PrintingOutAllAppliances();
					Console.ReadKey();
					return true;
				case "4":
					//Ta bort apparat
					saveAppl.RemoveAppliance();
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

		private static void UseAppliance()
		{			
			saveAppl.PrintingOutAllAppliances();
			Console.WriteLine("\n\t\tVilken köksapparat vill ni använda?");
			Console.Write("\t\t- ");
			int applianceIndex = saveAppl.DefiningInt() - 1;
			bool run = true;
			do
			{
				switch (saveAppl.KitchenApplianceList[applianceIndex].Type)
				{
					case "Toaster":
						{
							Toaster toaster = new Toaster(saveAppl.KitchenApplianceList[applianceIndex].Type, 
														  saveAppl.KitchenApplianceList[applianceIndex].Brand, 
														  saveAppl.KitchenApplianceList[applianceIndex].IsFunctioning);
							break;
						}
					case "Stove":
						{
							Stove stove = new Stove();
							stove.Use(tmpAppl[0].TimesUsed, tmpAppl[0].IsFunctioning);
							break;
						}
					case "Microwave":
						{
							Microwave microwave = new Microwave();
							microwave.Use(tmpAppl[0].TimesUsed, tmpAppl[0].IsFunctioning);
							break;
						}
					case "Oven":
						{
							Oven oven = new Oven();
							oven.Use(tmpAppl[0].TimesUsed, tmpAppl[0].IsFunctioning);
							break;
						}
					case "Other":
						{
							//Other other = new Other();
							//toaster.Use(tmpAppl[0].TimesUsed, tmpAppl[0].IsFunctioning);
							break;
						}
					default:
						{
							Console.WriteLine("Apparaten finns inte försök igen.");
							break;
						}
						Console.ReadKey();
				}
			} while (run);
		}
	}
}
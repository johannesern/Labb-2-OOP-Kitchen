namespace Labb_2_OOP_Kitchen
{
	internal class Program
	{
		public static List<IKitchenAppliance> appliances = new List<IKitchenAppliance>();

		static void Main(string[] args)
		{
			Oven oven = new Oven("Ugn", "Bosch", true);
			appliances.Add(oven);
			Stove stove = new Stove("Häll", "Siemens", true);
			appliances.Add(stove);
			Toaster toaster = new Toaster("Brödrost", "OBH Nordica", false);
			appliances.Add(toaster);
			Microwave microwave = new Microwave("Mikrovågsugn", "Samsung", true);
			appliances.Add(microwave);
			KitchenOverView();
		}

		public static void KitchenOverView()
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

					return true;
				case "2":
					//Lägga till apparat

					return true;
				case "3":
					//Lista alla apparater
					PrintingOutAllAppliances();
					Console.ReadKey();
					return true;
				case "4":
					//Ta bort apparat
					SwitchCase4RemoveAppliance();
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

		private static void SwitchCase4RemoveAppliance()
		{
			PrintingOutAllAppliances();
			Console.WriteLine("\n\t\tVilken apparat vill du ta bort? (Skriv in ett heltal)");
			Console.Write("\t\t- ");
			string input = Console.ReadLine();

			int applianceIndex = DefiningInt(input);
			Console.WriteLine("\t\tÄr du säker på att du vill ta bort\n" + 
							  "\t\t" + appliances[applianceIndex].Type + "\t" + appliances[applianceIndex].Brand);
			Console.WriteLine("\t\t[1] Ja [2] Nej");
			Console.Write("\t\t- ");
			string removeOrNot = Console.ReadLine();
			if(removeOrNot.ToUpper() == "JA")
			{
				RemovingApplianceFromList(applianceIndex);
			}
			else
			{
				Console.WriteLine("Inget borttaget, tryck på valfri knapp för att återgå till huvudmenyn.");
				Console.ReadKey();
			}
		}

		private static int DefiningInt(string input)
		{
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
					input = Console.ReadLine();
					Console.Write("\t\t- ");
				}
			} while (run);

			return applianceIndex;
		}

		private static void RemovingApplianceFromList(int applianceIndex)
		{
			bool flag = false;
			try
			{
				appliances.RemoveAt(applianceIndex - 1);
			}
			catch (Exception ex)
			{
				flag = true;
				Console.WriteLine(ex);
			}
			finally
			{
				if (flag)
				{
					Console.Clear();
					SwitchCase4RemoveAppliance();
				}
				else
				{
				}
			}
		}

		public static void PrintingOutAllAppliances()
		{
			Console.WriteLine("\n\t\tIndex\tTyp\t\tMärke\t\tFungerar?");
			int counter = 1;
			foreach (IKitchenAppliance appliance in appliances)
			{
				Console.WriteLine();
				Console.Write("\t\t" + counter);
				if (appliance.Type.Length < 8 && appliance.Brand.Length < 8)
				{
					Console.Write("\t" + appliance.Type +
								  "\t\t" + appliance.Brand +
								  "\t\t" + appliance.IsFunctioning);
				}
				else if (appliance.Type.Length > 7 && appliance.Brand.Length > 7)
				{
					Console.Write("\t" + appliance.Type +
								  "\t" + appliance.Brand +
								  "\t" + appliance.IsFunctioning);
				}
				else if (appliance.Type.Length < 8 && appliance.Brand.Length > 7)
				{
					Console.Write("\t" + appliance.Type +
								  "\t\t" + appliance.Brand +
								  "\t" + appliance.IsFunctioning);
				}
				else
				{
					Console.Write("\t" + appliance.Type +
								  "\t" + appliance.Brand +
								  "\t\t" + appliance.IsFunctioning);
				}
				counter++;
			}
			Console.WriteLine();
		}
	}
}
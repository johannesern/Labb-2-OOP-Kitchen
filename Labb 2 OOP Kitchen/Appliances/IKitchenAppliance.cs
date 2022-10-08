using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen.Appliances
{
    public interface IKitchenAppliance
    {
        string Type { get; set; }
        string Brand { get; set; }
        public bool IsFunctioning { get; set; }
        public KitchenAppliance Use(KitchenAppliance appl);
    }

    abstract public class KitchenAppliance : IKitchenAppliance
    {
        public int TimesUsed { get; set; }
        public string Type { get; set; }
        public string SweType { get; set; }
		public string Brand { get; set; }
        public bool IsFunctioning { get; set; }

        public KitchenAppliance(string type, string brand, bool isFunctioning)
        {
            TimesUsed = AroundTheCornerWarranty();
            Type = type;
            SweType = TranslateType(type);
            Brand = brand;
            IsFunctioning = isFunctioning;
        }

        public KitchenAppliance()
        {
        }

        public virtual KitchenAppliance Use(KitchenAppliance appl)
        {
            string machineMalfunctionMessage = "*maskinen funkar inte*";
            string machineWorkingMessage = "*maskinen funkar*";
            return WillItBreak(machineMalfunctionMessage, machineWorkingMessage, appl);
        }

        protected KitchenAppliance WillItBreak(string machineMalfunctionMessage, string machineWorkingMessage, KitchenAppliance appl)
        {
            appl.TimesUsed++;
            if (appl.IsFunctioning)
            {
                Random rnd = new Random();
                if (appl.TimesUsed > rnd.Next(1, 5))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t\t" + machineMalfunctionMessage);
					Console.ForegroundColor = ConsoleColor.White;
					appl.IsFunctioning = false;
                    return appl;
                }
                else
                {
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("\n\t\t" + machineWorkingMessage);
					Console.ForegroundColor = ConsoleColor.White;
					return appl;
                }
            }
            else
            {
                RepairMessage();
                return appl;
            }
        }
        private void RepairMessage()
        {
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("\n\t\tApparaten är trasig, kontakta en reparatör");
			Console.ForegroundColor = ConsoleColor.White;
		}
		protected string TranslateType(string type)
		{
			string SweType = "";
			switch (type)
			{
				case "Toaster":
					{
						return SweType =  "Brödrost";
					}
				case "Microwave":
					{
						return SweType = "Mikrovågsugn";
					}
				case "Oven":
					{
						return SweType = "Ugn";
					}
				case "Stove":
					{
						return SweType = "Spis/Häll";
					}
				case "Other":
					{
						return SweType = "Annan";
					}
			}
			return SweType;
		}
        protected int AroundTheCornerWarranty()
        {
            Random random = new Random();
            return random.Next(1, 5);
        }
	}
}

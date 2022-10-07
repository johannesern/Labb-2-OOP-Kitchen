using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen
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
		public string Brand { get; set; }
		public bool IsFunctioning { get; set; }

		public KitchenAppliance(string type, string brand, bool isFunctioning)
		{
			TimesUsed = 0;
			Type = type;
			Brand = brand;
			IsFunctioning = isFunctioning;
		}

		public KitchenAppliance()
		{

		}

		public virtual KitchenAppliance Use(KitchenAppliance appl)
		{
			string machineMalfunctionMessage = "\t\t*maskinen funkar inte*";
			string machineWorkingMessage = "\t\t*maskinen funkar*";
			return appl = WillItBreak(machineMalfunctionMessage, machineWorkingMessage, appl);
		}

		protected KitchenAppliance WillItBreak(string machine, string sound, KitchenAppliance appl)
		{
			if (appl.IsFunctioning)
			{
				Random rnd = new Random();
				if (appl.TimesUsed > rnd.Next(1, 2))
				{
					Console.WriteLine("\t\t" + machine);
					appl.IsFunctioning = false;
					return appl;
				}
				else
				{
					Console.WriteLine("\t\t" + sound);					
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
			Console.WriteLine("\t\tApparaten är trasig, kontakta en reparatör");
		}
	}
}

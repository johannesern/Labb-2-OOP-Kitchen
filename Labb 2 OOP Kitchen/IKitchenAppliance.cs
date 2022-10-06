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

		public void Use(int timesUsed, bool isFunctioning);
	}

	abstract public class KitchenAppliance : IKitchenAppliance
	{
		internal int TimesUsed { get; set; }
		public string Type { get; set; }
		public string Brand { get; set; }
		public bool IsFunctioning { get; set; }

		public virtual void Use(int timesUsed, bool isFunctioning)
		{
			string machineMalfunctionMessage = "*maskinen funkar inte*";
			string machineWorkingMessage = "*maskinen funkar*";
			WillItBreak(machineMalfunctionMessage, machineWorkingMessage, isFunctioning, timesUsed);
		}

		protected bool WillItBreak(string machine, string sound, bool IsFunctioning, int TimesUsed)
		{
			if (IsFunctioning)
			{
				TimesUsed++;
				Random rnd = new Random();
				if (TimesUsed > rnd.Next(1, 2))
				{
					Console.WriteLine(machine);
					return false;
				}
				else
				{
					Console.WriteLine(sound);					
					return true;
				}
			}
			else
			{
				RepairMessage();
				return false;
			}
		}
		private void RepairMessage()
		{
			Console.WriteLine("Apparaten är trasig, kontakta en reparatör");
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen
{
	public class Microwave : KitchenAppliance, IKitchenAppliance
	{
		public string Type { get; set; }
		public string Brand { get; set; }
		public bool IsFunctioning { get; set; }
		private int TimesUsed { get; set; }
		public Microwave(string type, string brand, bool isFunctioning)
		{
			Type = type;
			Brand = brand;
			IsFunctioning = isFunctioning;
		}

		public void Use()
		{
			if (IsFunctioning)
			{
				TimesUsed++;
				Random rnd = new Random();
				if (TimesUsed > rnd.Next(1, 10))
				{
					IsFunctioning = false;
					Console.WriteLine("KABOOM! Åh nej micron pajade!");
				}
				else
				{
					Console.WriteLine("beeping");
				}
			}
			else
			{
				RepairMessage();
			}
		}
	}
}

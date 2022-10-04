using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen
{
	public class Stove : KitchenAppliance, IKitchenAppliance
	{
		public string Type { get; set; }
		public string Brand { get; set; }
		public bool IsFunctioning { get; set; }
		private int TimesUsed { get; set; }
		public Stove(string type, string brand, bool isFunctioning)
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
					Console.WriteLine("Fiskpinnen blir ju knappt ljummen! Aha, den har fastnat på läge 2...");
				}
				else
				{
					Console.WriteLine("heating");
				}
			}
			else
			{
				RepairMessage();
			}
		}
	}
}

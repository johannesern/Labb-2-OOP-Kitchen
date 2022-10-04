using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen
{
	public class Oven : KitchenAppliance
	{
		private int TimesUsed;
		public Oven(string type, string brand, bool isFunctioning)
		{
			Type = type;
			Brand = brand;
			IsFunctioning = isFunctioning;
			TimesUsed = 0;
		}
		public Oven()
		{

		}
		public override void Use()
		{
			string machineMalfunctionMessage = "Skiiiit säkringen gick! Kortis i ugnen!";
			string machineWorkingMessage = "baking";
			TimesUsed = WillItBreak(machineMalfunctionMessage, machineWorkingMessage, IsFunctioning, TimesUsed);
		}
	}
}

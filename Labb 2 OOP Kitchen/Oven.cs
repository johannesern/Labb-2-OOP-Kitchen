using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen
{
	public class Oven : KitchenAppliance
	{
		public int TimesUsed { get; set; }
		public Oven(string type, string brand, bool isFunctioning)
		{
			Type = type;
			Brand = brand;
			IsFunctioning = isFunctioning;
			TimesUsed = 5;
		}
		public Oven()
		{
		}

		public override void Use(int timesUsed, bool isFunctioning)
		{
			string machineMalfunctionMessage = "Skiiiit säkringen gick! Kortis i ugnen!";
			string machineWorkingMessage = "*bakar något*";			
			WillItBreak(machineMalfunctionMessage, machineWorkingMessage, isFunctioning, timesUsed);
		}
	}
}

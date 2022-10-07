using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen
{
	public class Oven : KitchenAppliance
	{		
		public Oven(string type, string brand, bool isFunctioning) : base(type, brand, isFunctioning)
		{
			TimesUsed = 5;
			Type = type;
			Brand = brand;
			IsFunctioning = isFunctioning;			
		}
		
		public Oven()
		{

		}

		public override KitchenAppliance Use(KitchenAppliance appl)
		{
			string machineMalfunctionMessage = "Skiiiit säkringen gick! Kortis i ugnen!";
			string machineWorkingMessage = "*bakar något*";			
			return appl = WillItBreak(machineMalfunctionMessage, machineWorkingMessage, appl);
		}
	}
}

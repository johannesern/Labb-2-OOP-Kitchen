using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen
{
	public class Stove : KitchenAppliance
	{		
		public Stove(string type, string brand, bool isFunctioning) : base(type, brand, isFunctioning)
		{
			TimesUsed = 5;
			Type = type;
			Brand = brand;
			IsFunctioning = isFunctioning;
		}
		
		public Stove()
		{

		}

		public override KitchenAppliance Use(KitchenAppliance appl)
		{
			string machineMalfunctionMessage = "Fiskpinnen blir ju knappt ljummen! Aha, den har fastnat på läge 2...";
			string machineWorkingMessage = "*steker fiskpinnen*";
			return appl = WillItBreak(machineMalfunctionMessage, machineWorkingMessage, appl);
		}
	}
}

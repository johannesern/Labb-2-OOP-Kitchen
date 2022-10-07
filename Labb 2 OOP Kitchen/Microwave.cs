using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen
{
	public class Microwave : KitchenAppliance
	{		
		public Microwave(string type, string brand, bool isFunctioning) : base(type, brand, isFunctioning)
		{
			TimesUsed = 5;
			Type = type;			
			Brand = brand;
			IsFunctioning = isFunctioning;			
		}		
		
		public Microwave()
		{

		}

		public override KitchenAppliance Use(KitchenAppliance appl)
		{
			string machineMalfunctionMessage = "KABOOM! Åh nej micron pajade!";
			string machineWorkingMessage = "*värmer tallriken, inte maten*";
			return appl = WillItBreak(machineMalfunctionMessage, machineWorkingMessage, appl);
		}
	}
}

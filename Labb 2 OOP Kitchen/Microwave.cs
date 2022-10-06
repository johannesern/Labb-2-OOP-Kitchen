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
		public int TimesUsed { get; set; }
		public Microwave(string type, string brand, bool isFunctioning)
		{
			Type = type;			
			Brand = brand;
			IsFunctioning = isFunctioning;
			TimesUsed = 5;
		}		

		public Microwave()
		{
		}

		public override void Use(int timesUsed, bool isFunctioning)
		{
			string machineMalfunctionMessage = "KABOOM! Åh nej micron pajade!";
			string machineWorkingMessage = "*värmer tallriken, inte maten*";
			WillItBreak(machineMalfunctionMessage, machineWorkingMessage, isFunctioning, timesUsed);
		}
	}
}

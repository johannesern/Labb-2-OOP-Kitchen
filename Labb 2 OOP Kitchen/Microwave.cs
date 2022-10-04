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
		private int TimesUsed;
		public Microwave(string type, string brand, bool isFunctioning)
		{
			Type = type;
			Brand = brand;
			IsFunctioning = isFunctioning;
			TimesUsed = 0;
		}

		public Microwave()
		{
		}

		public override void Use()
		{
			string machineMalfunctionMessage = "KABOOM! Åh nej micron pajade!";
			string machineWorkingMessage = "beeping";
			TimesUsed = WillItBreak(machineMalfunctionMessage, machineWorkingMessage, IsFunctioning, TimesUsed);
		}
	}
}

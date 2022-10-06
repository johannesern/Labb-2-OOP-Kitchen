using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen
{
	public class Stove : KitchenAppliance
	{
		public int TimesUsed { get; set; }
		public Stove(string type, string brand, bool isFunctioning)
		{
			Type = type;
			Brand = brand;
			IsFunctioning = isFunctioning;
			TimesUsed = 5;
		}
		public Stove()
		{
		}

		public override void Use(int timesUsed, bool isFunctioning)
		{
			string machineMalfunctionMessage = "Fiskpinnen blir ju knappt ljummen! Aha, den har fastnat på läge 2...";
			string machineWorkingMessage = "*steker fiskpinnen*";
			WillItBreak(machineMalfunctionMessage, machineWorkingMessage, isFunctioning, timesUsed);
		}
	}
}

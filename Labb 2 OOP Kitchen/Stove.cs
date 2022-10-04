using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen
{
	public class Stove : KitchenAppliance
	{
		private int TimesUsed;
		public Stove(string type, string brand, bool isFunctioning)
		{
			Type = type;
			Brand = brand;
			IsFunctioning = isFunctioning;
			TimesUsed = 0;
		}
		public Stove()
		{

		}

		public override void Use()
		{
			string machineMalfunctionMessage = "Fiskpinnen blir ju knappt ljummen! Aha, den har fastnat på läge 2...";
			string machineWorkingMessage = "heating";
			TimesUsed = WillItBreak(machineMalfunctionMessage, machineWorkingMessage, IsFunctioning, TimesUsed);
		}
	}
}

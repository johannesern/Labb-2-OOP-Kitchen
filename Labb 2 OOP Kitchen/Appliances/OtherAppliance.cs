using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen.Appliances
{
	public class OtherAppliance : KitchenAppliance
	{
		public OtherAppliance(string type, string userInputType, string brand, bool isFunctioning) : base(type, brand, isFunctioning)
		{
			//Förklaring, se basklass
			TimesUsed = AroundTheCornerWarranty();
			Type = type;
			Brand = brand;
			SweType = userInputType;
			IsFunctioning = isFunctioning;
		}
		public OtherAppliance()
		{
		}
		public KitchenAppliance Use(KitchenAppliance appl)
		{
			string machineMalfunctionMessage = "tomt";
			string machineWorkingMessage = "tomt";
			return WillItBreak(machineMalfunctionMessage, machineWorkingMessage, appl);
		}
	}
}

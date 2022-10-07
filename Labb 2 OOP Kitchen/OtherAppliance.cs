using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen
{
	internal class OtherAppliance : KitchenAppliance
	{
		public int TimesUsed { get; set; }
		public string Type { get; set; }
		public string Brand { get; set; }
		public bool IsFunctioning { get; set; }

		public OtherAppliance()
		{

		}
	}
}

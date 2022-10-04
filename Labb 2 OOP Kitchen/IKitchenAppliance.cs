using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen
{
	public interface IKitchenAppliance
	{
		string Type { get; set; }
		string Brand { get; set; }
		public bool IsFunctioning { get; set; }
		
		void Use();
	}

	abstract public class KitchenAppliance
	{
		private int TimesUsed;
		
		public void RepairMessage()
		{
			Console.WriteLine("Apparaten är trasig, kontakta en reparatör");
		}
	}
}

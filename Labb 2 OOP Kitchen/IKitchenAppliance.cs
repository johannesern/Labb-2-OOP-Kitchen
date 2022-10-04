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

	abstract public class KitchenAppliance : IKitchenAppliance
	{
		private List<KitchenAppliance> kitchenAppl = new List<KitchenAppliance>();
		public List<KitchenAppliance> KitchenAppl
		{
			get { return kitchenAppl; }
			set { kitchenAppl = value; }
		}
		public string Type { get; set; }
		public string Brand { get; set; }
		public bool IsFunctioning { get; set; }		

		public virtual void Use()
		{

		}

		protected int WillItBreak(string machine, string sound, bool IsFunctioning, int TimesUsed)
		{
			if (IsFunctioning)
			{
				TimesUsed++;
				Random rnd = new Random();
				if (TimesUsed > rnd.Next(1, 6))
				{
					IsFunctioning = false;
					Console.WriteLine(machine);
					return TimesUsed;
				}
				else
				{
					Console.WriteLine(sound);
					return TimesUsed;
				}
			}
			else
			{
				RepairMessage();
				return TimesUsed;
			}
		}
		private void RepairMessage()
		{
			Console.WriteLine("Apparaten är trasig, kontakta en reparatör");
		}
	}
}

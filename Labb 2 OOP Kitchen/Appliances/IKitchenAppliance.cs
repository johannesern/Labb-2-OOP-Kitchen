using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen.Appliances
{
    public interface IKitchenAppliance
    {
        string Type { get; set; }
        string Brand { get; set; }
        public bool IsFunctioning { get; set; }
        public KitchenAppliance Use(KitchenAppliance appl);
    }
}

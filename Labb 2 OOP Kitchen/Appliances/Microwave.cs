using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_OOP_Kitchen.Appliances
{
    public class Microwave : KitchenAppliance
    {
        public Microwave(string type, string brand, bool isFunctioning) : base(type, brand, isFunctioning)
        {
            TimesUsed = 5;
            Type = type;
            SweType = TranslateType(Type);
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
            return WillItBreak(machineMalfunctionMessage, machineWorkingMessage, appl);
        }
    }
}

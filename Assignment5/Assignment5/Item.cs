using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    public enum ItemGroup { Consumable, Key, Equipment };
    public class Item
    {
        public string Name { get; set; }
        public int ContextAmount { get; set; } // Consumable (how much is restored) / Key (uses) / Equipment (damage)

        public ItemGroup Group { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        /// <param name="group"></param>
        public Item(string name, int amount, ItemGroup group)
        {
            Name = name;
            ContextAmount = amount;
            Group = group;
        }

        public override string ToString()
        {
            // TODO: display the output like this Axe
            return this.Name;
        }
    }
}

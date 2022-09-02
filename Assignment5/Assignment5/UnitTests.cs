using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignment5
{
    class UnitTests
    {
        Inventory inventory;
        Character hero;
  
        [SetUp]
        public void SetUp()
        {
            inventory = new Inventory(10);
        hero = new Character("Bob", RaceCategory.Human, 100);

            inventory.AddItem(new Item("Axe", 15, ItemGroup.Equipment));
            inventory.AddItem(new Item("Apple", 15, ItemGroup.Consumable));
            inventory.AddItem(new Item("Key", 15, ItemGroup.Key));

        }

        [Test]
        public void TakeDamge_ReduceCorrectAmount()
        {
            int originalHp = hero.Health;
            hero.TakeDamage(10);
            Assert.IsTrue((originalHp - 10) == hero.Health);
        }

        [Test]
        public void TakeDamge_SetAliveFalse()
        {
            hero.TakeDamage(hero.Health);
            Assert.IsFalse(hero.IsAlive);
        }

        [Test]
        public void RestoreHP()
        {
            int originalHp = hero.Health;
            hero.RestoreHealth(10);
            Assert.AreEqual(originalHp + 10, hero.Health);
        }

        [Test]
        public void RestoreHP_SetIsAlive()
        {
            hero.Health = 0;
            hero.IsAlive = false;

            hero.RestoreHealth(10);
            Assert.IsTrue(hero.IsAlive);
        }


        [Test]
        public void RemoveItem_Inventory()
        {
            //• RemoveItem - found item is set, returns true, verify the available slots increase
            int cacheAvaibleSlots = inventory.AvailableSlots;
            Item foundItem;
            inventory.TakeItem("Axe", out foundItem);
            Assert.IsTrue(inventory.AvailableSlots > cacheAvaibleSlots);
        }


        
        [Test]
        public void RemoveItem_ItemIsNull()
        {
            //• RemoveItem - found item is null, returns false, verify the available slots remain the same
            int cacheAvaibleSlots = inventory.AvailableSlots;
            Item foundItem;
            bool result = inventory.TakeItem("NULL_ITEM", out foundItem);
            Assert.IsTrue(inventory.AvailableSlots == cacheAvaibleSlots);
            Assert.IsTrue(foundItem==null);
            Assert.IsFalse(result);

        }

        [Test]
        public void AddItem_DecresesANumber()
        {
            //• AddItem - verify the available slots decreases and use ListAllItems to verify it exists

            int cacheAvaibleSlots = inventory.AvailableSlots;
            inventory.AddItem(new Item("TestItem", 13, ItemGroup.Key));

            Assert.IsTrue(cacheAvaibleSlots > inventory.AvailableSlots);

            var itemslist = inventory.ListAllItems();
            var xItem = itemslist.Find(x => x.Name == "TestItem");

            Assert.IsTrue(xItem != null);
        }

        //• Reset - removes all the items, and max slots restored
        [Test]
        public void Reset_Test()
        {
            //• AddItem - verify the available slots decreases and use ListAllItems to verify it exists

            int cacheAvaibleSlots = inventory.AvailableSlots;
            Item foundItem;
            inventory.TakeItem("TestItem", out foundItem);
            inventory.TakeItem("Key", out foundItem);
            inventory.TakeItem("Axe", out foundItem);
            inventory.TakeItem("Apple", out foundItem);

            Assert.AreEqual(inventory.AvailableSlots, inventory.MaxSlots);
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections;
using Iteration2;

namespace TestIteration2
{
    public class InventoryTests
    {
        private Item shovel;
        private Item sword;
        private Item pc;
        private Inventory inventory;

        [SetUp]
        public void Setup()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a might fine shovel");
            Item sword = new Item(new string[] { "sword", "blade" }, "a bronze sword", "This is most bronze sword");
            Item pc = new Item(new string[] { "pc", "computer" }, "a small computer", "This is a pocket-sized computer");
            inventory = new Inventory();

            inventory.Put(shovel);
            inventory.Put(sword);
            inventory.Put(pc);
        }

        [Test]
        public void TestFindItem()
        {
            Assert.IsTrue(inventory.HasItem("shovel"));
            Assert.IsTrue(inventory.HasItem("sword"));
            Assert.IsTrue(inventory.HasItem("pc"));
        }

        [Test]
        public void TestNoItemFind()
        {
            Assert.IsFalse(inventory.HasItem("stick"));
        }

        [Test]
        public void TestFetchItem()
        {
            Assert.NotNull(inventory.Fetch("shovel"));
            Assert.IsTrue(inventory.HasItem("shovel"));
        }

        [Test]
        public void TestTakeItem()
        {
            Assert.NotNull(inventory.Take("sword"));
            Assert.IsFalse(inventory.HasItem("sword"));
        }

        [Test]
        public void TestItemList()
        {
            string ItemList = "a shovel (shovel)\na bronze sword (sword)\na small computer (pc)";
            Assert.That(inventory.ItemList, Is.EqualTo(ItemList));
        }
    }
}

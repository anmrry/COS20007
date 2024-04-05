using NUnit.Framework;
using System;
using Iteration2;

namespace TestIteration2
{
    public class PlayerTests
    {
        private Player player;

        [SetUp]
        public void Setup()
        {
            player = new Player("Fred", "the mighty programmer");
            player.Inventory.Put(new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a might fine shovel"));
            player.Inventory.Put(new Item(new string[] { "sword", "blade" }, "a bronze sword", "This is most bronze sword"));
            player.Inventory.Put(new Item(new string[] { "pc", "computer" }, "a small computer", "This is a pocket-sized computer"));
        }

        [Test]
        public void TestPlayerIsIdentifiable()
        {
            Assert.IsTrue(player.AreYou("me"));
            Assert.IsTrue(player.AreYou("inventory"));
        }

        [Test]
        public void TestPlayerLocateItems()
        {
            Assert.IsTrue(player.Locate("shovel").AreYou("shovel"));
            Assert.IsTrue(player.Locate("sword").AreYou("sword"));
            Assert.IsTrue(player.Locate("pc").AreYou("pc"));
        }

        [Test]
        public void TestPlayerLocateItself()
        {
            Assert.IsTrue(player.Locate("me").AreYou("me"));
            Assert.IsTrue(player.Locate("inventory").AreYou("inventory"));
        }

        [Test]
        public void TestPlayerLocateNothing()
        {
            Assert.IsNull(player.Locate("stick"));
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            string PlayerFullDescription = "You are Fred the mighty programmer\nYou are carrying\na shovel (shovel)\na bronze sword (sword)\na small computer (pc)";
            Assert.That(player.FullDescription, Is.EqualTo(PlayerFullDescription));
        }

    }
}
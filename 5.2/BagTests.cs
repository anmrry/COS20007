using NUnit.Framework;
using System;
using SwinAdventure;
namespace BagTests
{
    public class Tests
    {
        private Bag bag;
        private Bag book;
        private Item photo;
        private Item bread;

        [SetUp]
        public void Setup()
        {
            bag = new Bag(new string[] { "bag" }, "a bag", "This is a tote bag");
            book = new Bag(new string[] { "book" }, "a book", "This is an old classic book");
            photo = new Item(new string[] { "photo" }, "a photo", "This is a photo of a buried treasure location");
            bread = new Item(new string[] { "bread" }, "a loaf of bread", "This is a perfect loaf of bread");

            bag.Inventory.Put(book);
            bag.Inventory.Put(bread);
            book.Inventory.Put(photo);
        }

        [Test]
        public void TestLocateItem()
        {
            Assert.That(bag.Locate("bread"), Is.EqualTo(bread));
            Assert.That(bag.Inventory.HasItem("bread"), Is.EqualTo(true));
        }

        [Test]
        public void TestLocateItself()
        {
            Assert.That(bag.Locate("bag"), Is.EqualTo(bag));
        }

        [Test]
        public void TestLocateNothing()
        {
            Assert.That(bag.Locate("bike"), Is.EqualTo(null));
        }

        [Test]
        public void TestFullDesc()
        {
            Assert.That(bag.FullDescription, Is.EqualTo("In a bag you can see:\na book (book)\na loaf of bread (bread)"));
        }

        [Test]
        public void BaginBag()
        {
            Assert.That(bag.Locate("book"), Is.EqualTo(book));
            Assert.That(bag.Locate("bread"), Is.EqualTo(bread));
            Assert.That(bag.Locate("photo"), Is.EqualTo(null));
        }
    }
}
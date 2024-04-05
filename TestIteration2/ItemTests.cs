using NUnit.Framework;
using System;
using Iteration2;

namespace TestIteration2
{
    public class ItemTests
    {
        private Item pc;

        [SetUp]
        public void Setup()
        {
            pc = new Item(new string[] { "pc", "computer" }, "a small computer", "This is a pocket-sized computer");
        }

        [Test]
        public void TestIdentifiableItem()
        {
           
            Assert.IsTrue(pc.AreYou("pc"));
            Assert.IsTrue(pc.AreYou("computer"));
        }

        [Test]
        public void TestShortDescription()
        {
            Assert.That(pc.ShortDescription, Is.EqualTo("a small computer (pc)"));
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.That(pc.FullDescription, Is.EqualTo("This is a pocket-sized computer"));
        }

    }
}
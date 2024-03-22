using SwinAdventureIteration1;
using NUnit.Framework;

namespace TestIdentifiableObject
{
    public class Tests
    {
        private IdentifiableObject testObject;

        [SetUp]
        public void Setup()
        {
            testObject = new IdentifiableObject(new string[] { "anda", "lana" });
        }

        [Test]
        public void TestAreYou()
        {
            bool isMatch = testObject.AreYou("anda");
            Assert.IsTrue(isMatch);
        }

        [Test]
        public void TestNotAreYou()
        {
            bool isMatch = testObject.AreYou("not");
            Assert.IsFalse(isMatch);
        }

        [Test]
        public void TestCaseSensitive()
        {
            Assert.IsTrue(testObject.AreYou("ANDA"));
        }

        [Test]
        public void TestFirstID()
        {
            string firstID = testObject.FirstId;
            Assert.That(testObject.FirstId, Is.EqualTo("anda"));
        }

        [Test]
        public void TestFirstIDEmpty()
        {
            IdentifiableObject emptyObject = new IdentifiableObject(new string[] { });
            string firstID = emptyObject.FirstId;
            Assert.That(emptyObject.FirstId, Is.EqualTo(""));
        }

        [Test]
        public void TestAddID()
        {
            testObject.AddIdentifier("tobi");
            Assert.IsTrue(testObject.AreYou("tobi"));
        }
    }
}
using SwinAdventure;
using NUnit.Framework;
namespace LookCommandTest
{
    public class LookCommandTest
    {
        LookCommand look;
        Player player;
        Bag bag;
        Item gem;

        [SetUp]
        public void Setup()
        {
            look = new LookCommand();
            player = new Player("Fred", "the mighty programmer");
            bag = new Bag(new string[] { "bag" }, "a bag", "This is a tote bag");
            gem = new Item(new string[] { "gem" }, "a gem", "This is a bright red gemstone");
            GameObject container;

            player.Inventory.Put(gem);
        }

        [Test]
        public void TestLookAtMe()
        {
            Assert.That(look.Execute(player, new string[] { "look", "at", "inventory" }), Is.EqualTo(player.FullDescription));
        }

        [Test]
        public void TestLookAtGem()
        {
            Assert.That(look.Execute(player, new string[] { "look", "at", "gem" }), Is.EqualTo("This is a bright red gemstone"));
        }

        [Test]
        public void TestLookAtUnknown()
        {
            player.Inventory.Take("gem");
            Assert.That(look.Execute(player, new string[] { "look", "at", "gem" }), Is.EqualTo($"I cannot find the gem in Player"));
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            Assert.That(look.Execute(player, new string[] { "look", "at", "gem", "in", "inventory" }), Is.EqualTo("This is a bright red gemstone"));
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            player.Inventory.Take("gem");
            bag.Inventory.Put(gem);
            player.Inventory.Put(bag);
            Assert.That(look.Execute(player, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo("This is a bright red gemstone"));
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            player.Inventory.Take("bag");
            Assert.That(look.Execute(player, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo("I cannot find the bag"));
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            player.Inventory.Put(bag);
            bag.Inventory.Take("gem");
            Assert.That(look.Execute(player, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo($"I cannot find the gem in a bag"));
        }

        [Test]
        public void TestInvalidLook()
        {
            Assert.That(look.Execute(player, new string[] { "look", "around" }), Is.EqualTo("I don't know how to look like that"));
            Assert.That(look.Execute(player, new string[] { "hello", "it's", "me" }), Is.EqualTo("Error in look input"));
            Assert.That(look.Execute(player, new string[] { "look", "at", "a", "at", "b" }), Is.EqualTo("What do you want to look in?"));
            Assert.That(look.Execute(player, new string[] { "look", "in", "bag", "for", "gem" }), Is.EqualTo("What do you want to look at?"));
        }

    }
}
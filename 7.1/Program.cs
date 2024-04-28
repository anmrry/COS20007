using System.Threading;

namespace SwinAdventure
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Swin Adventure!");
            
            Console.WriteLine("Enter your name: ");
            string playerName = Console.ReadLine();

            Console.WriteLine("Enter your description: ");
            string playerDesc = Console.ReadLine();

            Player player = new Player(playerName, playerDesc);
            
            Item photo = new Item(new string[] { "photo" }, "a photo", "This is a photo of a buried treasure location");
            Item bread = new Item(new string[] { "bread" }, "a loaf of bread", "This is a perfect loaf of bread");
            player.Inventory.Put(photo);
            player.Inventory.Put(bread);

            Bag bag = new Bag(new string[] { "bag" }, "a bag", "This is a tote bag");
            player.Inventory.Put(bag);

            Item book = new Item(new string[] { "book" }, "a book", "This is an old classic book");
            bag.Inventory.Put(book);

            bool keepPlaying = true;
            while (keepPlaying)
            {
                Console.WriteLine("Command -> ");
                string command = Console.ReadLine();
                string[] commandWords = command.Split(' ');

                //Check if the command is quit
                if (commandWords[0].ToLower() == "quit")
                {
                    keepPlaying = false;
                    Console.WriteLine();
                    Console.WriteLine("Bye!");
                }
                else
                {
                    // Check if the command is look
                    if (commandWords[0].ToLower() == "look")
                    {
                        LookCommand look = new LookCommand();
                        Console.WriteLine(look.Execute(player, commandWords));
                    }
                    else
                    {
                        // Handle other commands
                        Console.WriteLine("I don't understand " + command);
                    }
                }
            }
        }
    }
}

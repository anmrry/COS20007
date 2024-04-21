using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory container = null;
            if (text.Length != 3 && text.Length != 5)
            {
                return "I don't know how to look like that";
            }
            else if (text[0] != "look")
            { 
                return "Error in look input";
            }
            else if (text[1] != "at")
            {
                return "What do you want to look at?";
            }
            else if (text.Length == 5 && text[3] != "in")
            {
                return "What do you want to look in?";
            }
            else if (text.Length == 3)
            {
                container = p;
            }
            else if (text.Length == 5)
            {
                container = FetchContainer(p, text[4]);
                    if (container == null)
                    {
                        return "I cannot find the " + text[4];
                    }
                }
            string itemId = text[2];
            return LookAtIn(itemId, container);       
            
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            GameObject obj = p.Locate(containerId);
            IHaveInventory container = obj as IHaveInventory;
            if (container == null)
            {
                return null;
            }
            else
            {
                return container;
            }
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject thing = container.Locate(thingId);
            if (thing == null)
            {
                return "I cannot find the " + thingId;
            }
            else
            {
                return thing.FullDescription;
            }
        }
    }
}

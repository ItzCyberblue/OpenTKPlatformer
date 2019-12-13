using System;

namespace OpenTK_RPG
{
    public class Item
    {
        public string name = string.Empty;
        public string type = string.Empty;
        public string Description = string.Empty;
        public int value = 0;
        public Item( string name, string type, string Description, int value)
        {
            this.name = name;
            this.type = type;
            this.Description = Description;
            this.value = value;
        }
    }
}
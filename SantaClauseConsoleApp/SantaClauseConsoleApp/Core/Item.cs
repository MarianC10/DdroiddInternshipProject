using System;

namespace SantaClauseConsoleApp
{
    public class Item
    {
        private Guid id;
        private string name;

        public Item(string name) {
            this.id = Guid.NewGuid();
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public Guid Id
        {
            get { return id; }
        }

        public override string ToString()
        {
            return $"Item ID: {id.ToString()}\nItem Name: {name}";
        }
    }
}

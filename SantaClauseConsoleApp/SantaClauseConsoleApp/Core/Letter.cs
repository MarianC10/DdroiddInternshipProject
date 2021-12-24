using System;
using System.Collections.Generic;
using System.Text;

namespace SantaClauseConsoleApp
{
    public class Letter
    {
        private List<Item> items;
        private DateTime date;

        public Letter()
        {
            items = new List<Item>();
            date = DateTime.Now;
        }
        public List<Item> Items
        {
            get { return items; }
        }

        public DateTime Date
        {
            get { return date; }
        }

        public void addItem(Item item)
        {
            this.items.Add(item);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Letter date: " + date.ToString() + "\nItems on letter:");

            foreach (Item item in items)
            {
                stringBuilder.Append("\n" + item.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}

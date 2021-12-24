using System;
using System.Collections.Generic;

namespace SantaClauseConsoleApp
{
    public class SantaClaus
    {
        public static SantaClaus GET = new SantaClaus();
        private List<Child> children;
        private string name;

        private SantaClaus()
        {
            this.name = "Santa Claus";
            this.children = new List<Child>();
        }

        public string Name
        {
            get { return name; }
        }

        public List<Child> Children
        {
            set { children = value; }
        }

        public List<(string, int)> getToyReport()
        {
            List<string> items = new List<string>();
            List<(string, int)> report = new List<(string, int)>();

            foreach (Child child in children)
            {
                foreach (Item item in child.Letter.Items)
                    items.Add(item.Name); 
            }

            items.Sort();

            int count = 1;
            for (int i = 1; i < items.Count; ++i)
            {
                if (items[i] != items[i - 1])
                {
                    report.Add((items[i - 1], count));
                    count = 1;
                }
                else
                    ++count;
            }

            report.Add((items[items.Count - 1], count));
            report.Sort(
                ((string, int quantity) obj1, (string, int quantity) obj2) =>
                {
                    return obj1.quantity < obj2.quantity ? 1 : -1;
                }
            );

            return report;
        }

        public List<FullAddress> getGroupedAddresses()
        {
            List<FullAddress> addresses = new List<FullAddress>();

            foreach (Child child in children)
            {
                addresses.Add(child.Address);
            }

            addresses.Sort(
                (FullAddress adr1, FullAddress adr2) =>
                {
                    int cmp = String.Compare(adr1.City, adr2.City);

                    if (cmp == 0)
                        return String.Compare(adr1.Country, adr2.Country);

                    return cmp;
                }
            );

            return addresses;
        }
    }
}
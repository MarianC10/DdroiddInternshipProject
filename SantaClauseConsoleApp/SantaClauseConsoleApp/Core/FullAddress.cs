using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClauseConsoleApp
{
    public class FullAddress
    {
        private string addressLine;
        private string city;
        private string country;

        public FullAddress(string addressLine, string city, string country)
        {
            this.addressLine = addressLine;
            this.city = city;
            this.country = country;
        }

        public string AddressLine
        {
            get { return addressLine; }
        }

        public string City
        {
            get { return city; }
        }

        public string Country
        {
            get { return country; }
        }

        public override string ToString()
        {
            return $"{addressLine}, {city}, {country}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eroxia.model
{
    internal class Client : Person
    {
        public string Address { get; set; }

        public Employee? Employee { get; set; }

        public Client(string address, string fiscalCode, string name, string surname) : base(fiscalCode, name, surname)
        {
            Address = address;
        }
    }




}

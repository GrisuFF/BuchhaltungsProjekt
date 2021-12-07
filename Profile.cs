using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BuchhaltungsProjekt
{
    [Serializable]
    class Profile
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; }

        public Profile(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
            Transactions = new List<Transaction>();
        }

        public static implicit operator Profile(FileStream v)
        {
            throw new NotImplementedException();
        }
    }
}

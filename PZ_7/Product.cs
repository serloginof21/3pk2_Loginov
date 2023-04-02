using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_7
{
    internal class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public virtual double GetDiscount(Client _client)
        {
            if (_client.AllPurchases > 750) 
                return 0.75;
            else if (_client.AllPurchases > 500) 
                return 0.5;
            else if (_client.AllPurchases > 250) 
                return 0.25;
            else 
                return 1;
        }
    }
}

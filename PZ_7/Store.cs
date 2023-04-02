using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_7
{
    internal class Store
    {
        public string AllPurshares { get; set; }
        public void SaveOrder(Client _client, Product[] _product)
        {
            AllPurshares += ('\n' + $"\n Клиент {_client.Name}" + "\n Покупка:");
            foreach (Product _p in _product)
            {
                AllPurshares += _p.Name + ' ';
                _client.AllPurchases += _p.Price * _p.GetDiscount(_client);
            }
        }
    }
}

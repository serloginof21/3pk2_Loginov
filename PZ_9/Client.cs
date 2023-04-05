using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_9
{
    internal class Client
    {
        private Origin _origin;

        public Client()
        {
            this._origin = new Origin();
        }

        public void ClientDb(double valueDouble)
        {
            this._origin.OriginDouble(valueDouble);
        }

        public void ClientInt(int valueInt)
        {
            this._origin.OriginInt(valueInt * 2);
        }

        public void ClientChr(char valueChar)
        {
            int i;

            for (i = 0; i < 5; i++)
            {
                Console.Write(valueChar);
            }
            Console.WriteLine();
        }
    }
}

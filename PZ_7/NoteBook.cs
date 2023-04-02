using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_7
{
    internal class NoteBook : Product
    {
        public string TypePaper { get; set; }
        public int NumOfPages { get; set; }
        public override double GetDiscount(Client _client) { return base.GetDiscount(_client); }
    }
}

using System;

namespace PZ_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store _store = new Store() { AllPurshares = "" };
            Client _client1 = new Client() { AllPurchases = 650, Name = "Twentyone Savage" };
            Client _client2 = new Client() { AllPurchases = 435, Name = "Metro Boomin" };
            Client _client3 = new Client() { AllPurchases = 170, Name = "Tay K" };

            Pencil _pencil = new Pencil() { Name = "MedPencil", Price = 35, Company = "Brauberg", EraserOnTheTop = true};
            Pen _pen = new Pen() { Name = "UltraPen", Price = 350, Ink = "Black", RodThickness = "thin" };
            NoteBook _notebook = new NoteBook() { Name = "DeathNote", Price = 600, TypePaper = "Strings", NumOfPages = 48};

            _store.SaveOrder(_client1, new Product[5] { _pencil, _pen, _notebook, _notebook, _pen });
            _store.SaveOrder(_client2, new Product[4] { _pen, _pencil, _pencil, _notebook });
            _store.SaveOrder(_client3, new Product[3] { _notebook, _pencil, _pencil });
            Console.WriteLine(_store.AllPurshares);
        }
    }
}
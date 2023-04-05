namespace PZ_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Origin origin = new Origin();

            origin.OriginDouble(5.25);
            origin.OriginInt(500);
            origin.OriginChar('L');

            Console.WriteLine("-------");

            Client client = new Client();
            client.ClientDb(5.25);
            client.ClientInt(500);
            client.ClientChr('L');
        }
    }
}
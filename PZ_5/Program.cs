using System;

namespace PZ_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MoreDetails music1 = new MoreDetails("Stop Breathing", "1");
            MusicArtist artist = new MusicArtist("Playboi Carti", 32212037, "Stop Breathing", 1, music1);
            Console.WriteLine(artist.ToString());

            Console.WriteLine();

            MoreDetails music2 = new MoreDetails("SickoMode", "3");
            MusicArtist artist2 = new MusicArtist("Travis Scott", 45039765, "Sicko Mode", 3, music2);
            Console.WriteLine(artist2.ToString());
            
            Console.WriteLine();

            MusicArtist artist3 = (MusicArtist)artist2.Clone();
            Console.WriteLine(artist3.ToString());
        }
    }
    internal class MoreDetails
    {
        public string Name { get; set; }
        public string PlaceInPlaylist { get; set; }
        public MoreDetails(string name, string place)
        {
            Name = name;
            PlaceInPlaylist = place;
        }
    }

    internal class MusicArtist : ICloneable 
    {
        private MoreDetails _dtM;
        public string Name { get; set; }
        public int NumberListeners { get; set; }
        public MusicArtist (string name, int listen, string songn, int place, MoreDetails md)
        {
            Name = name;
            NumberListeners = listen;
            NameSong = songn;
            PlacePlaylist = place;
            _dtM = md;
        }

        
        public override string ToString()
        {
            return $"Музыкальный исполнитель {Name} имеет в месяц " +
                $"{NumberListeners} слушателей, " +
                $"самая популярная песня {MoreDetails}";
        }

        private string nameS;
        private int placeS;
        public string NameSong { get { return nameS; } set { nameS = value; } }
        public int PlacePlaylist { get { return placeS; } set { placeS = value; } }
        public string MoreDetails { get { return _dtM.Name; } set { _dtM.Name = value; } }
        public object Clone() => new MusicArtist(Name, NumberListeners, NameSong, PlacePlaylist, 
            new MoreDetails(_dtM.Name, _dtM.PlaceInPlaylist));
    }
}
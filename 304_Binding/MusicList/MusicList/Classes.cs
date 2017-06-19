using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicList
{
    public class ViewModel
    {
        public List<PlayList> Lists { get; set; }
        public PlayList Selected { get; set; }

        private static ViewModel _peldany;
        private ViewModel()
        {
            Lists = new List<PlayList>();
            foreach (string file in System.IO.Directory.EnumerateFiles(".", "*.csv", System.IO.SearchOption.TopDirectoryOnly))
                Lists.Add(PlayList.Parse(file));
        }

        public static ViewModel Get()
        {
            if (_peldany == null)
                _peldany = new ViewModel();
            return _peldany;
        }
    }

    public class Song
    {
        public string Writer { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public bool Favorit { get; set; }
        public string Note { get; set; }

        public override string ToString()
        {
            return Writer + " - " + Name;
        }

        public static Song Parse(string line)
        {
            string[] t = line.Split(';');
            Song d = new Song();
            d.Writer = t[0];
            d.Name = t[1];
            d.Length = int.Parse(t[2]);
            d.Favorit = (t[3] == "1");
            d.Note = t[4];

            return d;
        }
    }

    public class PlayList
    {
        public string FileName { get; set; }
        public string Name { get; set; }
        public List<Song> SongList { get; set; }

        public override string ToString()
        {
            return FileName;
        }

        public static PlayList Parse(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path, Encoding.Default);
            PlayList ll = new PlayList();
            ll.Name = lines[0].Replace(";", "");
            ll.FileName = path.Substring(path.LastIndexOf('\\') + 1);
            ll.SongList = new List<Song>();
            for (int i = 1; i < lines.Length; i++)
                if (lines[i] != "")
                    ll.SongList.Add(Song.Parse(lines[i]));

            return ll;
        }
    }
}

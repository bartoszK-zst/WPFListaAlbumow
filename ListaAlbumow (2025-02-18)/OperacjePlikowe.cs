using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ListaAlbumow__2025_02_18_
{
    public static class OperacjePlikowe
    {
        public static ObservableCollection<AlbumMuzyczny> PobierzZPliku(string path)
        {
            var r = new ObservableCollection<AlbumMuzyczny>();
            StreamReader reader = File.OpenText(path);
            string lineOfData;
            List<string> linesOfData = new List<string>();
            while ((lineOfData = reader.ReadLine()) != null)
            {
                linesOfData.Add(lineOfData);


            }
            reader.Close();

            string[] serializedAlbumData = new string[6];
            int i = 0;
            foreach (string line in linesOfData)
            {
                serializedAlbumData[i] = line;
                if (i++ >= 5)
                {
                    i = 0;
                    r.Add(
                    new AlbumMuzyczny()
                        {
                            Artist = serializedAlbumData[0],
                            Album = serializedAlbumData[1],
                            SongsNumber = int.Parse(serializedAlbumData[2]),
                            YearOfEdition = int.Parse(serializedAlbumData[3]),
                            DownloadNumber = int.Parse(serializedAlbumData[4])
                        }
                    );
                }
            }
            return r;
        }

        public static void ZapiszDoPliku(string path, ObservableCollection<AlbumMuzyczny> list)
        {
            StreamWriter writer = new StreamWriter(path, false);

            foreach (AlbumMuzyczny album in list)
            {
                writer.WriteLine(album.Artist);
                writer.WriteLine(album.Album);
                writer.WriteLine(album.SongsNumber);
                writer.WriteLine(album.YearOfEdition);
                writer.WriteLine(album.DownloadNumber);
                writer.WriteLine();
            }

            writer.Close();
        }
    }
}

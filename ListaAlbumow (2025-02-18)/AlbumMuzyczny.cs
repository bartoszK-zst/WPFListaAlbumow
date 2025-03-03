using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaAlbumow__2025_02_18_
{
    public struct AlbumMuzyczny : INotifyPropertyChanged
    {
        private int downloadNumber;

        public string Artist { get; set; }
        public string Album { get; set; }
        public int SongsNumber { get; set; }
        public int YearOfEdition { get; set; }
        public int DownloadNumber {
            get { return this.downloadNumber; }
            set
            {
                if(this.downloadNumber != value)
                {
                    this.downloadNumber = value;
                    this.NotifyPropertyChanged(nameof(DownloadNumber));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if(this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

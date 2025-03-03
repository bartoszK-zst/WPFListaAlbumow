using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListaAlbumow__2025_02_18_
{
    public partial class MainWindow : Window
    {
        ObservableCollection<AlbumMuzyczny> listaAM;
        public MainWindow()
        {
            listaAM = OperacjePlikowe.PobierzZPliku(@"Data.txt");
            InitializeComponent();
            ListBoxLista.ItemsSource = listaAM;
            ListBoxLista.SelectedIndex = 0;
        }

        private void PobierzButton_Click(object sender, RoutedEventArgs e)
        {
            var selIndex = ListBoxLista.SelectedIndex;
            var updatedItem = listaAM[selIndex] with { DownloadNumber = listaAM[selIndex].DownloadNumber + 1 };
            listaAM[selIndex] = updatedItem;
            //'resetowanie' ListBox-a - bez tego liczba pobrań zmieniała się tylko po
            //drugim wciśnięciu w przycisk, albo wybraniu innego albumu i powróceniu do właściwego
            ListBoxLista.ItemsSource = null;
            ListBoxLista.ItemsSource = listaAM;
            ListBoxLista.SelectedIndex = selIndex;

            //Poniżej wywołanie metody zapisującej do pliku
            //umieszczone tu, żeby ułatwić testowanie
            //OperacjePlikowe.ZapiszDoPliku(@"test.txt", listaAM);
        }
    }
}
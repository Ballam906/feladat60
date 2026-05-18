using Microsoft.Win32;
using System.IO;
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


namespace SzigetWPF
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Eloado> eloadok=new List<Eloado>();
        List<Eloado> szurt=new List<Eloado>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Beolvas();
            dtgAdatok.ItemsSource= eloadok;
            pbHallgatottsag.Maximum = eloadok.Max(e => e.SpotifyHallgato);
            cmbMufaj.ItemsSource = eloadok.Select(e => e.Mufaj).Distinct();
        }

        public void Beolvas()
        {
            StreamReader sr = new StreamReader("sziget2025.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                eloadok.Add(new Eloado(sr.ReadLine()));
            }
            sr.Close();


        }

        private void dtgAdatok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pbHallgatottsag.Value= eloadok[dtgAdatok.SelectedIndex].SpotifyHallgato;
        }

        private void cmbMufaj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            szurt= eloadok.Where(e => e.Mufaj == cmbMufaj.SelectedValue.ToString()).ToList();
            dtgAdatok.ItemsSource = szurt;
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            if (dtgAdatok.SelectedIndex > -1)
            {
                try
                {
                    SaveFileDialog sd = new SaveFileDialog();
                    sd.FileName = $"{szurt[dtgAdatok.SelectedIndex].Nev}.txt";
                    if (sd.ShowDialog() == true)
                    {
                        StreamWriter sw = new StreamWriter(sd.FileName);

                        sw.WriteLine($"{szurt[dtgAdatok.SelectedIndex].Nev};{szurt[dtgAdatok.SelectedIndex].Orszag};{szurt[dtgAdatok.SelectedIndex].FellepesNapja}");

                        sw.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem");
            }
            
        }
    }
}
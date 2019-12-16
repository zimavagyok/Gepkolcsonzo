using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GepkolcsonzoService;
using GepkolcsonzoModel;
using GepkolcsonzoModel.Entity;

namespace Barkácsbolt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UgyfelService _ugyfelService = null;
        private readonly GepService _gepService = null;
        private readonly OsszekotesService _osszekotesService = null;
        public MainWindow()
        {
            _ugyfelService = new UgyfelService();
            _gepService = new GepService();
            _osszekotesService = new OsszekotesService();
            InitializeComponent();
        }

        private void UgyfelValasztoCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ResponseMessage<List<Ugyfel>> request_ugy = _ugyfelService.GetAll();

            if (request_ugy == null || !request_ugy.IsSuccess || request_ugy.ResponseObject == null)
            {
                MessageBox.Show(request_ugy.ErrorMessage);
            }

            ResponseMessage<List<Gep>> request_gep = _gepService.GetAll();

            if (request_gep == null || !request_gep.IsSuccess || request_gep.ResponseObject == null)
            {
                MessageBox.Show(request_gep.ErrorMessage);
            }

            foreach(var item in request_ugy.ResponseObject)
            {
                UgyfelCB.Items.Add(item.Id+" "+item.Nev);
            }

            foreach (var item in request_gep.ResponseObject)
            {
                KolcsonzottGepCB.Items.Add(item.Id+" "+item.Marka+" "+item.Modell);
            }

            kolcsonDP.DisplayDateStart = DateTime.Now;
        }
        public void Frissit(int id)
        {
            int request_menny = _gepService.Elerheto(id);

            /*if (request_menny == null || !request_menny.IsSuccess)
            {
                MessageBox.Show(request_menny.ErrorMessage);
            }*/
            if (request_menny == 0)
            {
                ElerhetoL.Content = "Nem elérhető!";
                KolcsonzottCB.IsEnabled = false;
            }
            else
            {
                KolcsonzottCB.IsEnabled = true;
                ElerhetoL.Content = request_menny;
                for (int i = 1; i <= request_menny; i++)
                {
                    KolcsonzottCB.Items.Add(i);
                }
            }
        }

        private void KolcsonzottGepCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frissit(int.Parse(KolcsonzottGepCB.SelectedItem.ToString().Split(' ')[0]));
            if (KolcsonzottGepCB.SelectedItem != null && kolcsonDP.SelectedDate != null && KolcsonzottCB.SelectedItem != null)
            {
                TeljesAr();
            }
        }

        private void Lekeres_Click(object sender, RoutedEventArgs e)
        {
            if(UgyfelCB.SelectedItem == null || KolcsonzottGepCB.SelectedItem == null || KolcsonzottCB.SelectedItem == null || _gepService.Elerheto(int.Parse(KolcsonzottGepCB.SelectedItem.ToString().Split(' ')[0]))==0 || kolcsonDP.SelectedDate == null)
            {
                MessageBox.Show("Kötelező minden elemet kiválasztani!");
                return;
            }

            Osszekotes temp = new Osszekotes();
            temp.UgyfelID = _ugyfelService.GetByID(int.Parse(UgyfelCB.SelectedItem.ToString().Split(' ')[0])).ResponseObject.Id;
            temp.GepID = _gepService.GetByID(int.Parse(KolcsonzottGepCB.SelectedItem.ToString().Split(' ')[0])).ResponseObject.Id;
            temp.Darab = int.Parse(KolcsonzottCB.SelectedItem.ToString());
            temp.Meddig = DateTime.Parse(kolcsonDP.SelectedDate.ToString());
            temp.TeljesAr = (int)((temp.Meddig-DateTime.Now).TotalDays* _gepService.GetByID(int.Parse(KolcsonzottGepCB.SelectedItem.ToString().Split(' ')[0])).ResponseObject.Ar)* int.Parse(KolcsonzottCB.SelectedItem.ToString());
            DateTime val = _osszekotesService.Create(temp).ResponseObject.Datum;
            if(val!=null)
            {
                Gep gep = new Gep(_gepService.GetByID(temp.GepID).ResponseObject);
                gep.Mennyiseg -= temp.Darab;
                _gepService.Update(gep);
                MessageBox.Show("Sikeres kölcsönzés!");
                Frissit(int.Parse(KolcsonzottGepCB.SelectedItem.ToString().Split(' ')[0]));
            }
            else
            {
                MessageBox.Show("Hiba a kölcsönzésben!");
            }
        }

        private void TeljesAr()
        {
            if(kolcsonDP.SelectedDate== null || KolcsonzottGepCB.SelectedItem==null)
            {
                return;
            }

            int teljesar = (int)((DateTime.Parse(kolcsonDP.SelectedDate.ToString())-DateTime.Now).TotalDays * _gepService.GetByID(int.Parse(KolcsonzottGepCB.SelectedItem.ToString().Split(' ')[0])).ResponseObject.Ar) * int.Parse(KolcsonzottCB.SelectedItem.ToString());
            teljesarL.Content = teljesar;
        }

        private void KolcsonzottCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(KolcsonzottGepCB.SelectedItem!=null && kolcsonDP.SelectedDate!=null && KolcsonzottCB.SelectedItem!=null)
            {
                TeljesAr();
            }
        }

        private void kolcsonDP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (KolcsonzottGepCB.SelectedItem != null && kolcsonDP.SelectedDate != null && KolcsonzottCB.SelectedItem != null)
            {
                TeljesAr();
            }
        }
    }
}

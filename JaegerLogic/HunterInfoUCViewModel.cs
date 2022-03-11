using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JaegerLogic
{
    public class HunterInfoUCViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly Service serv = new Service();
        public HunterInfoUCViewModel()
        {
            _ExperimentalHunter = serv.GetAllHunters();
        }

        private Jaeger _SelectedHunter;
        public Jaeger SelectedHunter
        {
            get { return _SelectedHunter; }
            set
            {
                if (value != null)
                {
                    _SelectedHunter = serv.GetSelectedHunterInfo(value.ID);
                    RaisePropertyChanged("SelectedHunter");
                }
                else
                {
                    _SelectedHunter.Adresszusatz = "Adresszusatz";
                    _SelectedHunter.Anrede = "Anrede";
                    _SelectedHunter.Vorname = "Vorname";
                    _SelectedHunter.Nachname = "Nachname";
                    _SelectedHunter.Funktion = "Funktion";
                    _SelectedHunter.Straße = "Straße HausNr Zusatz";
                    _SelectedHunter.Hausnummer = "HausNr";
                    _SelectedHunter.Ort = "Ort";
                    _SelectedHunter.PLZ = "12345";
                    _SelectedHunter.Telefonnummer1 = "0123456789";
                    _SelectedHunter.Email = "Email Adresse";
                    _SelectedHunter.Geburtsdatum = DateTime.Today;
                }
                ShowHunterInfo();
            }
        }

        private List<Jaeger> _ExperimentalHunter;

        public List<Jaeger> ExperimentalHunter
        {
            get { return _ExperimentalHunter; }
            set { _ExperimentalHunter = serv.GetAllHunters(); }
        }

        #region properties
        private string _FormOfAdress;
        public string FormOfAdress
        {
            get
            {
                return _FormOfAdress;
            }
            set
            {
                _FormOfAdress = value;
                RaisePropertyChanged("FormOfAdress");
            }
        }

        private string _Function;
        public string Function
        {
            get
            {
                return _Function;
            }
            set
            {
                _Function = value;
                RaisePropertyChanged("Function");
            }
        }

        private string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        private string _LastName;
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        private string _Adress;
        public string Adress
        {
            get
            {
                return _Adress;
            }
            set
            {
                _Adress = value;
                RaisePropertyChanged("Adress");
            }
        }

        private string _Place;
        public string Place
        {
            get
            {
                return _Place;
            }
            set
            {
                _Place = value;
                RaisePropertyChanged("Place");
            }
        }

        private string _Phone1;
        public string Phone1
        {
            get
            {
                return _Phone1;
            }
            set
            {
                _Phone1 = value;
                RaisePropertyChanged("Phone1");
            }
        }

        private string _Phone2;
        public string Phone2
        {
            get
            {
                return _Phone2;
            }
            set
            {
                _Phone2 = value;
                RaisePropertyChanged("Phone2");
            }
        }

        private string _Phone3;
        public string Phone3
        {
            get
            {
                return _Phone3;
            }
            set
            {
                _Phone3 = value;
                RaisePropertyChanged("Phone3");
            }
        }

        private string _Email;
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
                RaisePropertyChanged("Email");
            }
        }

        private string _Birthday;
        public string Birthday
        {
            get { return _Birthday; }
            set
            {
                _Birthday = value;
                RaisePropertyChanged("Birthday");
            }
        }

        #endregion

        private ICommand _AddHunter;
        public ICommand AddHunter
        {
            get
            {
                if (_AddHunter == null)
                {
                    _AddHunter = new RelayCommand(() =>
                    {
                        HunterAddEditUCViewModel hunterAdd = ServiceLocator.Current.GetInstance<HunterAddEditUCViewModel>();
                        hunterAdd.Edit = false;
                        hunterAdd.Hunter = new Jaeger();
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("HunterAddEditUC"));
                    });
                }
                return _AddHunter;
            }
        }
        private ICommand _EditHunter;
        public ICommand EditHunter
        {
            get
            {
                if (_EditHunter == null)
                {
                    _EditHunter = new RelayCommand(() =>
                    {
                        if (SelectedHunter != null)
                        {
                            HunterAddEditUCViewModel hunterEdit = ServiceLocator.Current.GetInstance<HunterAddEditUCViewModel>();
                            hunterEdit.Hunter = SelectedHunter;
                            hunterEdit.Edit = true;
                            Messenger.Default.Send(new MainContentChangeMessage("HunterAddEditUC"));
                        }
                    });
                }
                return _EditHunter;
            }
        }

        private ICommand _DelHunter;
        public ICommand DelHunter
        {
            get
            {
                if (_DelHunter == null)
                {
                    _DelHunter = new RelayCommand<int>((ID) =>
                    {

                        serv.DelHunter(ID);
                        ExperimentalHunter = serv.GetAllHunters();
                        SelectedHunter = ExperimentalHunter[0];
                        RaisePropertyChanged("ExperimentalHunter");
                    });
                }
                return _DelHunter;
            }
        }

        private void ShowHunterInfo()
        {

            FormOfAdress = SelectedHunter.Anrede;
            FirstName = SelectedHunter.Vorname;
            LastName = SelectedHunter.Nachname;
            Function = SelectedHunter.Funktion;
            Adress = SelectedHunter.Straße + " " + SelectedHunter.Hausnummer + " " + SelectedHunter.Adresszusatz;
            Place = SelectedHunter.PLZ + " " + SelectedHunter.Ort;
            Phone1 = SelectedHunter.Telefonnummer1;
            Phone2 = SelectedHunter.Telefonnummer2;
            Phone3 = SelectedHunter.Telefonnummer3;
            Email = SelectedHunter.Email;
            if (SelectedHunter.Geburtsdatum != null)
            {
                Birthday = SelectedHunter.Geburtsdatum.Value.ToString("dd/MM/yyyy");
            }
        }
    }
}

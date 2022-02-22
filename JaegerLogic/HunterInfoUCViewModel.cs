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
    public class HunterInfoUCViewModel:ViewModelBase,INotifyPropertyChanged
    {
        private Service serv = new Service();
        public HunterInfoUCViewModel()
        {
            _FormOfAdress = "Anrede";
            _FirstName = "Vorname";
            _LastName = "Nachname";
            _Function = "Funktion";
            _Adress = "Straße HausNr Zusatz";
            _Place = "PLZ Ort";
            _Phone1 = "TelefonNr1";
            _Phone2 = "TelefonNr2";
            _Phone3 = "TelefonNr3";
            _Email = "Email Adresse";

            
                    _Huntards = serv.GetAllHuntards();
              
            
        }
        private List<Jaeger> _Huntards;
        public List<Jaeger> Huntards
        {
            get { return _Huntards; }
            set
            {
                _Huntards = value;
                RaisePropertyChanged("Huntards");
            }
        }
        private Jaeger _SelectedHuntard;

        public Jaeger SelectedHuntard
        {
            get { return _SelectedHuntard; }
            set
            {
                _SelectedHuntard = value;
                RaisePropertyChanged("SelectedHuntard");
            }
        }

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

        private ICommand _AddHunter;
        public ICommand AddHunter
        {
            get
            {
                if (_AddHunter == null)
                {
                    _AddHunter = new RelayCommand(() =>
                    {
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
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("HunterAddEditUC"));
                    });
                }
                return _EditHunter;
            }
        }
    }
}

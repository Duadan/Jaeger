using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JaegerLogic
{
    public class HunterAddEditUCViewModel : ViewModelBase
    {
        public HunterAddEditUCViewModel()
        {
            Vorname = "genaU";
        }
        private List<string> _FormOfAdress;
        public List<string> FormOfAdress
        {
            get { return _FormOfAdress; }
            set { _FormOfAdress = value; }
        }

        private DateTime _Birthday;
        public DateTime Birthday
        {
            get { return _Birthday; }
            set { _Birthday = value; }
        }

        private List<string> _Task;
        public List<string> Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private string _Vorname;
        public string Vorname
        {
            get 
            { 
                return _Vorname; 
            }
            set
            {
                _Vorname = value;
                RaisePropertyChanged("Vorname");
            }
        }

        private string _Nachname;
        public string Nachname
        {
            get
            {
                return _Nachname;
            }
            set
            {
                _Nachname = value;
                RaisePropertyChanged("Nachname");
            }
        }

        private string _Straße;
        public string Straße
        {
            get
            {
                return _Straße;
            }
            set
            {
                _Straße= value;
                RaisePropertyChanged("Straße");
            }
        }

        private string _HausNr;
        public string HausNr
        {
            get
            {
                return _HausNr;
            }
            set
            {
                _HausNr = value;
                RaisePropertyChanged("HausNr");
            }
        }

        private string _Adresszusatz;
        public string Addresszusatz
        {
            get
            {
                return _Adresszusatz;
            }
            set
            {
                _Adresszusatz = value;
                RaisePropertyChanged("Adresszusatz");
            }
        }

        private string _PLZ;
        public string PLZ
        {
            get
            {
                return _PLZ;
            }
            set
            {
                _PLZ = value;
                RaisePropertyChanged("PLZ");
            }
        }

        private string _Ort;
        public string Ort
        {
            get
            {
                return _Ort;
            }
            set
            {
                _Ort = value;
                RaisePropertyChanged("Ort");
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

        private string _Phone1;
        public string Phone1
        {
            get { return _Phone1; }
            set { _Phone1 = value; }
        }

        private string _Phone2;
        public string Phone2
        {
            get { return _Phone2; }
            set { _Phone2 = value; }
        }

        private string _Phone3;
        public string Phone3
        {
            get { return _Phone3; }
            set { _Phone3 = value; }
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
                          Email = Vorname;
                      });
                }
                return _AddHunter;
            }
        }
        private ICommand _AddHunterCancel;
        public ICommand AddHunterCancel
        {
            get
            {
                if (_AddHunterCancel == null)
                {
                    _AddHunterCancel = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("HunterInfoUC"));
                    });
                }
                return _AddHunterCancel;
            }
        }
    }
}

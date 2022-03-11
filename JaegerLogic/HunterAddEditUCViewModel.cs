using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JaegerLogic
{
    public class HunterAddEditUCViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly Service serv = new Service();
        public bool Edit = false;
        public HunterAddEditUCViewModel()
        {
            Hunter = new Jaeger();
            //Testing = new List<Jaeger>();
            ColorFirstName = ColorAdrextra = ColorBirthday = ColorEmail = ColorFormOfAdress = ColorFunction = ColorHouseNumber = ColorLastName = ColorPhone1 = ColorPhone2 = ColorPhone3 = ColorPlace = ColorPostal = ColorStreet = "#FFABADB3";

        }

        #region all the properties
        private List<string> _FormOfAdress = new List<string> { "Herr", "Frau", "Divers", "Dr." };
        public List<string> FormOfAdress
        {
            get { return _FormOfAdress; }
            set
            {
                _FormOfAdress = value;

            }
        }

        private DateTime _Birthday = DateTime.Today;
        public DateTime Birthday
        {
            get { return _Birthday; }
            set { _Birthday = value; }
        }

        private string _ColorFirstName;
        public string ColorFirstName
        {
            get { return _ColorFirstName; }
            set
            {
                _ColorFirstName = value;
                RaisePropertyChanged("ColorFirstName");
            }
        }

        private string _ColorFormOfAdress;
        public string ColorFormOfAdress
        {
            get { return _ColorFormOfAdress; }
            set
            {
                _ColorFormOfAdress = value;
                RaisePropertyChanged("ColorFormOfAdress");
            }
        }

        private string _ColorLastName;
        public string ColorLastName
        {
            get { return _ColorLastName; }
            set
            {
                _ColorLastName = value;
                RaisePropertyChanged("ColorLastName");
            }
        }

        private string _ColorBirthday;
        public string ColorBirthday
        {
            get { return _ColorBirthday; }
            set
            {
                _ColorBirthday = value;
                RaisePropertyChanged("ColorBirthday");
            }
        }

        private string _ColorFunction;
        public string ColorFunction
        {
            get { return _ColorFunction; }
            set
            {
                _ColorFunction = value;
                RaisePropertyChanged("ColorFunction");
            }
        }

        private string _ColorStreet;
        public string ColorStreet
        {
            get { return _ColorStreet; }
            set
            {
                _ColorStreet = value;
                RaisePropertyChanged("ColorStreet");
            }
        }

        private string _ColorHouseNumber;
        public string ColorHouseNumber
        {
            get { return _ColorHouseNumber; }
            set
            {
                _ColorHouseNumber = value;
                RaisePropertyChanged("ColorHouseNumber");
            }
        }

        private string _ColorAdrextra;
        public string ColorAdrextra
        {
            get { return _ColorAdrextra; }
            set
            {
                _ColorAdrextra = value;
                RaisePropertyChanged("ColorAdrextra");
            }
        }

        private string _ColorPostal;
        public string ColorPostal
        {
            get { return _ColorPostal; }
            set
            {
                _ColorPostal = value;
                RaisePropertyChanged("ColorPostal");
            }
        }

        private string _ColorPlace;
        public string ColorPlace
        {
            get { return _ColorPlace; }
            set
            {
                _ColorPlace = value;
                RaisePropertyChanged("ColorPlace");
            }
        }

        private string _ColorPhone1;
        public string ColorPhone1
        {
            get { return _ColorPhone1; }
            set
            {
                _ColorPhone1 = value;
                RaisePropertyChanged("ColorPhone1");
            }
        }

        private string _ColorPhone2;
        public string ColorPhone2
        {
            get { return _ColorPhone2; }
            set
            {
                _ColorPhone2 = value;
                RaisePropertyChanged("ColorPhone2");
            }
        }

        private string _ColorPhone3;
        public string ColorPhone3
        {
            get { return _ColorPhone3; }
            set
            {
                _ColorPhone3 = value;
                RaisePropertyChanged("ColorPhone3");
            }
        }

        private string _ColorEMail;
        public string ColorEmail
        {
            get { return _ColorEMail; }
            set
            {
                _ColorEMail = value;
                RaisePropertyChanged("ColorEmail");
            }
        }

        private List<string> _Task = new List<string> { "kein Ahnung", "Tut etwas", "Förster" };
        public List<string> Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Jaeger _Hunter;
        public Jaeger Hunter
        {
            get { return _Hunter; }
            set
            {
                _Hunter = value;
            }
        }

        //private List<Jaeger> _Testing;
        //public List<Jaeger> Testing
        //{
        //    get { return _Testing; }
        //    set
        //    {
        //        _Testing = value;
        //        RaisePropertyChanged("Testing");
        //    }
        //}

        #endregion

        private ICommand _ConfirmHunter;
        public ICommand ConfirmHunter
        {
            get
            {
                if (_ConfirmHunter == null)
                {
                    _ConfirmHunter = new RelayCommand(() =>
                    {
                        Hunter.Geburtsdatum = Birthday;
                        if (Hunter.IsValid())
                        {
                            if (!Edit)
                            {
                                serv.InsertHunter(Hunter);
                                //Testing.Add(Hunter);
                                //Testing = Testing;
                                Hunter = new Jaeger();
                            }

                            if (Edit)
                            {
                                serv.UpdateHunter(Hunter);
                                Hunter = new Jaeger();
                            }
                            HunterInfoUCViewModel send = ServiceLocator.Current.GetInstance<HunterInfoUCViewModel>();
                            send.ExperimentalHunter = serv.GetAllHunters();
                            { Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("HunterInfoUC")); }
                        }
                        else //Ränder färben
                        {
                            ColorFormOfAdress = Validate(Hunter.Anrede);
                            ColorLastName = Validate(Hunter.Nachname);
                            ColorFunction = Validate(Hunter.Funktion);
                            ColorPlace = Validate(Hunter.Ort);
                            ColorStreet = Validate(Hunter.Straße);
                            ColorFirstName = Validate(Hunter.Vorname);

                            if (!string.IsNullOrEmpty(Hunter.Telefonnummer1))
                            {
                                if (!Regex.IsMatch(Hunter.Telefonnummer1, "([0-9 +-])"))
                                {
                                    ColorPhone1 = "Red";
                                }
                                else
                                {
                                    ColorPhone1 = "#FFABADB3";
                                }
                            }
                            else
                            {
                                ColorPhone1 = "Red";
                            }
                            if (string.IsNullOrEmpty(Hunter.PLZ))
                            {
                                ColorPostal = "Red";
                            }
                            else
                            {
                                if (!Regex.IsMatch(Hunter.PLZ, "([0-9]{5})") || Hunter.PLZ.Length != 5)//doesn't work at all?!
                                {
                                    ColorPostal = "Red";
                                }
                                else
                                {
                                    ColorPostal = "#FFABADB3";
                                }
                            }

                            if (!string.IsNullOrEmpty(Hunter.Email))
                            {
                                if (Regex.IsMatch(Hunter.Email, "([A-z]+@[A-z]+.[A-z]{2,4})"))
                                {
                                    ColorEmail = "#FFABADB3";
                                }
                                else
                                {
                                    ColorEmail = "Red";
                                }
                            }
                            else
                            {
                                ColorEmail = "#FFABADB3";
                            }
                            if (!string.IsNullOrEmpty(Hunter.Telefonnummer2))
                            {
                                if (!Regex.IsMatch(Hunter.Telefonnummer2, "([0-9 +-])"))
                                {
                                    ColorPhone2 = "Red";
                                }
                                else
                                {
                                    ColorPhone2 = "#FFABADB3";
                                }
                            }
                            else
                            {
                                ColorPhone2 = "#FFABADB3";
                            }
                            if (!string.IsNullOrEmpty(Hunter.Telefonnummer3))
                            {
                                if (!Regex.IsMatch(Hunter.Telefonnummer3, "([0-9 +-])"))
                                {
                                    ColorPhone3 = "Red";
                                }
                                else
                                {
                                    ColorPhone3 = "#FFABADB3";
                                }
                            }
                            else
                            {
                                ColorPhone3 = "#FFABADB3";
                            }
                            if (!string.IsNullOrEmpty(Hunter.Hausnummer))
                            {
                                if (!Regex.IsMatch(Hunter.Hausnummer, "([0-9 +-])"))
                                {
                                    ColorHouseNumber = "Red";
                                }
                                else
                                {
                                    ColorHouseNumber = "#FFABADB3";
                                }
                            }
                            else
                            {
                                ColorHouseNumber = "Red";
                            }
                        }
                    });
                }
                return _ConfirmHunter;
            }
        }
        public string Validate(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "Red";
            }
            else
            {
                return "#FFABADB3";
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

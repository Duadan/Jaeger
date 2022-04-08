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
    public class AccidentAddUCViewModel:ViewModelBase
    {
        private ServiceAddGame serv = new ServiceAddGame();
        public AccidentAddUCViewModel()
        {
            AnimalList = serv.GetAllAnimalsShown();
            Accident = new Termine();
            Accident.DatumUhrzeit = DateTime.Today;
            AccidentList = serv.GetAccidents();
        }
        private ICommand _AccidentAddConfirm;
        public ICommand AccidentAddConfirm
        {
            get
            {
                if (_AccidentAddConfirm == null)
                {
                    _AccidentAddConfirm = new RelayCommand(() =>
                    {
                        Accident.DatumUhrzeit = Accident.DatumUhrzeit.AddHours(ChosenHour).AddMinutes(ChosenMinute);
                        if (string.IsNullOrEmpty(Accident.Bezeichnung))//Fragen ob mehr Zeichen gewünscht
                        {
                            Accident.Bezeichnung = "Unfall";
                        }
                        Accident.Typ = "Unfall";

                        if (Accident.IsValid())
                        {
                            serv.InsertAccident(Accident,AnimalList);
                            Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AddSuccessShow"));
                        }
                        else
                        {
                            Messenger.Default.Send(new MainContentChangeMessage("FailedInputShow"));
                        }
                        

                    });
                }
                return _AccidentAddConfirm;
            }
        }

        private ICommand _AccidentAddCancel;
        public ICommand AccidentAddCancel
        {
            get
            {
                if (_AccidentAddCancel == null)
                {
                    _AccidentAddCancel = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AccidentInfoUC"));
                    });
                }
                return _AccidentAddCancel;
            }
        }

        private ICommand _AccidentDelete;//noch unfertig
        public ICommand AccidentDelete
        {
            get
            {
                if (_AccidentDelete == null)
                {
                    _AccidentDelete = new RelayCommand(() =>
                    {
                    });
                }
                return _AccidentDelete;
            }
        }
        //add two way

        #region properties

        private int[] _Hrs= {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23 } ;//nur Std evtl. als INT
        public int[] Hrs
        {
            get { return _Hrs; }
            set { _Hrs = value; }
        }

        private int[] _Minutes={ 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55 };//nur Minuten evtl als INT
        public int[] Minutes
        {
            get { return _Minutes; }
            set { _Minutes = value; }
        }
        private int _ChosenHour;
        public int ChosenHour
        {
            get { return _ChosenHour; }
            set { _ChosenHour = value; }
        }

        private int _ChosenMinute;

        public int ChosenMinute
        {
            get { return _ChosenMinute; }
            set { _ChosenMinute = value; }
        }


        private List<Termine> _AccidentList ;//Datenbank hier anfügen
        public List<Termine> AccidentList
        {
            get { return _AccidentList; }
            set { _AccidentList = value; }
        }

        private List<AnimalShown> _AnimalList;
        public List<AnimalShown> AnimalList
        {
            get { return _AnimalList; }
            set { _AnimalList = value; }
        }

        private Termine _Accident;
        public Termine Accident
        {
            get { return _Accident; }
            set 
            { 
                _Accident = value;
                RaisePropertyChanged("Accident");
            }
        }

        #endregion

    }
}

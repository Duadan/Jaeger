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
    public class AppointmentInfoUCViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly ServiceAppointments serv = new ServiceAppointments();
        //private readonly Service servHunter = new Service();
        //public AppointmentsUCViewModel AppointmentsUC = ServiceLocator.Current.GetInstance<AppointmentsUCViewModel>();
        public AppointmentInfoUCViewModel()
        {
            //AppointmentsUC = ServiceLocator.Current.GetInstance<AppointmentsUCViewModel>();
            IsSelected = false;
        }

        #region properties

        private int _SelectedID;
        public int SelectedID
        {
            get { return _SelectedID; }
            set
            {
                _SelectedID = value;
                AppointmentChosen = serv.SelectedAppointment(SelectedID);
                if (IsSelected)
                {
                    ListHunter = serv.GetInvitedHunter(SelectedID);
                }
                RaisePropertyChanged("SelectedID");
            }
        }

        private Termine _AppointmentChosen;
        public Termine AppointmentChosen
        {
            get { return _AppointmentChosen; }
            set
            {
                _AppointmentChosen = serv.SelectedAppointment(SelectedID);
                if (_AppointmentChosen.Typ == "Andere")
                {
                    Type = false;
                }
                else
                {
                    Type = true;
                }
                RaisePropertyChanged("Type");
                RaisePropertyChanged("AppointmentChosen");
            }
        }

        private bool _Type;
        public bool Type
        {
            get { return _Type; }
            set { _Type = value; }
        }


        private bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set { _IsSelected = value; }
        }

        private int _CountGuests;
        public int CountGuests
        {
            get { return _CountGuests; }
            set
            {
                _CountGuests = value;
                RaisePropertyChanged("CountGuests");
            }
        }

        private int _CountHunter;
        public int CountHunter
        {
            get { return _CountHunter; }
            set
            {
                _CountHunter = value;
                RaisePropertyChanged("CountHunter");
            }
        }

        private int _CountBeater;
        public int CountBeater
        {
            get { return _CountBeater; }
            set
            {
                _CountBeater = value;
                RaisePropertyChanged("CountBeater");
            }
        }

        private List<HunterInvited> _ListHunter;
        public List<HunterInvited> ListHunter //neue Klasse Jäger+, füge Rolle hinzu
        {
            get { return _ListHunter; }
            set
            {
                _ListHunter = value;
                RaisePropertyChanged("ListHunter");
            }
        }

        private HunterInvited _SelectedHunter;
        public HunterInvited SelectedHunter
        {
            get { return _SelectedHunter; }
            set
            {
                _SelectedHunter = value;
                if (value != null)
                {
                    ListGame = serv.GetBigGame(SelectedID, SelectedHunter.ID);
                    RaisePropertyChanged("ListGame");
                }
                RaisePropertyChanged("SelectedHunter");
            }
        }

        private List<Game> _ListGame;
        public List<Game> ListGame
        {
            get { return _ListGame; }
            set
            {
                _ListGame = value;
                RaisePropertyChanged("ListGame");
            }
        }

        #endregion

        private ICommand _AppointmentInfoEdit;
        public ICommand AppointmentInfoEdit
        {
            get
            {
                if (_AppointmentInfoEdit == null)
                {
                    _AppointmentInfoEdit = new RelayCommand(() =>
                    {
                        AppointmentAddEditUCViewModel edit = ServiceLocator.Current.GetInstance<AppointmentAddEditUCViewModel>();
                        //edit.ChosenHour = AppointmentChosen.DatumUhrzeit.Hour;
                        //edit.ChosenMinute = AppointmentChosen.DatumUhrzeit.Minute;
                        edit.Appointment = AppointmentChosen;
                        edit.ChosenHour = AppointmentChosen.DatumUhrzeit.Hour;
                        edit.ChosenMinute = AppointmentChosen.DatumUhrzeit.Minute;
                        edit.IsEdit = true;
                        if (AppointmentChosen.Typ == "Jagd")
                        {
                            edit.AppointmentIsHunt = true;
                        }
                        foreach (TerminJaeger l in edit.HunterList)
                        {
                            l.Eingeladen = false;
                            l.Rolle = null;
                            l.Gaeste = 0;
                        }
                        foreach (HunterInvited i in ListHunter)
                        {
                            foreach (TerminJaeger l in edit.HunterList)
                            {
                                if (i.ID == l.ID)
                                {
                                    l.Eingeladen = true;
                                    l.Rolle = i.Rolle;
                                    l.Gaeste = i.Gäste;
                                }
                            }
                        }
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentAddEditUC"));
                    });
                }
                return _AppointmentInfoEdit;
            }
        }
        private ICommand _AppointmentInfoAddGame;
        public ICommand AppointmentInfoAddGame
        {
            get
            {
                if (_AppointmentInfoAddGame == null)
                {
                    _AppointmentInfoAddGame = new RelayCommand(() =>
                    {
                        //AppointmentAddEditUCViewModel edit = ServiceLocator.Current.GetInstance<AppointmentAddEditUCViewModel>();
                        //edit.IsEdit = true;
                        //Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentAddGameUC"));
                    });
                }
                return _AppointmentInfoAddGame;
            }
        }


    }
}

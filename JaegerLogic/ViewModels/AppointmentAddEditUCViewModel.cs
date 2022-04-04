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
    public class AppointmentAddEditUCViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly ServiceAppointments serv = new ServiceAppointments();
        //private readonly Service servH = new Service();
        public AppointmentAddEditUCViewModel()
        {
            HunterList = serv.GetAllAppointmentHunters();
            Role = new List<string> { "Jäger", "Treiber" };
            Appointment = new Termine
            {
                DatumUhrzeit = DateTime.Today
            };
            ColorHrs = ColorMin = ColorName = ColorPlace = "#FFABADB3";
        }

        #region Properties

        private bool _IsEdit;

        public bool IsEdit
        {
            get { return _IsEdit; }
            set { _IsEdit = value; }
        }
        private string _ColorName;
        public string ColorName
        {
            get { return _ColorName; }
            set
            {
                _ColorName = value;
                RaisePropertyChanged("ColorName");
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

        private string _ColorHrs;
        public string ColorHrs
        {
            get { return _ColorHrs; }
            set
            {
                _ColorHrs = value;
                RaisePropertyChanged("ColorHrs");
            }
        }

        private string _ColorMin;
        public string ColorMin
        {
            get { return _ColorMin; }
            set
            {
                _ColorMin = value;
                RaisePropertyChanged("ColorMin");
            }
        }

        private List<string> _Role;
        public List<string> Role
        {
            get { return _Role; }
            set
            {
                _Role = value;
                RaisePropertyChanged("Role");
            }
        }

        private Termine _Appointment;
        public Termine Appointment
        {
            get { return _Appointment; }
            set
            {
                _Appointment = value;
                RaisePropertyChanged("Appointment");
            }
        }

        private int[] _Hrs = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };
        public int[] Hrs
        {
            get { return _Hrs; }
            set { _Hrs = value; }
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

        private int[] _Minutes = { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55 };
        public int[] Minutes
        {
            get { return _Minutes; }
            set { _Minutes = value; }
        }

        private bool _AppointmentIsHunt;
        public bool AppointmentIsHunt
        {
            get { return _AppointmentIsHunt; }
            set { _AppointmentIsHunt = value; }
        }
        public bool AppointmentIsOther
        {
            get { return !_AppointmentIsHunt; }
            set { _AppointmentIsHunt = !value; }
        }

        private List<TerminJaeger> _HunterList;
        public List<TerminJaeger> HunterList
        {
            get { return _HunterList; }
            set { _HunterList = value; }
        }

        private TerminJaeger _SelectedHunter;
        public TerminJaeger SelectedHunter
        {
            get { return _SelectedHunter; }
            set { _SelectedHunter = value; }
        }

        #endregion

        private ICommand _AppointmentAddEditConfirm;
        public ICommand AppointmentAddEditConfirm
        {
            get
            {
                if (_AppointmentAddEditConfirm == null)
                {
                    _AppointmentAddEditConfirm = new RelayCommand(() =>
                    {
                        Appointment.DatumUhrzeit = Appointment.DatumUhrzeit.AddHours(ChosenHour).AddMinutes(ChosenMinute);
                        if (AppointmentIsHunt)
                        {
                            Appointment.Typ = "Jagd";
                        }
                        else
                        {
                            Appointment.Typ = "Andere";
                        }
                        if (Appointment.IsValid())
                        {
                            if (!IsEdit)
                            {
                                serv.InsertAppointment(Appointment,HunterList);
                                Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentAddEditConfirm"));
                                //serv.SaveAnswers(HunterList,Appointment.ID);
                            }
                            else if (IsEdit)
                            {
                                serv.UpdateAppointment(Appointment,HunterList);
                                Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentAddEditConfirm"));
                            }
                            AppointmentsUCViewModel pfft = ServiceLocator.Current.GetInstance<AppointmentsUCViewModel>();
                            pfft.Appointments = serv.GetAllAppointments();
                        }
                        HunterAddEditUCViewModel check = new HunterAddEditUCViewModel();
                        ColorName = check.Validate(Appointment.Bezeichnung);
                        ColorPlace = check.Validate(Appointment.Ort);
                    });
                }
                return _AppointmentAddEditConfirm;
            }
        }

        private ICommand _AppointmentAddEditCancel;
        public ICommand AppointmentAddEditCancel
        {
            get
            {
                if (_AppointmentAddEditCancel == null)
                {
                    _AppointmentAddEditCancel = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentCalendarUC"));
                    });
                }
                return _AppointmentAddEditCancel;
            }
        }
    }
}

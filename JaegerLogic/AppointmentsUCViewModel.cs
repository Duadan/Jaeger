using CommonServiceLocator;
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
    public class AppointmentsUCViewModel : ViewModelBase
    {
        private readonly ServiceAppointments serv = new ServiceAppointments();
        public AppointmentsUCViewModel()
        {
            _Appointments = serv.GetAllAppointments();
        }

        #region Buttons

        private ICommand _AppointmentInfoUC;
        public ICommand AppointmentInfoUC
        {
            get
            {
                if (_AppointmentInfoUC == null)
                {
                    _AppointmentInfoUC = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentInfoUC"));
                    });
                }
                return _AppointmentInfoUC;
            }
        }
        private ICommand _AppointmentAddEditUC;
        public ICommand AppointmentAddEditUC
        {
            get
            {
                if (_AppointmentAddEditUC == null)
                {
                    _AppointmentAddEditUC = new RelayCommand(() =>
                    {
                        AppointmentAddEditUCViewModel edit = ServiceLocator.Current.GetInstance<AppointmentAddEditUCViewModel>();
                        edit.IsEdit = false;
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentAddEditUC"));
                    });
                }
                return _AppointmentAddEditUC;
            }
        }
        private ICommand _AppointmentCertificateUC;
        public ICommand AppointmentCertificateUC
        {
            get
            {
                if (_AppointmentCertificateUC == null)
                {
                    _AppointmentCertificateUC = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentCertificateUC"));
                    });
                }
                return _AppointmentCertificateUC;
            }
        }
        private ICommand _AppointmentAddGameUC;
        public ICommand AppointmentAddGameUC
        {
            get
            {
                if (_AppointmentAddGameUC == null)
                {
                    _AppointmentAddGameUC = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentAddGameUC"));
                    });
                }
                return _AppointmentAddGameUC;
            }
        }
        private ICommand _AppointmentShowAll;
        public ICommand AppointmentShowAll
        {
            get
            {
                if (_AppointmentShowAll == null)
                {
                    _AppointmentShowAll = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentShowAll"));
                    });
                }
                return _AppointmentShowAll;
            }
        }
        private ICommand _AppointmentShowHunt;
        public ICommand AppointmentShowHunt
        {
            get
            {
                if (_AppointmentShowHunt == null)
                {
                    _AppointmentShowHunt = new RelayCommand(() =>
                    {
                        //Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentShowHunt"));
                    });
                }
                return _AppointmentShowHunt;
            }
        }
        private ICommand _AppointmentShowOther;
        public ICommand AppointmentShowOther
        {
            get
            {
                if (_AppointmentShowOther == null)
                {
                    _AppointmentShowOther = new RelayCommand(() =>
                    {
                        //Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentShowOther"));
                    });
                }
                return _AppointmentShowOther;
            }
        }

        #endregion

        private List<Termine> _Appointments;
        public List<Termine> Appointments
        {
            get { return _Appointments; }
            set { _Appointments = value; }
        }

        private Termine _SelectedAppointment;
        public Termine SelectedAppointment
        {
            get { return _SelectedAppointment; }
            set
            {
                _SelectedAppointment = value;
                RaisePropertyChanged("SelectedAppointment");
                AppointmentInfoUCViewModel bla = ServiceLocator.Current.GetInstance<AppointmentInfoUCViewModel>();
                bla.SelectedID = value.ID;
                bla.IsSelected = true;
            }
        }
    }
}

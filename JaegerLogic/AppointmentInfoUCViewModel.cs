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
    public class AppointmentInfoUCViewModel : ViewModelBase
    {
        private readonly ServiceAppointments serv = new ServiceAppointments();
        private readonly Service servHunter = new Service();
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
                _AppointmentChosen = serv.SelectedAppointment(SelectedID);
                if (IsSelected)
                {
                    _ListHunter = servHunter.GetSelectedHunter(SelectedID);
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
                //_AppointmentChosen = serv.SelectedAppointment(SelectedID);
                RaisePropertyChanged("AppointmentChosen");
            }
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
            set { _CountGuests = value; }
        }

        private int _CountHunter;
        public int CountHunter
        {
            get { return _CountHunter; }
            set { _CountHunter = value; }
        }

        private int _CountBeater;
        public int CountBeater
        {
            get { return _CountBeater; }
            set { _CountBeater = value; }
        }

        private List<Jaeger> _ListHunter;
        public List<Jaeger> ListHunter
        {
            get { return _ListHunter; }
            set
            {
                _ListHunter = value;
                RaisePropertyChanged("ListHunter");
            }
        }

        private Jaeger _SelectedHunter;

        public Jaeger SelectedHunter
        {
            get { return _SelectedHunter; }
            set
            {
                _SelectedHunter = value;
                RaisePropertyChanged("SelectedHunter");
            }
        }


        private List<Game> _ListGame;
        public List<Game> ListGame
        {
            get { return _ListGame; }
            set { _ListGame = value; }
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
                        AppointmentAddEditUCViewModel edit = ServiceLocator.Current.GetInstance<AppointmentAddEditUCViewModel>();
                        edit.IsEdit = true;
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentAddGameUC"));
                    });
                }
                return _AppointmentInfoAddGame;
            }
        }
    }
}

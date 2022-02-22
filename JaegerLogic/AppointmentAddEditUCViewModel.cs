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
    public class AppointmentAddEditUCViewModel:ViewModelBase
    {
        public AppointmentAddEditUCViewModel()
        {

        }
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Place;
        public string Place
        {
            get { return _Place; }
            set { _Place = value; }
        }

        private DateTime _Date;

        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        private DateTime _Hrs;
        public DateTime Hrs
        {
            get { return _Hrs; }
            set { _Hrs = value; }
        }

        private DateTime _Minutes;
        public DateTime Minutes
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
        private List<string> _AppointmentHunter;
        public List<string> AppointmentHunter
        {
            get { return _AppointmentHunter; }
            set { _AppointmentHunter = value; }
        }

        private ICommand _AppointmentAddEditConfirm;
        public ICommand AppointmentAddEditConfirm
        {
            get
            {
                if (_AppointmentAddEditConfirm == null)
                {
                    _AppointmentAddEditConfirm = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentAddEditConfirm"));
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

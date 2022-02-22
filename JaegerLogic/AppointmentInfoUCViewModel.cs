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
    public class AppointmentInfoUCViewModel:ViewModelBase
    {
        public AppointmentInfoUCViewModel()
        {
            _Name = "Bezeichnung";
            _Place = "Ort";
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

        private List<string> _ListHunter;
        public List<string> ListHunter
        {
            get { return _ListHunter; }
            set { _ListHunter = value; }
        }

        private List<string> _ListGame;
        public List<string> ListGame
        {
            get { return _ListGame; }
            set { _ListGame = value; }
        }

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
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentAddGameUC"));
                    });
                }
                return _AppointmentInfoAddGame;
            }
        }
    }
}

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
    public class AppointmentAddGameUCViewModel:ViewModelBase,INotifyPropertyChanged
    {
        private readonly ServiceAddGame serv = new ServiceAddGame();
        private readonly ServiceAnimal servA = new ServiceAnimal();
        public AppointmentAddGameUCViewModel()
        {
            AppointmentAddGameListHunter = serv.GetTheHunters(SelectedID);
            AppointmentAddGameListAnimal = serv.GetAllAnimalsShown();
        }

        #region Properties
        private List<Jaeger> _AppointmentAddGameListHunter;
        public List<Jaeger> AppointmentAddGameListHunter
        {
            get { return _AppointmentAddGameListHunter; }
            set 
            { 
                _AppointmentAddGameListHunter = value;
            }
        }

        private Jaeger _SelectedHunter;

        public Jaeger SelectedHunter
        {
            get { return _SelectedHunter; }
            set 
            { 
                _SelectedHunter = value;
                AppointmentAddGameListAnimal = serv.GetAllAnimalsShown();
            }
        }


        private int _SelectedID;
        public int SelectedID
        {
            get { return _SelectedID; }
            set
            {
                _SelectedID = value;
                AppointmentAddGameListAnimal = serv.GetAllAnimalsShown();
                AppointmentAddGameListHunter=serv.GetTheHunters(value);
                RaisePropertyChanged("SelectedID");
            }
        }


        private List<AnimalShown> _AppointmentAddGameListAnimal;
        public List<AnimalShown> AppointmentAddGameListAnimal
        {
            get { return _AppointmentAddGameListAnimal; }
            set 
            { 
                _AppointmentAddGameListAnimal = value; 
            }
        }


        private AnimalShown _SelectedAnimal;
        public AnimalShown SelectedAnimal
        {
            get { return _SelectedAnimal; }
            set
            {
                _SelectedAnimal = value;
                RaisePropertyChanged("SelectedAnimal");
            }
        }

        private List<string> _ListGame;
        public List<string> ListGame
        {
            get { return _ListGame; }
            set { _ListGame = value; }
        }
        #endregion

        private ICommand _AddGameConfirm;
        public ICommand AddGameConfirm
        {
            get
            {
                if (_AddGameConfirm == null)
                {
                    _AddGameConfirm = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentAddGameConfirm"));
                    });
                }
                return _AddGameConfirm;
            }
        }
        private ICommand _AddGameCancel;
        public ICommand AddGameCancel
        {
            get
            {
                if (_AddGameCancel == null)
                {
                    _AddGameCancel = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentCalendarUC"));
                    });
                }
                return _AddGameCancel;
            }
        }
    }
}

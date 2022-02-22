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
    public class AppointmentAddGameUCViewModel:ViewModelBase
    {
        public AppointmentAddGameUCViewModel()
        {

        }
        private List<string> _AppointmentAddGameListHunter;
        public List<string> AppointmentAddGameListHunter
        {
            get { return _AppointmentAddGameListHunter; }
            set { _AppointmentAddGameListHunter = value; }
        }

        private List<string> _AppointmentAddGameListAnimal;
        public List<string> AppointmentAddGameListAnimal
        {
            get { return _AppointmentAddGameListAnimal; }
            set { _AppointmentAddGameListAnimal = value; }
        }

        private List<string> _ListGame;

        public List<string> ListGame
        {
            get { return _ListGame; }
            set { _ListGame = value; }
        }
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

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
    public class AccidentInfoUCViewModel:ViewModelBase,INotifyPropertyChanged
    {
        private ServiceAddGame serv = new ServiceAddGame();
        public AccidentInfoUCViewModel()
        {
            AccidentInfoList = serv.GetAccidents();
            Animals = serv.GetAllAccidents();
        }

        private Termine _SelectedAccident;
        public Termine SelectedAccident
        {
            get { return _SelectedAccident; }
            set 
            { 
                _SelectedAccident = value;
                RaisePropertyChanged("Animals");
                RaisePropertyChanged("SelectedAccident");
            }
        }

        private ICommand _AccidentInfoAdd;
        public ICommand AccidentInfoAdd
        {
            get
            {
                if (_AccidentInfoAdd == null)
                {
                    _AccidentInfoAdd = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AccidentAddUC"));
                    });
                }
                return _AccidentInfoAdd;
            }
        }

        private List<AnimalShown> _Animals;
        public List<AnimalShown> Animals
        {
            get { return _Animals; }
            set { _Animals = value; }
        }


        private List<Termine> _AccidentInfoList;//DB anbinden
        public List<Termine> AccidentInfoList
        {
            get { return _AccidentInfoList; }
            set { _AccidentInfoList = value; }
        }

    }
}

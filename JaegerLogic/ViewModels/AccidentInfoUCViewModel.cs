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
        public AccidentInfoUCViewModel()
        {

        }

        private string _Place;
        public string Place
        {
            get { return _Place; }
            set { _Place = value; }
        }

        private string _Date;
        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        private string _Animal;
        public string Animal
        {
            get { return _Animal; }
            set { _Animal = value; }
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

        private List<string> _AccidentInfoList;//DB anbinden
        public List<string> AccidentInfoList
        {
            get { return _AccidentInfoList; }
            set { _AccidentInfoList = value; }
        }

    }
}

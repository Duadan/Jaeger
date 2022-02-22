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
    public class AccidentAddUCViewModel:ViewModelBase
    {
        public AccidentAddUCViewModel()
        {

        }
        private ICommand _AccidentAddConfirm;
        public ICommand AccidentAddConfirm
        {
            get
            {
                if (_AccidentAddConfirm == null)
                {
                    _AccidentAddConfirm = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AccidentAddConfirm"));
                    });
                }
                return _AccidentAddConfirm;
            }
        }
        private ICommand _AccidentAddCancel;
        public ICommand AccidentAddCancel
        {
            get
            {
                if (_AccidentAddCancel == null)
                {
                    _AccidentAddCancel = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AccidentInfoUC"));
                    });
                }
                return _AccidentAddCancel;
            }
        }
        //add two way
        private DateTime _Date;
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        private DateTime _Hrs;//nur Std evtl. als INT
        public DateTime Hrs
        {
            get { return _Hrs; }
            set { _Hrs = value; }
        }
        private DateTime _Minutes;//nur Minuten evtl als INT
        public DateTime Minutes
        {
            get { return _Minutes; }
            set { _Minutes = value; }
        }
        private string _Place;
        public string Place
        {
            get { return _Place; }
            set { _Place = value; }
        }
        private List<string> _AccidentList ;//Datenbank hier anfügen
        public List<string> AccidentList
        {
            get { return _AccidentList; }
            set { _AccidentList = value; }
        }

    }
}

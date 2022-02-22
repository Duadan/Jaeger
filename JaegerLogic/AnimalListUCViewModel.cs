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
    public class AnimalListUCViewModel:ViewModelBase
    {
        public AnimalListUCViewModel()
        {

        }

        private List<string> _AnimalList;
        public List<string> AnimalList
        {
            get { return _AnimalList; }
            set { _AnimalList = value; }
        }

        private string _AnimalName;
        public string AnimalName
        {
            get { return _AnimalName; }
            set { _AnimalName = value; }
        }

        private ICommand _AnimalListAdd;
        public ICommand AnimalListAdd
        {
            get
            {
                if (_AnimalListAdd == null)
                {
                    _AnimalListAdd = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AnimalListAdd"));
                    });
                }
                return _AnimalListAdd;
            }
        }
        private ICommand _AnimalListConfirm;
        public ICommand AnimalListConfirm
        {
            get
            {
                if (_AnimalListConfirm == null)
                {
                    _AnimalListConfirm = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AnimalListConfirm"));
                    });
                }
                return _AnimalListConfirm;
            }
        }
        private ICommand _AnimalListCancel;
        public ICommand AnimalListCancel
        {
            get
            {
                if (_AnimalListCancel == null)
                {
                    _AnimalListCancel = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AnimalListInfoUC"));
                    });
                }
                return _AnimalListCancel;
            }
        }
    }
}

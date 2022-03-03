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
    public class AnimalListUCViewModel : ViewModelBase
    {
        private readonly ServiceAnimal serv = new ServiceAnimal();
        public AnimalListUCViewModel()
        {
            AnimalList = serv.GetAllAnimals();
        }

        private List<Tiere> _AnimalList;
        public List<Tiere> AnimalList
        {
            get { return _AnimalList; }
            set { _AnimalList = value; }
        }

        private Tiere _SelectedAnimal;
        public Tiere SelectedAnimal
        {
            get { return _SelectedAnimal; }
            set
            {
                _SelectedAnimal = value;
                RaisePropertyChanged("SelectedAnimal");
            }
        }

        private string _AnimalName;
        public string AnimalName
        {
            get { return _AnimalName; }
            set
            {
                _AnimalName = value;
                RaisePropertyChanged("AnimalName");
            }
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
                        serv.AddAnimal(AnimalName);
                    });
                }
                return _AnimalListAdd;
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
        private ICommand _AnimalListDelete;
        public ICommand AnimalListDelete
        {
            get
            {
                if (_AnimalListDelete == null)
                {
                    _AnimalListDelete = new RelayCommand(() =>
                      {
                          serv.DeleteAnimal(SelectedAnimal);
                      });
                }
                RaisePropertyChanged("AnimalList");
                return _AnimalListDelete;
            }
        }
        private ICommand _EditAnimal;
        public ICommand EditAnimal
        {
            get
            {
                if (_EditAnimal == null)
                {
                    _EditAnimal = new RelayCommand(() =>
                      {
                          serv.UpdateAnimal(SelectedAnimal);
                      });
                }
                return _EditAnimal;
            }
        }

    }
}

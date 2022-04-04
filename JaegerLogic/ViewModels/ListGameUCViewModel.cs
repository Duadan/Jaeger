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
    public class ListGameUCViewModel : ViewModelBase
    {
        public ListGameUCViewModel()
        {

        }

        private List<string> _ListGame; //evtl pro Spalte Tier, Zähler, ZielAnzahl
        public List<string> ListGame
        {
            get { return _ListGame; }
            set { _ListGame = value; }
        }

        private List<DateTime> _Years;

        public List<DateTime> Years
        {
            get { return _Years; }
            set { _Years = value; }
        }

        private ICommand _ListCreateNew;
        public ICommand ListCreateNew
        {
            get
            {
                if (_ListCreateNew == null)
                {
                    _ListCreateNew = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("ListGameAddEditUC"));
                    });
                }
                return _ListCreateNew;
            }
        }

        private ICommand _ListEdit;
        public ICommand ListEdit
        {
            get
            {
                if (_ListEdit == null)
                {
                    _ListEdit = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("ListGameAddEditUC"));
                    });
                }
                return _ListEdit;
            }
        }
    }
}

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
    public class ListGameAddEditUCViewModel:ViewModelBase
    {
        public ListGameAddEditUCViewModel()
        {
            //TODO alles
        }

        private List<string> _ListGame;
        public List<string> ListGame
        {
            get { return _ListGame; }
            set { _ListGame = value; }
        }

        private List<DateTime> _Year;
        public List<DateTime> Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        private ICommand _GameEditConfirm;
        public ICommand GameEditConfirm
        {
            get
            {
                if (_GameEditConfirm == null)
                {
                    _GameEditConfirm = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("HunterInfoUC"));
                    });
                }
                return _GameEditConfirm;
            }
        }

        private ICommand _GameEditCancel;
        public ICommand GameEditCancel
        {
            get
            {
                if (_GameEditCancel == null)
                {
                    _GameEditCancel = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("ListGameUC"));
                    });
                }
                return _GameEditCancel;
            }
        }
    }
}

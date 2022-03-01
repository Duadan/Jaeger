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
    public class HunterAddEditUCViewModel : ViewModelBase
    {
        private readonly Service serv = new Service();
        public bool Edit = false;
        public HunterAddEditUCViewModel()
        {
            Hunter = new Jaeger();
            Testing = new List<Jaeger>();
        }
        
        #region all the properties
        private List<string> _FormOfAdress=new List<string> { "Herr","Frau","Divers","Dr."};
        public List<string> FormOfAdress
        {
            get { return _FormOfAdress; }
            set 
            {
                _FormOfAdress = value;

            }
        }

        private DateTime _Birthday=DateTime.Today;
        public DateTime Birthday
        {
            get { return _Birthday; }
            set { _Birthday = value; }
        }

        private List<string> _Task=new List<string> { "kein Ahnung", "Tut etwas", "Förster" };
        public List<string> Task
        {
            get { return _Task; }
            set { _Task = value; }
        }

        private Jaeger _Hunter;
        public Jaeger Hunter
        {
            get { return _Hunter; }
            set
            {
                _Hunter = value;
            }
        }

        private List<Jaeger> _Testing;
        public List<Jaeger> Testing
        {
            get { return _Testing; }
            set
            {
                _Testing = value;
                RaisePropertyChanged("Testing");
            }
        }

        #endregion

        private ICommand _ConfirmHunter;
        public ICommand ConfirmHunter
        {
            get
            {
                if (_ConfirmHunter == null)
                {
                    _ConfirmHunter = new RelayCommand(() =>
                    {
                        if (!Edit)
                        {
                            Hunter.Geburtsdatum = Birthday;
                            if (Hunter.IsValid())
                            {
                                serv.InsertHunter(Hunter);
                                //Testing.Add(Hunter);
                                //Testing = Testing;
                                Hunter = new Jaeger();
                            }
                        }
                        if (Edit)
                        {
                            Hunter.Geburtsdatum = Birthday;
                            if (Hunter.IsValid())
                            {
                                serv.UpdateHunter(Hunter);
                                Hunter = new Jaeger();
                            }
                        }
                    });
                }
                return _ConfirmHunter;
            }
        }

        private ICommand _AddHunterCancel;
        public ICommand AddHunterCancel
        {
            get
            {
                if (_AddHunterCancel == null)
                {
                    _AddHunterCancel = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("HunterInfoUC"));
                    });
                }
                return _AddHunterCancel;
            }
        }
    }
}

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JaegerLogic;
using System.ComponentModel;
using System.Windows.Input;

namespace JaegerUI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase,INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
                WindowTitle = "Design";
            }
            else
            {
                // Code runs "for real"
                WindowTitle = "Kimme und Korn";
            }
        }
        public string WindowTitle { get; private set; }
        private ICommand _HunterInfoShow;
        public ICommand HunterInfoShow
        {
            get
            {
                if (_HunterInfoShow == null)
                {
                    _HunterInfoShow = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("HunterInfoUC"));
                    });
                }
                return _HunterInfoShow;
            }
        }
        private ICommand _AppointmentsUC;
        public ICommand AppointmentsUC
        {
            get
            {
                if (_AppointmentsUC == null)
                {
                    _AppointmentsUC = new RelayCommand(() =>
                      {
                          Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentsUC"));
  
                      });
                }
                return _AppointmentsUC;
            }
        }
        private ICommand _InvitationsUC;
        public ICommand InvitationsUC
        {
            get
            {
                if (_InvitationsUC == null)
                {
                    _InvitationsUC = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("InvitationsUC"));

                    });
                }
                return _InvitationsUC;
            }
        }
        private ICommand _ListGameUC;
        public ICommand ListGameUC
        {
            get
            {
                if (_ListGameUC == null)
                {
                    _ListGameUC = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("ListGameUC"));

                    });
                }
                return _ListGameUC;
            }
        }
        private ICommand _AccidentInfo;
        public ICommand AccidentInfo
        {
            get
            {
                if (_AccidentInfo == null)
                {
                    _AccidentInfo = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AccidentInfo"));

                    });
                }
                return _AccidentInfo;
            }
        }
        private ICommand _AnimalListUC;
        public ICommand AnimalListUC
        {
            get
            {
                if (_AnimalListUC == null)
                {
                    _AnimalListUC = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AnimalListUC"));

                    });
                }
                return _AnimalListUC;
            }
        }
        private ICommand _DocumentsUC;
        public ICommand DocumentsUC
        {
            get
            {
                if (_DocumentsUC == null)
                {
                    _DocumentsUC = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("DocumentsUC"));

                    });
                }
                return _DocumentsUC;
            }
        }
        private ICommand _CertificateUC;
        public ICommand CertificateUC
        {
            get
            {
                if (_CertificateUC == null)
                {
                    _CertificateUC = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("CertificateUC"));

                    });
                }
                return _CertificateUC;
            }
        }
        private ICommand _ChangePasswordUC;
        public ICommand ChangePasswordUC
        {
            get
            {
                if (_ChangePasswordUC == null)
                {
                    _ChangePasswordUC = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("ChangePasswordUC"));

                    });
                }
                return _ChangePasswordUC;
            }
        }
    }
}
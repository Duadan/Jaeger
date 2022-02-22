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
    public class ChangePasswordUCViewModel:ViewModelBase
    {
        public ChangePasswordUCViewModel()
        {

        }
        private ICommand _PasswordConfirm;
        public ICommand PasswordConfirm
        {
            get
            {
                if (_PasswordConfirm == null)
                {
                    _PasswordConfirm = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("PasswordConfirm"));
                    });
                }
                return _PasswordConfirm;
            }
        }
        private ICommand _PasswordCancel;
        public ICommand PasswordCancel
        {
            get
            {
                if (_PasswordCancel == null)
                {
                    _PasswordCancel = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentsUC"));
                    });
                }
                return _PasswordCancel;
            }
        }
    }
}

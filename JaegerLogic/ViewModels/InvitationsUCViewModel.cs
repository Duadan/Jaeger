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
    public class InvitationsUCViewModel:ViewModelBase
    {
        public InvitationsUCViewModel()
        {

        }

        private ICommand _InviteCreate;
        public ICommand InviteCreate
        {
            get
            {
                if (_InviteCreate == null)
                {
                    _InviteCreate = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentsCertificateUC"));
                    });
                }
                return _InviteCreate;
            }
        }

        private List<string> _Invites;
        public List<string> Invites
        {
            get { return _Invites; }
            set { _Invites = value; }
        }
    }
}

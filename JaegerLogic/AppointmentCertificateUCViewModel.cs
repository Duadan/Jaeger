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
    public class AppointmentCertificateUCViewModel:ViewModelBase
    {
        public AppointmentCertificateUCViewModel()
        {

        }
        private List<string> _ListCertificates;
        public List<string> ListCertificates
        {
            get { return _ListCertificates; }
            set { _ListCertificates = value; }
        }

        private List<string> _CertificateListHunter;
        public List<string> CertificateListHunter
        {
            get { return _CertificateListHunter; }
            set { _CertificateListHunter = value; }
        }

        private ICommand _CertificateConfirm;
        public ICommand CertificateConfirm
        {
            get
            {
                if (_CertificateConfirm == null)
                {
                    _CertificateConfirm = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("HunterInfoUC"));
                    });
                }
                return _CertificateConfirm;
            }
        }

        private ICommand _CertificateCancel;
        public ICommand CertificateCancel
        {
            get
            {
                if (_CertificateCancel == null)
                {
                    _CertificateCancel = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("AppointmentsUC"));
                    });
                }
                return _CertificateCancel;
            }
        }
    }
}

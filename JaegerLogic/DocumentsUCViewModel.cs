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
    public class DocumentsUCViewModel:ViewModelBase
    {
        public DocumentsUCViewModel()
        {

        }
        private List<string> _ListDocuments;
        public List<string> ListDocuments
        {
            get { return _ListDocuments; }
            set { _ListDocuments = value; }
        }

        private ICommand _DocumentAdd;
        public ICommand DocumentAdd
        {
            get
            {
                if (_DocumentAdd == null)
                {
                    _DocumentAdd = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("DocumentAdd"));//Dateien durchsuchen, dateipfad in DB speichern
                    });
                }
                return _DocumentAdd;
            }
        }

        private ICommand _DocumentEdit;
        public ICommand DocumentEdit
        {
            get
            {
                if (_DocumentEdit == null)
                {
                    _DocumentEdit = new RelayCommand(() =>
                    {
                        Messenger.Default.Send<MainContentChangeMessage>(new MainContentChangeMessage("DocumentEdit"));//Datei über Pfad öffnen
                    });
                }
                return _DocumentEdit;
            }
        }
    }
}

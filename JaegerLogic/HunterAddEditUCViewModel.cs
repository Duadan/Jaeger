using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JaegerLogic
{
    public class HunterAddEditUCViewModel : ViewModelBase
    {
        public HunterAddEditUCViewModel()
        {
            Name = "Ove";
        }
        private string _Name;
        public string Name
        {
            get 
            { 
                return _Name; 
            }
            set
            {
                _Name = value;
                RaisePropertyChanged("Name");
            }
        }
    }
}

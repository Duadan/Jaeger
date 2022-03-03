using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerLogic
{
    public partial class Termine
    {
        public bool IsValid()
        {
            bool valid = false;
            if (!string.IsNullOrEmpty(Ort) && !string.IsNullOrEmpty(Typ)&&!string.IsNullOrEmpty(Bezeichnung))
            {
                valid = true;
            }
            return valid;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerLogic
{
    public partial class Jaeger
    {
        public bool IsValid()
        {
            bool valid = false;
            if (!string.IsNullOrEmpty(Anrede) && !string.IsNullOrEmpty(Nachname) && !string.IsNullOrEmpty(Vorname) && !string.IsNullOrEmpty(Telefonnummer1) && !string.IsNullOrEmpty(Straße) && !string.IsNullOrEmpty(Hausnummer) && !string.IsNullOrEmpty(Ort))
            {
                if (int.TryParse(PLZ, out int r) && PLZ.ToCharArray().Length == 5 && Int64.TryParse(Telefonnummer1, out Int64 t))
                {
                    valid = true;
                }
            }
            return valid;
        }
    }
}

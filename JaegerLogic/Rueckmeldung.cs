//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JaegerLogic
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rueckmeldung
    {
        public int ID { get; set; }
        public string Rolle { get; set; }
        public int Gäste { get; set; }
        public int Termin_ID { get; set; }
        public int Jaeger_ID { get; set; }
    
        public virtual Jaeger Jaeger { get; set; }
        public virtual Termine Termine { get; set; }
    }
}

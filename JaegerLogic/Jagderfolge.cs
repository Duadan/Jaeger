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
    
    public partial class Jagderfolge
    {
        public int ID { get; set; }
        public int Jaeger_ID { get; set; }
        public int Termine_ID { get; set; }
        public int Tiere_ID { get; set; }
        public int Abschüsse { get; set; }
    
        public virtual Jaeger Jaeger { get; set; }
        public virtual Termine Termine { get; set; }
        public virtual Tiere Tiere { get; set; }
    }
}
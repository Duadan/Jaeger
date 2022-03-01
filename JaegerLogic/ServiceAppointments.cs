using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerLogic
{
    public class ServiceAppointments
    {
        public List<Termine> GetAllAppointments()
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var termine = from a in hunt.Termine
                              select new { a.ID, a.Bezeichnung, a.DatumUhrzeit, a.Ort, a.Jagderfolge, a.Postausgang, a.Rueckmeldung, a.Typ };
                var appointment = new List<Termine>();
                foreach (var b in termine)
                {
                    appointment.Add(new Termine()
                    {
                        ID = b.ID,
                        Bezeichnung = b.Bezeichnung,
                        DatumUhrzeit = b.DatumUhrzeit,
                        Ort = b.Ort,
                        Typ = b.Typ,
                        Jagderfolge = b.Jagderfolge,
                        Postausgang = b.Postausgang,
                        Rueckmeldung = b.Rueckmeldung
                    });
                }
                return appointment;
            }
        }
        public List<TerminList> GetTerminLists()
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var termine = from a in hunt.Termine
                              select new { a.ID, a.Bezeichnung, a.DatumUhrzeit, a.Ort, a.Typ };
                var appointment = new List<TerminList>();
                foreach (var b in termine)
                {
                    appointment.Add(new TerminList()
                    {
                        ID = b.ID,
                        Bezeichnung = b.Bezeichnung,
                        DatumUhrzeit = b.DatumUhrzeit,
                        Typ = b.Typ
                    });
                }
                return appointment;
            }
        }

    }
    public partial class TerminList
    {
        public string Bezeichnung { get; set; }
        public DateTime DatumUhrzeit { get; set; }
        public int ID { get; set; }
        public string Typ { get; set; }
    }
}

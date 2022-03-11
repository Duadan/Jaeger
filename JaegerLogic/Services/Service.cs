using System;
using System.Collections.Generic;
using System.Linq;

namespace JaegerLogic
{
    public class Service
    {
        public List<Jaeger> GetAllHunters()
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var hunter = from a in hunt.Jaeger
                             select a;
                List<Jaeger> huntards = new List<Jaeger>();
                foreach (var item in hunter)
                {
                    huntards.Add(new Jaeger()
                    {
                        ID = item.ID,
                        Vorname = item.Vorname,
                        Nachname = item.Nachname,
                    });
                }
                return huntards;
            }
        }

        public void InsertHunter(Jaeger hunterToAdd)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                hunt.Jaeger.Add(hunterToAdd);
                hunt.SaveChanges();
            }
        }

        public void UpdateHunter(Jaeger jaegerToUpdate)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                Jaeger huntards = hunt.Jaeger.Find(jaegerToUpdate.ID);

                huntards.Anrede = jaegerToUpdate.Anrede;
                huntards.Vorname = jaegerToUpdate.Vorname;
                huntards.Nachname = jaegerToUpdate.Nachname;
                huntards.Funktion = jaegerToUpdate.Funktion;
                huntards.Straße = jaegerToUpdate.Straße;
                huntards.Hausnummer = jaegerToUpdate.Hausnummer;
                huntards.Adresszusatz = jaegerToUpdate.Adresszusatz;
                huntards.PLZ = jaegerToUpdate.PLZ;
                huntards.Ort = jaegerToUpdate.Ort;
                huntards.Telefonnummer1 = jaegerToUpdate.Telefonnummer1;
                huntards.Telefonnummer2 = jaegerToUpdate.Telefonnummer2;
                huntards.Telefonnummer3 = jaegerToUpdate.Telefonnummer3;
                huntards.Email = jaegerToUpdate.Email;
                huntards.Geburtsdatum = jaegerToUpdate.Geburtsdatum;

                hunt.SaveChanges();
            }
        }

        public void DelHunter(int hunterID)
        {
            
            using (JaegerDB hunt = new JaegerDB())
            {
                //Einladung löschen optional? falls ja: MessageBoxResult ja-> mach; nein->skip
                var rip = from a in hunt.Rueckmeldung
                          where a.Jaeger_ID == hunterID
                          select new { a.ID };
                foreach(var i in rip)
                {
                    hunt.Rueckmeldung.Remove(hunt.Rueckmeldung.Find(i.ID));
                }
                Jaeger del = hunt.Jaeger.Find(hunterID);
                hunt.Jaeger.Remove(del);
                //List<Rueckmeldung>ruck = (List<Rueckmeldung>)hunt.Rueckmeldung.Where(x => x.Jaeger_ID == ID);
                //hunt.Rueckmeldung.RemoveRange(ruck);
                hunt.SaveChanges();
            }
        }

        public List<Jaeger> GetSelectedHunter(int appointmentID)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var hunter = from a in hunt.Rueckmeldung
                             join b in hunt.Jaeger
                             on a.Jaeger_ID equals b.ID
                             where a.Termin_ID == appointmentID
                             select b;
                List<Jaeger> huntards = hunter.ToList();
                return huntards;
            }
        }

        public Jaeger GetSelectedHunterInfo(int hunterID)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var hunter = from a in hunt.Jaeger
                             where a.ID==hunterID
                             select a;
                return hunter.FirstOrDefault();
            }
        }
    }

    public partial class HunterShown

    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int ID { get; set; }
    }
    public partial class HunterInsert//could be relevant?
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Anrede { get; set; }
        public string Ort { get; set; }
        public string PLZ { get; set; }
        public string Straße { get; set; }
        public string Hausnummer { get; set; }
        public string Adresszusatz { get; set; }
        public string Telefonnummer1 { get; set; }
        public string Telefonnummer2 { get; set; }
        public string Telefonnummer3 { get; set; }
        public string Funktion { get; set; }
        public string Email { get; set; }
        public string Jagdhunde { get; set; }
        public Nullable<System.DateTime> Geburtsdatum { get; set; }
    }
}

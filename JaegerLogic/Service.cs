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
                             select new { a.ID, a.Anrede, a.Vorname, a.Nachname, a.Funktion, a.Straße, a.Hausnummer, a.Adresszusatz, a.PLZ, a.Ort, a.Telefonnummer1, a.Telefonnummer2, a.Telefonnummer3, a.Email, a.Geburtsdatum, a.Jagdhunde };
                var huntards = new List<Jaeger>();
                foreach (var item in hunter)
                {
                    huntards.Add(new Jaeger()
                    {
                        ID = item.ID,
                        Anrede = item.Anrede,
                        Vorname = item.Vorname,
                        Nachname = item.Nachname,
                        Funktion = item.Funktion,
                        Straße = item.Straße,
                        Hausnummer = item.Hausnummer,
                        Adresszusatz = item.Adresszusatz,
                        PLZ = item.PLZ,
                        Ort = item.Ort,
                        Telefonnummer1 = item.Telefonnummer1,
                        Telefonnummer2 = item.Telefonnummer2,
                        Telefonnummer3 = item.Telefonnummer3,
                        Email = item.Email,
                        Geburtsdatum = item.Geburtsdatum
                    });
                }
                return huntards;
            }
        }

        public void InsertHunter(Jaeger hunter)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                hunt.Jaeger.Add(hunter);
                hunt.SaveChanges();
            }
        }

        public void UpdateHunter(Jaeger jaeger)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                Jaeger huntards = hunt.Jaeger.Find(jaeger.ID);

                huntards.Anrede = jaeger.Anrede;
                huntards.Vorname = jaeger.Vorname;
                huntards.Nachname = jaeger.Nachname;
                huntards.Funktion = jaeger.Funktion;
                huntards.Straße = jaeger.Straße;
                huntards.Hausnummer = jaeger.Hausnummer;
                huntards.Adresszusatz = jaeger.Adresszusatz;
                huntards.PLZ = jaeger.PLZ;
                huntards.Ort = jaeger.Ort;
                huntards.Telefonnummer1 = jaeger.Telefonnummer1;
                huntards.Telefonnummer2 = jaeger.Telefonnummer2;
                huntards.Telefonnummer3 = jaeger.Telefonnummer3;
                huntards.Email = jaeger.Email;
                huntards.Geburtsdatum = jaeger.Geburtsdatum;

                hunt.SaveChanges();
            }
        }

        public void DelHunter(int ID)
        {
            
            using (JaegerDB hunt = new JaegerDB())
            {
                //if/where SelectedHunter.ID==hunter.ID
                Jaeger del = hunt.Jaeger.Find(ID);
                hunt.Jaeger.Remove(del);
                hunt.SaveChanges();
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

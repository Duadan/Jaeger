using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerLogic
{
    public class Service
    {
        public List<Jaeger> GetAllHuntards()
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var hunter = from a in hunt.Jaeger
                             select new { a.Anrede, a.Vorname, a.Nachname, a.Funktion, a.Straße, a.Hausnummer, a.Adresszusatz, a.PLZ, a.Ort, a.Telefonnummer1, a.Telefonnummer2, a.Telefonnummer3, a.Email, a.Geburtsdatum,a.Jagdhunde };
                var huntards = new List<Jaeger>();
                foreach (var item in hunter)
                {
                    huntards.Add(new Jaeger()
                    {
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
    }
}

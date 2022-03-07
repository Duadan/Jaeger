using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerLogic
{
    class ServiceAddGame
    {
        public List<Jaeger> GetTheHunters(int appointmentID)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var hunturds = from a in hunt.Jaeger
                               join b in hunt.Rueckmeldung
                               on a.ID equals b.Jaeger_ID
                               where b.Termin_ID == appointmentID
                               select new { a.Vorname, a.Nachname, a.ID };
                List<Jaeger> huntards = new List<Jaeger>();
                foreach (var i in hunturds)
                {
                    huntards.Add(new Jaeger
                    {
                        ID = i.ID,
                        Vorname = i.Vorname,
                        Nachname = i.Nachname
                    });
                }
                return huntards;
            }
        }
        public void AddToGame(AnimalShown selectedAnimal, int selectedHunterID, int selectedAppointmentID)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                for (int i = 0; i < selectedAnimal.Anzahl; i++)
                {
                    Jagderfolge kills = new Jagderfolge
                    {
                        Jaeger_ID = selectedHunterID,
                        Tiere_ID = selectedAnimal.TierID,
                        Termine_ID = selectedAppointmentID
                    };
                    hunt.Jagderfolge.Add(kills);
                }
                hunt.SaveChanges();
            }
        }
        public List<AnimalShown> GetAllAnimalsShown()
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var animal = from a in hunt.Tiere
                             select new { a.ID, a.Tierart };
                List<AnimalShown> animals = new List<AnimalShown>();
                foreach (var b in animal)
                {
                    animals.Add(new AnimalShown
                    {
                        TierID = b.ID,
                        Tier = b.Tierart,
                        Anzahl=0
                    });
                }
                return animals;
            }
        }

    }
    public class AnimalShown
    {
        public int TierID { get; set; }
        public int Anzahl { get; set; }
        public string Tier { get; set; }
    }
}

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
                for (int i = 0; i < selectedAnimal.AnimalCount; i++)
                {
                    Jagderfolge kills = new Jagderfolge
                    {
                        Jaeger_ID = selectedHunterID,
                        Tiere_ID = selectedAnimal.AnimalID,
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
                        AnimalID = b.ID,
                        Animal = b.Tierart,
                        AnimalCount=0
                    });
                }
                return animals;
            }
        }

        public List<AnimalShot> GetAnimalsShot()
        {
            using(JaegerDB hunt=new JaegerDB())
            {
                var killList = from a in hunt.Jagderfolge
                               join b in hunt.Termine
                               on a.Termine_ID equals b.ID
                               join c in hunt.Tiere
                               on a.Tiere_ID equals c.ID
                               join d in hunt.Jaeger
                               on a.Jaeger_ID equals d.ID
                               select new { b.DatumUhrzeit, c.Tierart,c.ID, d.Vorname, d.Nachname };
                List<AnimalShot> shots = new List<AnimalShot>();
                foreach(var i in killList)
                {
                    shots.Add(new AnimalShot
                    {
                        Vorname = i.Vorname,
                        Nachname = i.Nachname,
                        TierID=i.ID,
                        Tier = i.Tierart,
                        Datum = i.DatumUhrzeit
                    });
                }
                return shots;
            }
        }

        public List<AnimalShown> GetAppointmentGame(int appointmentID)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var killcount = from a in hunt.Tiere
                                join b in hunt.Jagderfolge
                                on a.ID equals b.Tiere_ID
                                where b.Termine_ID == appointmentID
                                select new { a.Tierart, a.ID };
                Dictionary<int, AnimalShown> game = new Dictionary<int, AnimalShown>();
                List<AnimalShown> gameList = new List<AnimalShown>();
                List<string> isIn = new List<string>();
                //int count = 0;
                foreach (var item in killcount)
                {
                    AnimalShown currentGame = gameList.FirstOrDefault(g => g.Animal == item.Tierart);
                    if (currentGame == null)
                    {
                        currentGame = new AnimalShown
                        {
                            Animal = item.Tierart,
                            AnimalID = item.ID
                        };
                        gameList.Add(currentGame);
                    }
                    currentGame.AnimalCount++;

                }
                gameList = gameList.OrderBy(g => g.Animal).ToList();
                return gameList;
            }
        }

        #region Accident
        public void InsertAccident(Termine accidentToAdd, List<AnimalShown> animalCount)
        {
            using (JaegerDB hunt = new JaegerDB())
            {

                hunt.Termine.Add(accidentToAdd);
                hunt.SaveChanges();
                foreach (AnimalShown a in animalCount)
                {
                    AddToGame(a, 0, accidentToAdd.ID);
                }
            }
        }

        public List<AnimalShown> GetAllAccidents()
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var killcount = from a in hunt.Tiere
                                join b in hunt.Jagderfolge
                                on a.ID equals b.Tiere_ID
                                where b.Termine.Typ=="Unfall"
                                select new { a.Tierart, a.ID };
                Dictionary<int, AnimalShown> game = new Dictionary<int, AnimalShown>();
                List<AnimalShown> gameList = new List<AnimalShown>();
                //int count = 0;
                foreach (var item in killcount)
                {
                    AnimalShown currentGame = gameList.FirstOrDefault(g => g.Animal == item.Tierart);
                    if (currentGame == null)
                    {
                        currentGame = new AnimalShown
                        {
                            Animal = item.Tierart,
                            AnimalID = item.ID
                        };
                        gameList.Add(currentGame);
                    }
                    currentGame.AnimalCount++;

                }
                gameList = gameList.OrderBy(g => g.Animal).ToList();
                return gameList;
            }
        }

        public List<Termine> GetAccidents()
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var termine = from a in hunt.Termine
                              where a.Typ == "Unfall"
                              select a;
                List<Termine> appointment = termine.ToList();
                return appointment;
            }
        }

        #endregion

    }
    public class AnimalShown
    {
        public int AnimalID { get; set; }
        public int AnimalCount { get; set; }
        public string Animal { get; set; }
    }

    public class AnimalShot
    {
        public string Vorname { get; set; }

        public string Nachname { get; set; }

        public int TierID { get; set; }

        public string Tier { get; set; }

        public DateTime Datum { get; set; }
    }
}

using CommonServiceLocator;
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
                              select a;
                List<Termine> appointment = termine.ToList();
                return appointment;
            }
        }

        //public List<TerminList> GetTerminLists()
        //{
        //    using (JaegerDB hunt = new JaegerDB())
        //    {
        //        var termine = from a in hunt.Termine
        //                      select new { a.ID, a.Bezeichnung, /*a.DatumUhrzeit,*/ a.Ort, a.Typ };
        //        var appointment = new List<TerminList>();
        //        foreach (var b in termine)
        //        {
        //            appointment.Add(new TerminList()
        //            {
        //                ID = b.ID,
        //                Bezeichnung = b.Bezeichnung,
        //                //DatumUhrzeit = b.DatumUhrzeit,
        //                Typ = b.Typ
        //            });
        //        }
        //        return appointment;
        //    }
        //}

        public void InsertAppointment(Termine appointmentList, List<TerminJaeger> appointmentHunterList)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                hunt.Termine.Add(appointmentList);
                Rueckmeldung answer;
                foreach (TerminJaeger i in appointmentHunterList)
                {
                    if (i.Eingeladen)
                    {
                        if (i.Rolle == null)
                        {
                            i.Rolle = "Gast";
                        }
                        answer = new Rueckmeldung()
                        {
                            Gäste = i.Gaeste,
                            Jaeger_ID = i.ID,
                            Rolle = i.Rolle,
                            Termin_ID = appointmentList.ID
                        };
                        hunt.Rueckmeldung.Add(answer);
                    }
                }
                hunt.SaveChanges();
            }
        }

        public void UpdateAppointment(Termine appointment, List<TerminJaeger> appointmentHunterList)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                Termine updating = hunt.Termine.Find(appointment.ID);

                updating.Bezeichnung = appointment.Bezeichnung;
                updating.DatumUhrzeit = appointment.DatumUhrzeit;
                updating.Ort = appointment.Ort;
                updating.Typ = appointment.Typ;
                hunt.SaveChanges();

                var invites = from a in hunt.Rueckmeldung
                              where a.Termin_ID == appointment.ID
                              select a;

                Rueckmeldung answer;
                foreach (TerminJaeger i in appointmentHunterList.Where(hunter => hunter.Eingeladen))
                {
                    //Jäger Updaten, z.B. mehr Gäste
                    Rueckmeldung adjust = invites.FirstOrDefault(answr => answr.Jaeger_ID == i.ID);
                    if (adjust != null)
                    {
                        adjust.Gäste = i.Gaeste;
                        adjust.Rolle = i.Rolle;
                    }
                    //Jäger hinzufügen; mehr eingeladen
                    else
                    {
                        answer = new Rueckmeldung()
                        {
                            Gäste = i.Gaeste,
                            Jaeger_ID = i.ID,
                            Rolle = i.Rolle,
                            Termin_ID = updating.ID
                        };
                        hunt.Rueckmeldung.Add(answer);
                    }

                }
                //Jäger ausladen
                foreach (TerminJaeger i in appointmentHunterList.Where(hunter => !hunter.Eingeladen))
                {
                    Rueckmeldung adjust = invites.FirstOrDefault(answr => answr.Jaeger_ID == i.ID);

                    if (adjust != null)
                    {
                        hunt.Rueckmeldung.Remove(adjust);
                    }
                }
                hunt.SaveChanges();
            }
        }
        //public void SaveAnswers(List<TerminJaeger> appointmentHunterList, int appointmentID)
        //{
        //    using (JaegerDB hunt = new JaegerDB())
        //    {
        //        Rueckmeldung answer;
        //        foreach (TerminJaeger i in appointmentHunterList)
        //        {
        //            if (i.Eingeladen)
        //            {
        //                answer = new Rueckmeldung()
        //                {
        //                    Gäste = i.Gaeste,
        //                    Jaeger_ID = i.ID,
        //                    Rolle = i.Rolle,
        //                    Termin_ID = appointmentID
        //                };
        //                hunt.Rueckmeldung.Add(answer);
        //            }
        //        }
        //        hunt.SaveChanges();
        //    }
        //}

        public List<Jagderfolge> GetAllGame(int appointmentID)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var game = from a in hunt.Jagderfolge
                           where a.Termine_ID == appointmentID
                           select a;
                var gamelist = game.ToList();
                return gamelist;
            }
        }

        public List<TerminJaeger> GetAllAppointmentHunters()
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var hunter = from a in hunt.Jaeger
                             select new { a.ID, a.Vorname, a.Nachname, };
                var huntards = new List<TerminJaeger>();
                foreach (var item in hunter)
                {
                    huntards.Add(new TerminJaeger()
                    {
                        ID = item.ID,
                        Vorname = item.Vorname,
                        Nachname = item.Nachname,
                        Eingeladen = false
                    });
                }
                return huntards;
            }
        }

        public List<TerminJaeger> GetAllAppointmentHunters(int appointmentID)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var hunter = from a in hunt.Jaeger
                             join b in hunt.Rueckmeldung
                             on a.ID equals b.Jaeger_ID
                             into ab
                             from c in ab.DefaultIfEmpty()
                             where c.Termin_ID == appointmentID
                             select new
                             {
                                 a.ID,
                                 a.Vorname,
                                 a.Nachname,
                                 c.Gäste,
                                 c.Rolle
                             };

                List<TerminJaeger> huntards = new List<TerminJaeger>();
                foreach (var item in hunter)
                {
                    huntards.Add(new TerminJaeger()
                    {
                        ID = item.ID,
                        Vorname = item.Vorname,
                        Nachname = item.Nachname,
                        Gaeste = item.Gäste,
                        Rolle = item.Rolle,
                        Eingeladen = !string.IsNullOrEmpty(item.Rolle)
                    });
                }

                return huntards;
            }
        }

        public Termine SelectedAppointment(int appointmentID)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var termine = from a in hunt.Termine
                              where a.ID == appointmentID
                              select a;
                Termine appointment = new Termine();
                foreach (var item in termine)
                {
                    appointment.ID = item.ID;
                    appointment.DatumUhrzeit = item.DatumUhrzeit;
                    appointment.Bezeichnung = item.Bezeichnung;
                    appointment.Typ = item.Typ;
                    appointment.Ort = item.Ort;
                }
                return appointment;
            }
        }
        //WiP
        public List<Game> GetBigGame(int appointmentID, int hunterID)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var killcount = from a in hunt.Tiere
                                join b in hunt.Jagderfolge
                                on a.ID equals b.Tiere_ID
                                where b.Termine_ID == appointmentID && b.Jaeger_ID == hunterID
                                select new { a.Tierart, a.ID};
                Dictionary<int, Game> game = new Dictionary<int, Game>();
                List<Game> gameList = new List<Game>();
                List<string> isIn = new List<string>();
                //int count = 0;
                foreach (var item in killcount)
                {
                    Game currentGame = gameList.FirstOrDefault(g => g.Animal == item.Tierart);
                    if (currentGame == null)
                    {
                        currentGame = new Game
                        {
                            Animal = item.Tierart,
                            ID = item.ID
                        };
                        gameList.Add(currentGame);
                    }
                    currentGame.Count++;
                    
                }
                gameList = gameList.OrderBy(g => g.Animal).ToList();
                return gameList;
            }
        }

        public int[] GetTheNumbers(int appointmentID)//[0]all; [1]hunting; [2]scary
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var hunter = from a in hunt.Rueckmeldung
                             where a.Termin_ID == appointmentID
                             select new { a.Gäste, a.Rolle };
                int all = 0;
                int hunting = 0;
                int scary = 0;
                foreach (var i in hunter)
                {
                    all++;
                    all += i.Gäste;
                    scary += i.Gäste;
                    if (i.Rolle == "Jäger")
                    {
                        hunting++;
                    }
                    else
                    {
                        scary++;
                    }
                }
                int[] send = { all, hunting, scary };
                return send;
                //AppointmentInfoUCViewModel info = ServiceLocator.Current.GetInstance<AppointmentInfoUCViewModel>();
                //info.CountGuests = all;
                //info.CountBeater = scary;
                //info.CountHunter = hunting;
            }
        }

        public List<HunterInvited> GetInvitedHunter(int appointmentID)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var hunter = from a in hunt.Jaeger
                             join b in hunt.Rueckmeldung
                             on a.ID equals b.Jaeger_ID
                             into ab
                             from c in ab.DefaultIfEmpty()
                             where c.Termin_ID == appointmentID
                             select new
                             {
                                 a.ID,
                                 a.Anrede,
                                 a.Vorname,
                                 a.Nachname,
                                 a.Funktion,
                                 a.Straße,
                                 a.Hausnummer,
                                 a.Adresszusatz,
                                 a.PLZ,
                                 a.Ort,
                                 a.Telefonnummer1,
                                 a.Telefonnummer2,
                                 a.Telefonnummer3,
                                 a.Email,
                                 a.Geburtsdatum,
                                 c.Gäste,
                                 c.Rolle
                             };

                //var disappoint = from b in hunt.Rueckmeldung
                //                 where b.Termin_ID == ID
                //                 select new { b.Rolle, b.Gäste,b.Jaeger_ID };
                var huntards = new List<HunterInvited>();
                foreach (var item in hunter)
                {
                    huntards.Add(new HunterInvited()
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
                        Geburtsdatum = item.Geburtsdatum,
                        Gäste = item.Gäste,
                        Rolle = item.Rolle,
                        //Eingeladen = !string.IsNullOrEmpty(item.Rolle)
                    });
                }

                return huntards;
            }
        }

        public void DelAppointment(int appointmentID)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                //Einladung löschen optional? falls ja: MessageBoxResult ja-> mach; nein->skip
                var rip = from a in hunt.Rueckmeldung
                          where a.Termin_ID == appointmentID
                          select new { a.ID };
                foreach (var i in rip)
                {
                    hunt.Rueckmeldung.Remove(hunt.Rueckmeldung.Find(i.ID));
                }
                Termine del = hunt.Termine.Find(appointmentID);
                hunt.Termine.Remove(del);
                //List<Rueckmeldung>ruck = (List<Rueckmeldung>)hunt.Rueckmeldung.Where(x => x.Jaeger_ID == ID);
                //hunt.Rueckmeldung.RemoveRange(ruck);
                hunt.SaveChanges();
            }
        }
    }
    //public partial class TerminList
    //{
    //    public string Bezeichnung { get; set; }
    //    //public DateTime DatumUhrzeit { get; set; }
    //    public int ID { get; set; }
    //    public string Typ { get; set; }
    //}

    public class TerminJaeger
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int ID { get; set; }
        public bool Eingeladen { get; set; }
        public string Rolle { get; set; }
        public int Gaeste { get; set; }
    }

    public partial class Game
    {
        public int ID { get; set; }

        public string Animal { get; set; }
        public int Count { get; set; }
    }

    public class HunterInvited
    {
        public int ID { get; set; }
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
        public Nullable<System.DateTime> Geburtsdatum { get; set; }
        public string Rolle { get; set; }
        public int Gäste { get; set; }
    }
}

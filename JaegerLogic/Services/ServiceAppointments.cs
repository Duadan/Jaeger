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
                              select new { a.ID, a.Bezeichnung, a.DatumUhrzeit, a.Ort, a.Typ };
                var appointment = new List<Termine>();
                foreach (var b in termine)
                {
                    appointment.Add(new Termine()
                    {
                        ID = b.ID,
                        Bezeichnung = b.Bezeichnung,
                        DatumUhrzeit = b.DatumUhrzeit,
                        Ort = b.Ort,
                        Typ = b.Typ
                    });
                }
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
                Termine Appointment = new Termine
                {
                    Bezeichnung = appointmentList.Bezeichnung,
                    DatumUhrzeit = appointmentList.DatumUhrzeit,
                    Typ = appointmentList.Typ,
                    Ort = appointmentList.Ort
                };
                hunt.Termine.Add(Appointment);
                Rueckmeldung answer;
                foreach (TerminJaeger i in appointmentHunterList)
                {
                    if (i.Eingeladen)
                    {
                        answer = new Rueckmeldung()
                        {
                            Gäste = i.Gaeste,
                            Jaeger_ID = i.ID,
                            Rolle = i.Rolle,
                            Termin_ID = Appointment.ID
                        };
                        hunt.Rueckmeldung.Add(answer);
                    }
                    hunt.SaveChanges();
                }
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
                           select new { a.ID, a.Jaeger_ID, a.Termine_ID, a.Tiere_ID, };
                var gamelist = new List<Jagderfolge>();
                foreach (var b in game)
                {
                    gamelist.Add(new Jagderfolge()
                    {
                        ID = b.ID,
                        Jaeger_ID = b.Jaeger_ID,
                        Termine_ID = b.Termine_ID,
                        Tiere_ID = b.Tiere_ID
                    });
                }
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

                //var disappoint = from b in hunt.Rueckmeldung
                //                 where b.Termin_ID == ID
                //                 select new { b.Rolle, b.Gäste,b.Jaeger_ID };
                var huntards = new List<TerminJaeger>();
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
                              select new { a.ID, a.Bezeichnung, a.DatumUhrzeit, a.Ort, a.Typ };
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

        public List<Game> GetBigGame(int appointmentID, int hunterID)
        {
            using (JaegerDB hunt = new JaegerDB())
            {
                var killcount = from a in hunt.Tiere
                                join b in hunt.Jagderfolge
                                on a.ID equals b.Tiere_ID
                                where b.Termine_ID == appointmentID && b.Jaeger_ID == hunterID
                                select new { a.Tierart };
                List<Game> game = new List<Game>();
                int count=0;
                foreach(var item in killcount)
                {
                    count++;
                }
                return game;
            }
        }

        public void GetTheNumbers(int appointmentID)
        {
            using (JaegerDB hunt=new JaegerDB())
            {
                var hunter = from a in hunt.Rueckmeldung
                             where a.Termin_ID == appointmentID
                             select new { a.Gäste,a.Rolle };
                int all=0;
                int hunting = 0;
                int scary = 0;
                foreach(var i in hunter)
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
                AppointmentInfoUCViewModel info = ServiceLocator.Current.GetInstance<AppointmentInfoUCViewModel>();
                info.CountGuests = all;
                info.CountBeater = scary;
                info.CountHunter = hunting;
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

    public partial class TerminJaeger
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
        public string Animal { get; set; }
        public int Count { get; set; }
    }
}

using GalaSoft.MvvmLight.Messaging;
using JaegerLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JaegerUI
{
    /// <summary>
    /// Interaktionslogik für AppointmentsUC.xaml
    /// </summary>
    public partial class AppointmentsUC : UserControl
    {
        public AppointmentsUC()
        {
            InitializeComponent();
            CtrlAppointment.Content = new AppointmentCalendarUC();
            Messenger.Default.Register<MainContentChangeMessage>(this, (MainContentChangeMessage message) =>
            {
                switch (message.Control)
                {
                    case "AppointmentInfoUC":
                        CtrlAppointment.Content = new AppointmentInfoUC();
                        break;
                    case "AppointmentAddEditUC":
                        CtrlAppointment.Content = new AppointmentAddEditUC();//ID oder so mitgeben
                        break;
                    case "AppointmentCertificateUC":
                        CtrlAppointment.Content = new AppointmentCertificateUC();
                        break;
                    case "AppointmentAddGameUC":
                        CtrlAppointment.Content = new AppointmentAddGameUC();
                        break;
                    case "AppointmentCalendarUC":
                        CtrlAppointment.Content = new AppointmentCalendarUC();
                        break;
                    case "CertificateUC":
                        CtrlAppointment.Content = new AppointmentCertificateUC();
                        break;
                }
            });
        }
    }
}

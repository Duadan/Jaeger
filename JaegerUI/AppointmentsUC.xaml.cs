﻿using System;
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
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            CtrlAppointment.Content = new AppointmentInfoUC();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CtrlAppointment.Content = new AppointmentAddEditUC();
        }

        private void BtnCertificate_Click(object sender, RoutedEventArgs e)
        {
            CtrlAppointment.Content = new AppointmentCertificateUC();
        }

        private void BtnGame_Click(object sender, RoutedEventArgs e)
        {
            CtrlAppointment.Content = new AppointmentAddGameUC();
        }
    }
}

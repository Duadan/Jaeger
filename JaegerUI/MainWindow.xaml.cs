﻿using GalaSoft.MvvmLight.Messaging;
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
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CtrlMainWindow.Content = new AppointmentsUC();
            Messenger.Default.Register<MainContentChangeMessage>(this, (MainContentChangeMessage message) =>
            {
                switch (message.Control)
                {
                    case "AppointmentsUC":
                        CtrlMainWindow.Content = new AppointmentsUC();
                        break;
                    case "HunterInfoUC":
                        CtrlMainWindow.Content = new HunterInfoUC();
                        break;
                    case "InvitationsUC":
                        CtrlMainWindow.Content = new InvitationsUC();
                        break;
                    case "ListGameUC":
                        CtrlMainWindow.Content = new ListGameUC();
                        break;
                    case "AccidentInfo":
                        CtrlMainWindow.Content = new AccidentInfo();
                        break;
                    case "AnimalListUC":
                        CtrlMainWindow.Content = new AnimalListUC();
                        break;
                    case "DocumentsUC":
                        CtrlMainWindow.Content = new DocumentsUC();
                        break;
                    case "CertificateUC":
                        AppointmentsUC appointments = new AppointmentsUC();
                        CtrlMainWindow.Content = appointments;
                        appointments.CtrlAppointment.Content = new AppointmentCertificateUC();
                        break;
                    case "ChangePasswordUC":
                        CtrlMainWindow.Content = new ChangePasswordUC();
                        break;
                    case "HunterAddEditUC":
                        CtrlMainWindow.Content = new HunterAddEditUC();
                        break;
                }

            });
        }
    }
}

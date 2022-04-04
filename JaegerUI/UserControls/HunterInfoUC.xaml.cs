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
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class HunterInfoUC : UserControl
    {
        public HunterInfoUC()
        {
            InitializeComponent();
        }

        private void LBHunter_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send<string>("LBHunterLoaded");
        }
    }
}
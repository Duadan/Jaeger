/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:JaegerUI"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using JaegerLogic;
//using Microsoft.Practices.ServiceLocation;

namespace JaegerUI.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<HunterAddEditUCViewModel>();
            SimpleIoc.Default.Register<HunterInfoUCViewModel>();
            SimpleIoc.Default.Register<LoginUCViewModel>();
            SimpleIoc.Default.Register<ChangePasswordUCViewModel>();
            SimpleIoc.Default.Register<AppointmentsUCViewModel>();
            SimpleIoc.Default.Register<AppointmentAddEditUCViewModel>();
            SimpleIoc.Default.Register<AppointmentAddGameUCViewModel>();
            SimpleIoc.Default.Register<AppointmentCertificateUCViewModel>();
            SimpleIoc.Default.Register<AppointmentInfoUCViewModel>();
            SimpleIoc.Default.Register<AccidentInfoUCViewModel>();
            SimpleIoc.Default.Register<AccidentAddUCViewModel>();
            SimpleIoc.Default.Register<InvitationsUCViewModel>();
            SimpleIoc.Default.Register<DocumentsUCViewModel>();
            SimpleIoc.Default.Register<AnimalListUCViewModel>();
            SimpleIoc.Default.Register<ListGameUCViewModel>();
            SimpleIoc.Default.Register<ListGameAddEditUCViewModel>();
        }
        public HunterAddEditUCViewModel HunterAddEditUC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HunterAddEditUCViewModel>();
            }

        }
        public LoginUCViewModel LoginUC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginUCViewModel>();
            }
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public AppointmentsUCViewModel AppointmentsUC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AppointmentsUCViewModel>();
            }
        }
        public ChangePasswordUCViewModel ChangePasswordUC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ChangePasswordUCViewModel>();
            }
        }
        public AppointmentAddEditUCViewModel AppointmentAddEditUC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AppointmentAddEditUCViewModel>();
            }
        }
        public AppointmentAddGameUCViewModel AppointmentAddGameUC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AppointmentAddGameUCViewModel>();
            }
        }
        public AppointmentCertificateUCViewModel AppointmentCertificateUC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AppointmentCertificateUCViewModel>();
            }
        }
        public AppointmentInfoUCViewModel AppointmentInfoUC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AppointmentInfoUCViewModel>();
            }
        }
        public HunterInfoUCViewModel HunterInfoUC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HunterInfoUCViewModel>();
            }
        }
        public AccidentInfoUCViewModel AccidentInfoUC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AccidentInfoUCViewModel>();
            }
        }
        public AccidentAddUCViewModel AccidentAddUC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AccidentAddUCViewModel>();
            }
        }
        public InvitationsUCViewModel InvitationsUC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InvitationsUCViewModel>();
            }
        }
        public DocumentsUCViewModel DocumentsUC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DocumentsUCViewModel>();
            }
        }
        public AnimalListUCViewModel AnimalListUC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AnimalListUCViewModel>();
            }
        }
        public ListGameUCViewModel ListGameUC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ListGameUCViewModel>();
            }
        }
        public ListGameAddEditUCViewModel ListGameAddEditUC
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ListGameAddEditUCViewModel>();
            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
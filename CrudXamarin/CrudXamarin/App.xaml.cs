using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CrudXamarin.Modelo;
using CrudXamarin.Vista;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CrudXamarin
{
    public partial class App : Application
    {

        //public static Config_Data DataBase = new Config_Data();
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new Lista_Contenido());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CrudXamarin.Modelo;


namespace CrudXamarin.Vista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Operaciones_CRUD : ContentPage
	{
		public Operaciones_CRUD ()
		{
			InitializeComponent ();
		}

        
    

        private async void OnToDoItemAdded_Clicked(object sender, EventArgs e)
        {
            var newToDoItem = (Modelo.Tbl_Data)BindingContext;

            Config_Data dt = new Config_Data();
            var Resultado = await dt.Insertar(newToDoItem);
            if (Resultado == 1)
            {
                await App.Current.MainPage.DisplayAlert("Info", $"Registro guardado, ID:{newToDoItem}", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Error al guardar", "OK");
                await Navigation.PopAsync();
            }


        }

        private async void ButtonEliminar_Clicked(object sender, EventArgs e)
        {
            var itemToDelete = (Modelo.Tbl_Data)BindingContext;

            Config_Data dt = new Config_Data();
            await dt.BorrarDatos(itemToDelete);
            await Navigation.PopAsync();
            

        }

        private void ButtonActualizar_Clicked(object sender, EventArgs e)
        {
            var item = (Modelo.Tbl_Data)BindingContext;
        }

        private void ButtonCancelar_Clicked(object sender, EventArgs e)
        {

        }
    }
}
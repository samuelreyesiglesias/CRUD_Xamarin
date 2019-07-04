using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudXamarin.Vista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Lista_Contenido : ContentPage
	{

        List<Modelo.Tbl_Data> Tareas = new List<Modelo.Tbl_Data>();
		public Lista_Contenido ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var R = new Modelo.Config_Data();
            var Resultado = R.ObtenerTodosItems();
            var r = await Resultado;
            Tareas = r.ToList();
            ListViewItems.ItemsSource = Tareas;

        }
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Operaciones_CRUD { BindingContext = new Modelo.Tbl_Data() });

        }
        
        private async void ListViewItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var TodoItem = e.SelectedItem as Modelo.Tbl_Data;
            if(TodoItem != null)
            {
                await Navigation.PushAsync(new Operaciones_CRUD { BindingContext = TodoItem });
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using CrudXamarin.Modelo;
namespace CrudXamarin.Modelo
{
    
    class Config_Data
    {
        SQLiteAsyncConnection Database;

        public Config_Data()
        {
            String DbFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoItemDb.db");
            Database = new SQLiteAsyncConnection(DbFilePath);
            Database.CreateTableAsync<Tbl_Data>().Wait();
        }
        public Task<int> Insertar (Tbl_Data tbl_Data)
        {
            return Database.InsertAsync(tbl_Data);
        }

        public Task<Tbl_Data> ObtenerTodoporID(int id)
        {
            return Database.Table<Tbl_Data>().Where(ti => ti.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> ActualizarDatos(Tbl_Data tbl_Data)
        {
            return Database.UpdateAsync(tbl_Data);
        }

        public Task<int> BorrarDatos(Tbl_Data tbl_Data)
        {
            return Database.DeleteAsync(tbl_Data);
        }

        public Task<List<Tbl_Data>> ObtenerTodosItems()
        {
            return Database.Table<Tbl_Data>().ToListAsync();
        }
        public Task<List<Tbl_Data>> ObtenerCategoriaItemsID(int idCategoria)
        {
            return Database.QueryAsync<Tbl_Data>($"SELECT * FROM [T_Tareas] WHERE [CategoryID]={idCategoria}");
        }
    }
}

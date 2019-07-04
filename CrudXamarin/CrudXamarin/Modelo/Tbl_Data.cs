using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace CrudXamarin.Modelo
{
    [Table("Tbl_Registros")]
    class Tbl_Data
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public int CategoryID { get; set; }

    }
}

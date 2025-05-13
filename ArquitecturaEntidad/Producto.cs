using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquitecturaEntidad
{
    public class Producto
    {
        public int IdProducto { get; set; }  
        public string Nombre { get; set; }    
        public string Descripcion { get; set; }  
        public int Stock { get; set; }       
        public decimal Precio { get; set; }   

        public Producto()
        {
        }

        public Producto(int idProducto, string nombre, string descripcion, int stock, decimal precio)
        {
            IdProducto = idProducto;
            Nombre = nombre;
            Descripcion = descripcion;
            Stock = stock;
            Precio = precio;
        }

        public Producto( string nombre, string descripcion, int stock, decimal precio)
        {
           
            Nombre = nombre;
            Descripcion = descripcion;
            Stock = stock;
            Precio = precio;
        }
    }
}

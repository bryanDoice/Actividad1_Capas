using ArquitecturaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquitecturaDatosDatos
{
    public static class ProductoDatos
    {

        public static void CrearProducto(Producto producto)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionBd))
                {
                    conexion.Open();

                    string consulta = "INSERT INTO Producto (Nombre, Descripcion, Stock, Precio) VALUES (@Nombre, @Descripcion, @Stock, @Precio)";
                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                        cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                        cmd.Parameters.AddWithValue("@Precio", producto.Precio);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el producto. Detalles: {ex.Message}");
            }
        }

        public static void EditarProducto(Producto producto)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionBd))
                {
                    conexion.Open();

                    string consulta = "UPDATE Producto SET Nombre = @Nombre, Descripcion = @Descripcion, Stock = @Stock, Precio = @Precio WHERE IdProducto = @IdProducto";
                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                        cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                        cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                        cmd.Parameters.AddWithValue("@Precio", producto.Precio);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el producto. Detalles: {ex.Message}");
            }
        }

        public static void BorrarProducto(int idProducto)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionBd))
                {
                    conexion.Open();

                    string consulta = "DELETE FROM Producto WHERE IdProducto = @IdProducto";
                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al borrar el producto. Detalles: {ex.Message}");
            }
        }

        public static Producto ObtenerProductoPorId(int idProducto)
        {
            Producto producto = null;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionBd))
                {
                    conexion.Open();

                    string consulta = "SELECT * FROM Producto WHERE IdProducto = @IdProducto";
                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                        SqlDataReader leer = cmd.ExecuteReader();
                        if (leer.Read())
                        {
                            producto = new Producto
                            {
                                IdProducto = Convert.ToInt32(leer["IdProducto"]),
                                Nombre = leer["Nombre"].ToString(),
                                Descripcion = leer["Descripcion"].ToString(),
                                Stock = Convert.ToInt32(leer["Stock"]),
                                Precio = Convert.ToDecimal(leer["Precio"])
                            };
                        }
                        leer.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el producto. Detalles: {ex.Message}");
            }

            return producto;
        }

        public static List<Producto> ObtenerTodosLosProductos()
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionBd))
                {
                    conexion.Open();

                    string consulta = "SELECT * FROM Producto";
                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        SqlDataReader leer = cmd.ExecuteReader();
                        while (leer.Read())
                        {
                            Producto prod = new Producto
                            {
                                IdProducto = Convert.ToInt32(leer["IdProducto"]),
                                Nombre = leer["Nombre"].ToString(),
                                Descripcion = leer["Descripcion"].ToString(),
                                Stock = Convert.ToInt32(leer["Stock"]),
                                Precio = Convert.ToDecimal(leer["Precio"])
                            };
                            productos.Add(prod);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los productos: " + ex.Message);
            }

            return productos;
        }

    }
}



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArquitecturaDatosDatos;
using ArquitecturaEntidad;

namespace Actividad1_Capas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CargarProductos();

        }



        private void CargarProductos()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("IdProducto", "ID");
            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("Descripcion", "Descripción");
            dataGridView1.Columns.Add("Stock", "Stock");
            dataGridView1.Columns.Add("Precio", "Precio");

            // Suponiendo que tienes un método para obtener todos los productos
            List<Producto> listaProductos = ArquitecturaDatosDatos.ProductoDatos.ObtenerTodosLosProductos();

            foreach (Producto prod in listaProductos)
            {
                dataGridView1.Rows.Add(prod.IdProducto, prod.Nombre, prod.Descripcion, prod.Stock, prod.Precio);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text;
            string descripcion = textBoxDescripcion.Text;
            int stock = int.Parse(textBoxStonk.Text);
            decimal precio = decimal.Parse(textBoxPrecio.Text);

            Producto nuevoProducto = new Producto(nombre, descripcion, stock, precio);
            ProductoDatos.CrearProducto(nuevoProducto);

            CargarProductos();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdProducto"].Value);
            string nombre = textBoxNombre.Text;
            string descripcion = textBoxDescripcion.Text;
            int stock = int.Parse(textBoxStonk.Text);
            decimal precio = decimal.Parse(textBoxPrecio.Text);

            Producto productoEditado = new Producto(id, nombre, descripcion, stock, precio);
            ProductoDatos.EditarProducto(productoEditado);

            CargarProductos();
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdProducto"].Value);

            DialogResult confirmacion = MessageBox.Show("¿Estás seguro de eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.Yes)
            {
                ProductoDatos.BorrarProducto(id);
                CargarProductos();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dataGridView1.SelectedRows[0];

                textBoxNombre.Text = fila.Cells["Nombre"].Value.ToString();
                textBoxDescripcion.Text = fila.Cells["Descripcion"].Value.ToString();
                textBoxStonk.Text = fila.Cells["Stock"].Value.ToString();
                textBoxPrecio.Text = fila.Cells["Precio"].Value.ToString();
            }
        }
    }
}

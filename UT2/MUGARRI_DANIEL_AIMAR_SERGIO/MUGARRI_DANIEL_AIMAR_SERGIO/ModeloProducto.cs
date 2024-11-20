using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace PruebaProyecto
{
    public class ModeloProducto
    {
        private String nombre;
        private String marca;
        private decimal precio;
        private ImageSource imagen;
        private String descripcion;

        public ModeloProducto(string nombre, string marca, decimal precio, ImageSource imagen, string descripcion)
        {
            this.nombre = nombre;
            this.marca = marca;
            this.precio = precio;
            this.imagen = imagen;
            this.descripcion = descripcion;
        }

        public String getNombre() { return nombre; }
        public String getMarca() { return marca; }
        public decimal getPrecio() { return precio; }
        public ImageSource getImagen() { return imagen; }
        public String getDescripcion() { return descripcion; }
        public void setNombre(String nombre) { this.nombre = nombre; }
        public void setMarca(String marca) { this.marca = marca; }
        public void setPrecio(decimal precio) { this.precio = precio; }
        public void setImange(ImageSource image) { this.imagen = image; }
        public void setDescripcion(String descripcion) { this.descripcion = descripcion; }

    }
}

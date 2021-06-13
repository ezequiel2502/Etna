using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModels
{
    public class CarritoViewModels
    {
        private Producto producto;
        private int cantidad;
        public CarritoViewModels()
        { }
        public CarritoViewModels(Producto producto , int cantidad)
        {
            this.Producto = producto;
            this.Cantidad = cantidad;

        }

        public Producto Producto { get => producto; set => producto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}
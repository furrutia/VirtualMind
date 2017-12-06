using MyResftfullApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyResftfullApp.Models
{
    public class Moneda
    {
        private Contexto contexto;

        private string id;
        private string nombre;
        private decimal cotizacionCompra;
        private decimal cotizacionVenta;
        private string leyendaActualizacion;

        public string Id
        {
            get { return id; }
            set { this.id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { this.nombre = value; }
        }
        public decimal CotizacionCompra
        {
            get { return cotizacionCompra; }
            set { this.cotizacionCompra = value; }
        }
        public decimal CotizacionVenta
        {
            get { return cotizacionVenta; }
            set { this.cotizacionVenta = value; }
        }
        public string LeyendaActualizacion
        {
            get { return leyendaActualizacion; }
            set { this.leyendaActualizacion = value; }
        }

        public Moneda()
        {
            contexto = new Contexto();
        }

        public void Dolar()
        {
            ITipoMoneda dolar = new Dolar();
            contexto.TipoMoneda = dolar;
        }

        public void Real()
        {
            ITipoMoneda real = new Real();
            contexto.TipoMoneda = real;
        }

        public void Pesos()
        {
            ITipoMoneda pesos = new Pesos();
            contexto.TipoMoneda = pesos;
        }

        public string ObtenerCotizacion() {
            return this.contexto.ObtenerCotizacion();
        }

    }
}
using MyResftfullApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyResftfullApp.Models
{
    public class Contexto
    {
        // Referencia a la interfaz
        private ITipoMoneda tipoMoneda;

        // Propiedad que establecerá un nuevo tipo de conducción (cambio de estrategia)
        public ITipoMoneda TipoMoneda
        {
            get { return tipoMoneda; }
            set { this.tipoMoneda = value; }
        }

        // Métodos de servicio (invocan los métodos implementados por las estrategias)
        public string ObtenerCotizacion()
        {
            return tipoMoneda.ObtenerCotizacion();
        }
    }
}
using MyResftfullApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace MyResftfullApp.Models
{
    public class Real : ITipoMoneda
    {
        public string ObtenerCotizacion()
        {
            throw new Exception("Unauthorized");
        }
    }
}
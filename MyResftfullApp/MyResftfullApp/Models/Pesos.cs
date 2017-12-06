using MyResftfullApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net;

namespace MyResftfullApp.Models
{
    public class Pesos : ITipoMoneda
    {
        string ITipoMoneda.ObtenerCotizacion()
        {
            throw new Exception("Unauthorized");
        }
    }
}
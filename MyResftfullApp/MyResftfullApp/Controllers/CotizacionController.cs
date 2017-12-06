using MyResftfullApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web.Http;

namespace MyResftfullApp.Controllers
{
    public class CotizacionController : ApiController
    {
        private JsonMediaTypeFormatter JSONMediaFormatter = new JsonMediaTypeFormatter();

        Moneda[] monedas = new Moneda[]
        {
            new Moneda { Id = "Pesos", Nombre = "Pesos"},
            new Moneda { Id = "Dolar", Nombre = "Dolar"},
            new Moneda { Id = "Real", Nombre = "Real"}
        };

        public IEnumerable<Moneda> GetAllCotizaciones()
        {
            return null;
        }

        public HttpResponseMessage GetCotizacion(string id)
        {
            HttpResponseMessage Response = this.Request.CreateResponse(HttpStatusCode.OK);

            try
            {
                var moneda = monedas.FirstOrDefault((p) => p.Id.ToUpper() == id.ToUpper());
                if (moneda == null)
                {
                    Response.StatusCode = HttpStatusCode.NotFound;
                    return Response;
                }

                Moneda monedaStrategy = new Moneda();

                string cotizacion = "";

                switch (id.ToUpper())
                {
                    case "PESOS":
                        monedaStrategy.Pesos();
                        break;
                    case "DOLAR":
                        monedaStrategy.Dolar();
                        break;
                    case "REAL":
                        monedaStrategy.Real();
                        break;
                    default:
                        break;
                }

                cotizacion = monedaStrategy.ObtenerCotizacion();

                Response.Content = new ObjectContent(typeof(String), cotizacion, JSONMediaFormatter, "application/json");

                return Response;
            }
            catch (Exception ex)
            {
                if (ex.Message == "Unauthorized")
                {
                    Response.StatusCode = HttpStatusCode.Unauthorized;
                    //Response.Content = new ObjectContent(typeof(String), ex.Message, JSONMediaFormatter, "application/json"); 
                }
                return Response;
            }
        }
    }
}

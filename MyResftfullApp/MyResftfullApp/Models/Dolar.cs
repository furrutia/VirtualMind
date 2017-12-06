using MyResftfullApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net;
using System.IO;
using System.Text;

namespace MyResftfullApp.Models
{
    public class Dolar : ITipoMoneda
    {
        public string ObtenerCotizacion()
        {
            WebRequest request = WebRequest.Create("http://www.bancoprovincia.com.ar/Principal/Dolar");

            request.ContentType = "application/json; charset=utf-8";
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            return readStream.ReadToEnd();
        }
    }
}
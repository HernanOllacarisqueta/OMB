﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Data;
using Infraestructura;

namespace Servicios
{
    /// <summary>
    /// Agrupamos todos los servicios relacionados con Productos: Libros, Categorias, Autores, etc...
    /// </summary>
    ///     

    public class ProductServices
  {
    public string ErrorInfo { get; set; }

      public bool AgregarLibro(string Titulo, string ISBN, string ISBN_10)
      {
            bool result = true;
            OMBContext ctx = OMBContext.DB;


            //new Libro()
            //agregar propiedas de los parametros
            //ctx.Libros.add

      }  

  }
}

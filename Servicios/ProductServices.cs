using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Data;
using Infraestructura;
using System.Data.Entity.Infrastructure;

namespace Servicios
{
    /// <summary>
    /// Agrupamos todos los servicios relacionados con Productos: Libros, Categorias, Autores, etc...
    /// </summary>
    ///     

    public class ProductServices
    {
        public string ErrorInfo { get; set; }

        public bool AgregarLibro(string titulo, string isbn, string isbn10)
        {
            bool result = true;
            OMBContext ctx = OMBContext.DB;
            Libro Book;
            ClearError();

            Book = ctx.Libros.FirstOrDefault(libro => libro.Titulo == titulo && libro.ISBN == isbn && libro.ISBN10 == isbn10);

            if (Book == null && !ValidateBook(titulo, isbn, isbn10))
            {
                Libro Libro = new Libro();
                Libro.Titulo = titulo;
                Libro.ISBN = isbn;
                Libro.ISBN10 = isbn10;

                ctx.Libros.Add(Libro);

                ctx.SaveChanges(); // No me deja hacer los cambios
            }
            else
            {
                //ErrorInfo = "Libro existente 2"; //Si es error de Base de datos? 
                result = false;
            }

            return result;
        }

        public bool AgregarLibro2(Libro libro)
        {
            bool result = true;
            OMBContext ctx = OMBContext.DB;
            ClearError();

            ctx.Libros.Add(libro);
            ctx.SaveChanges();

            return result;
        }

        private bool ValidateBook(string titulo, string isbn, string isbn_10)
        {

            bool result = false;
            ClearError();
            OMBContext ctx = OMBContext.DB;

            try
            {
                //  TODO incorporar hashing para comparar con la que obtenemos de la tabla
                int cuenta = ctx.Database
                          .SqlQuery<int>("select count(*) from Libros where Titulo = @p0 and ISBN = @p1 and ISBN10 = @p2", titulo, isbn, isbn_10)
                          .FirstOrDefault();

                if (cuenta == 0)
                {
                    result = false;
                }
                else
                {
                    ErrorInfo = "Libro existente";
                }
            }
            catch (Exception ex)
            {
                //  TODO Lanzar excepcion???
                ErrorInfo = "Error al intentar acceder a la tabla de usuarios";
                result = false;
            }

            return result;
        }

        public List<Editorial> ObtenerListaEditoriales()
        {
            ClearError();

            OMBContext ctx = OMBContext.DB;

            try
            {
                //  TODO
                return ctx.Editoriales.ToList();
            }
            catch (Exception ex)
            {
                //  TODO
                ErrorInfo = "Error al intentar acceder a la tabla de Editoriales";
                return null;
            }

        }

        public Editorial ObtenerEditorial(string nombreEdit)
        {
            ClearError();
            OMBContext ctx = OMBContext.DB;
            Editorial editorial;

            try
            {
                //  TODO
                editorial = ctx.Editoriales.FirstOrDefault(edit => edit.Nombre == nombreEdit);
            }
            catch (Exception ex)
            {
                //  TODO
                ErrorInfo = "Editorial no existente";
                return null;
            }            

            return editorial;
        }

        private void ClearError()
        {
            ErrorInfo = null;
        }

    }



}

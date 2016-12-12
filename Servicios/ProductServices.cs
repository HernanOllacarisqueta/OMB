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

        public bool AgregarLibro(string titulo, string isbn, string isbn_10)
        {
            bool result = true;
            OMBContext ctx = OMBContext.DB;
            Libro Book;
            ClearError();

            //Necesario hacer esto?
            Book = ctx.Libros.FirstOrDefault(libro => libro.Titulo == titulo && libro.ISBN == isbn && libro.ISBN_10 == isbn_10);
                            
            if (Book != null && !ValidateBook(titulo, isbn, isbn_10))
            {
                Libro Libro = new Libro();
                Libro.Titulo = titulo;
                Libro.ISBN = isbn;
                Libro.ISBN_10 = isbn_10;

                ctx.Libros.Add(Libro);
                ctx.SaveChanges();
            }
            else
            {
                //ErrorInfo = "Libro existente 2"; //Si es error de Base de datos? 
                result = false;
            }

            return result;
        }


        private bool ValidateBook(string titulo, string isbn, string isbn_10)
        {

            bool result = false;

            try
            {
                //  TODO incorporar hashing para comparar con la que obtenemos de la tabla
                int cuenta = OMBContext.DB.Database
                          .SqlQuery<int>("select count(*) from Libros where Titulo = @p0 and ISBN = @p1 and ISBN10 = @p2", titulo, isbn, isbn_10)
                          .FirstOrDefault();

                if (cuenta == 0)
                {
                    result = true;
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

        public IQueryable<Editorial> ObtenerEditoriales()
        {
            return OMBContext.DB.Set<Editorial>();
        }

        /*
        public IEnumerable<Editorial> ObtenerEditorales2()
        {
            return OMBContext.DB.Set<Editorial>();
        }
        */

        //Editoriales = OMBContext.DB.Database.ExecuteSqlCommand("select * from Editoriales");
        //

        /* 01
        private DbSqlQuery<Editorial> Editorialesdb;

        public DbSqlQuery<Editorial> ObtenerEditoriales()
        {
            try
            {
                //  TODO
                Editorialesdb  = OMBContext.DB.Editoriales.SqlQuery("select * from Editoriales");

                return Editorialesdb;
            }
            catch (Exception ex)
            {
                //  TODO
                ErrorInfo = "Error al intentar acceder a la tabla de usuarios";
                return null;           
            }
        }
        */

        /* 02
        public List<Editorial> Editoriales;

        public List<Editorial> ObtenerEditoriales()
        {
            try
            {
                //  TODO 
                Editoriales = OMBContext.DB.Database.SqlQuery<List<Editorial>>("select * from Editoriales");

                return Editoriales;
            }
            catch (Exception ex)
            {
                //  TODO
                ErrorInfo = "Error al intentar acceder a la tabla de usuarios";
                return null;
            }
        }*/

        private void ClearError()
        {
            ErrorInfo = null;
        }

    }



}

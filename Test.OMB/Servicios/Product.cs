using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity.Infrastructure;
using Entidades;
using Servicios;

namespace Test.OMB.Servicios
{
    [TestClass]
    public class Product
    {
        [TestMethod]
        public void CrearLibro()
        {
            ProductServices serv = new ProductServices();
            bool result;

            result = serv.AgregarLibro("pepe", "sarasa", "hehe");

            Assert.IsTrue(result, "No se creo");

        }

        [TestMethod]
        public void CrearLibro2()
        {
            ProductServices serv = new ProductServices();
            bool result;

            Libro libro = new Libro();

            result = serv.AgregarLibro2(libro);

            Assert.IsTrue(result, "No se creo");

        }


        [TestMethod]
        public void ObtenerEditoriales()
        {
            ProductServices serv = new ProductServices();

            List<Editorial> editoriaLista = serv.ObtenerListaEditoriales();

            Assert.IsTrue(editoriaLista.Count > 1);

        }

        [TestMethod]
        public void ObtenerEditorial()
        {
            ProductServices serv = new ProductServices();

            Editorial editorial = serv.ObtenerEditorial("Wrox");

            Assert.AreEqual(editorial.Nombre, "Wrox");
        }

    }
}

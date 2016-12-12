using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Servicios;

namespace Test.OMB.Servicios
{
    [TestClass]
    public class Security
    {
        [TestMethod]
        public void ProbarLoginConDatosIncorrectos()
        {
            SecurityServices serv = new SecurityServices();
            bool result;

            result = serv.Login("pirulo", "12345678");

            Assert.IsFalse(result, "Hay un usuario pirulo???");
        }

        [TestMethod]
        public void ProbarLoginConDatosCorrectos()
        {
            SecurityServices serv = new SecurityServices();
            bool result;

            result = serv.Login("ethedy", "12345678");

            Assert.IsTrue(result, "No hay un usuario ethedy???");
        }

        [TestMethod]
        public void TestearObtenerEditoriales()
        {
            ProductServices serv = new ProductServices();

        }
        
    }
}

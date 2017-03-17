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
    public class Productos
    {
        [TestMethod]
        public void ProbarLoginConDatosIncordrectos()
        {
            SecurityServices serv = new SecurityServices();
            bool result;

            result = serv.Login("pirulo", "12345678");

            Assert.IsFalse(result, "Hay un usuario pirulo???");
        }

    }
}

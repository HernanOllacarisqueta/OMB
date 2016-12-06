using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OMB_Desktop.ViewModel;

namespace Test.OMB.Desktop
{
    [TestClass]
    public class Login
    {
        [TestMethod]
        public void LoginFallidoSinUsuario()// Probar si falla el evento FaltanDatos.Raise(new Notification()...
        {
            LoginViewModel lvm = new LoginViewModel();
            bool evento = false;

            lvm.Password = "12324";
            lvm.LoginID = "    ";

            lvm.FaltanDatos.Raised += (sender, args) => 
            {
                evento = true;
            };

            lvm.LoginCommand.Execute(null);
            Assert.IsTrue(evento);
        }
    }
}

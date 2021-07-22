using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Mvc;
using TonicApp;
using TonicApp.Controllers;

namespace TonicAppTests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();
            ViewResult result=controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
       
    }
}

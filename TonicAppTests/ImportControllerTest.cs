using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Mvc;
using TonicApp;
using TonicApp.Controllers;

namespace TonicAppTests
{
    [TestClass]
    public class ImportControllerTest
    {
        [TestMethod]
        public void Index()
        {           
                ImportController controller = new ImportController();
                ViewResult result = controller.Index() as ViewResult;
                Assert.IsNotNull(result);            
        }
    }
}

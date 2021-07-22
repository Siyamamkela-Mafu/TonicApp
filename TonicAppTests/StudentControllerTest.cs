using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Mvc;
using TonicApp;
using TonicApp.Controllers;
namespace TonicAppTests
{
    [TestClass]
    public class StudentControllerTest
    {
        [TestMethod]
        public void Index()
        {
            StudentController controller = new StudentController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Delete()
        {
            long Id = 0;
            StudentController controller = new StudentController();
            ActionResult result = controller.Delete(Id);
            Assert.IsNull(result);
        }
    }
}

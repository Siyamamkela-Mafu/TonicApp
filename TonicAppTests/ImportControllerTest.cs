using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TonicApp;
using TonicApp.Controllers;
using System.Data;
using TonicAppTests.Models;

namespace TonicAppTests
{
    [TestClass]
    public class ImportControllerTest
    {
        public TestContext TestContext { get; set; }
        [TestMethod]
        public void Index()
        {           
                ImportController controller = new ImportController();
                ViewResult result = controller.Index() as ViewResult;
                Assert.IsNotNull(result);            
        }
        [TestMethod]     
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\Data\TonicTestData.csv", "TonicTestData#csv", DataAccessMethod.Sequential), DeploymentItem("TonicAppTests\\Data\\TonicTestData.csv")]
        public void Import()
        {
          string studentNo= TestContext.DataRow[0].ToString();
          string firstName= TestContext.DataRow[1].ToString();
          string surname= TestContext.DataRow[2].ToString();
          string code= TestContext.DataRow[3].ToString();
          string courseDesc= TestContext.DataRow[4].ToString();
          string gradeDesc= TestContext.DataRow[5].ToString();
            var course = new Course(0,code,courseDesc,true);

            Assert.IsTrue(course.Code==code);
            Assert.IsTrue(course.Description==courseDesc);


            var grade = new Grade(0,gradeDesc, true);
            Assert.IsTrue(grade.Description == gradeDesc);

            var student = new Student(0,studentNo,firstName,surname,true);
            Assert.IsTrue(student.FName == firstName);
            Assert.IsTrue(student.Surname == surname);
            Assert.IsTrue(student.StudentNo == studentNo);

        }
    }
}

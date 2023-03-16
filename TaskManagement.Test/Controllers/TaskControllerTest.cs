using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http.Json;
using TaskManagement.Contract.Task;
using TaskManagement.Test.Common;

namespace TaskManagement.Test.Controllers
{
    [TestClass]
    public class TaskControllerTest : IntegrationTest
    {
        [TestMethod]
        public async Task Create_Task()
        {
            // Arrange
            var taskRequest = new TaskRequest("Study React TypeScript.");

            // Act
            var results = await TestClient.PostAsJsonAsync("/api/tasks", taskRequest);

            //Assert
            Assert.AreEqual(results.StatusCode, System.Net.HttpStatusCode.Created);
        }

    }
}

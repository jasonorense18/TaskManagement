using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TaskManagement.Api.Test.Common;
using TaskManagement.Contract.Authentication;
using TaskManagement.Contract.Task;

namespace TaskManagement.Api.Test.Controllers
{

    [TestClass]
    public class TaskControllerTest : IntegrationTest
    {
        [TestMethod]
        public async Task Create_Task()
        {
            // Arrange
            await RegisterUser();
            var taskRequest = new TaskRequest("Study React TypeScript.");

            // Act
            var response = await TestClient.PostAsJsonAsync("api/tasks", taskRequest);
            var jsonString = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);
        }

        [TestMethod]
        public async Task Get_Tasks()
        {
            // Arrange
            await RegisterUser();
            var taskRequest = new TaskRequest("Study React TypeScript.");

            // Act
            var response = await TestClient.GetAsync("api/tasks");
            var jsonString = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK );
        }

        private async Task RegisterUser()
        {
            if (AuthenticationResponse == null)
            {
                var user = new RegisterRequest("Jason", "Orense", "jason@gmail.com", "pass123");
                var response = await TestClient.PostAsJsonAsync("api/auth/register", user);
                var rseultsString = await response.Content.ReadAsStringAsync();
                var authResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(rseultsString);
                AuthenticationResponse = authResponse;
            }

            TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthenticationResponse.Token);
            TestClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}

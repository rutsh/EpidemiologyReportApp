using Microsoft.AspNetCore.Mvc.Testing;
using System;
using Xunit;
using EpedimiologyReport;

namespace EpedimiologyReport.Tests
{
    public class PatientControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public PatientControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void GetPatient_ById_ReturnPatient()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/patient/000000018");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
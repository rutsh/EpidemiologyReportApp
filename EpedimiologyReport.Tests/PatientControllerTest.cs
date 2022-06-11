using Microsoft.AspNetCore.Mvc.Testing;
using System;
using Xunit;
using EpedimiologyReport;
using EpidemiologyReport.Controllers;
using Moq;
using EpedimiologyReport.Services;
using EpedimiologyReport.Services.Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace EpedimiologyReport.Tests
{

    public class PatientControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly Mock<IPatientRepository> _mockRepo;
        private readonly PatientController _controller;
        public PatientControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _mockRepo = new Mock<IPatientRepository>();
            _controller = new PatientController(_mockRepo.Object, NullLogger<PatientController>.Instance);
        }
       
        [Fact]
        public async void AddPatientTest()
        {           
           Patient p1= new Patient("123456789",new List<Locations>());
            _mockRepo.Setup(p => p.Save(p1));          
            await _controller.Save(p1);
            _mockRepo.Verify(x => x.Save(p1), Times.Exactly(1));
        }
       
        [Fact]
        public async void GetPatientByIDTest()
        {            
            string mockID = "123456789";
            _mockRepo.Setup(l => l.Get(mockID)).Returns(Task.FromResult(new Patient() {PatientId=mockID}));
            var result = await _controller.Get(mockID);
            Assert.True(result != null);
            Assert.Equal(result.PatientId,mockID);
        }
        
    }
}
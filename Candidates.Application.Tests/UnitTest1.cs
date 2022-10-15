using Candidates.Application.Services.Interfaces;
using Candidates.Domain.Entities;
using Candidates.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Candidates.Application.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfCandidates()
        {

            var mockRepo = new Mock<ICandidatesService>();
            mockRepo.Setup(repo => repo.GetAllCandidates())
                .Returns(GetTestCandidates());
            var controller = new CandidatesController(mockRepo.Object);
            // Act
            var result = controller.Index();
            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Candidate>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        private IEnumerable<Candidate> GetTestCandidates()
        {
            return new List<Candidate>()
    {
        new Candidate()
        {
            IdCandidate = 1,
            Name = "Antonio"
        },
        new Candidate()
        {
            IdCandidate = 2,
            Name = "Juan"
        }
    };
        }
    }
}
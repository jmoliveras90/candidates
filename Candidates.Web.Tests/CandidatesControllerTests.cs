using Candidates.Application.Queries;
using Candidates.Domain.Entities;
using Candidates.Web.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Candidates.Web.Tests
{
    public class CandidatesControllerTests
    {
        [Fact]
        public async void Index_ReturnsAViewResult_WithAListOfCandidates()
        {
            var mockMediator = new Mock<IMediator>();

            mockMediator.Setup(x => x.Send(new GetAllCandidatesQuery(),
                It.IsAny<CancellationToken>())).ReturnsAsync(GetTestCandidates());

            var controller = new CandidatesController(mockMediator.Object);
            var result = await controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Candidate[]>(
                viewResult.ViewData.Model);

            Assert.Equal(2, model.Count());
        }

        private List<Candidate> GetTestCandidates()
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

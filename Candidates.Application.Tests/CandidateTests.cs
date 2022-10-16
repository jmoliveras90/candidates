using Candidates.Application.Queries;
using Candidates.Application.Services.Interfaces;
using Candidates.Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;
using static Candidates.Application.Queries.GetAllCandidatesQuery;

namespace Candidates.Application.Tests
{
    public class CandidateExperienceTests
    {
        [Fact]
        public async void GetCandidates()
        {
            var mockService = new Mock<ICandidatesService>();
            mockService.Setup(service => service.GetAllCandidates())
                .ReturnsAsync(GetTestCandidates());
            var handler = new GetAllCandidatesQueryHandler(mockService.Object);
            var result = await handler.Handle(new GetAllCandidatesQuery(),
                It.IsAny<CancellationToken>());

            Assert.IsAssignableFrom<IEnumerable<Candidate>>(result);
            Assert.Equal(2, result.Count());
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
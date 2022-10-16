using Candidates.Application.Queries.CandidateExperiences;
using Candidates.Application.Services.Interfaces;
using Candidates.Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;
using static Candidates.Application.Queries.CandidateExperiences.GetAllCandidateExperiencesQuery;

namespace Candidates.Application.Tests
{
    public class CandidatesServiceTests
    {
        [Fact]
        public async void Index_ReturnsAViewResult_WithAListOfCandidates()
        {
            var mockService = new Mock<ICandidateExperiencesService>();
            mockService.Setup(service => service.GetAllCandidateExperiences())
                .ReturnsAsync(GetTestCandidateExperiences());
            var handler = new GetAllCandidateExperiencesQueryHandler(mockService.Object);
            var result = await handler.Handle(new GetAllCandidateExperiencesQuery(),
                It.IsAny<CancellationToken>());

            Assert.IsAssignableFrom<IEnumerable<CandidateExperience>>(result);
            Assert.Equal(2, result.Count());           
        }

        private IEnumerable<CandidateExperience> GetTestCandidateExperiences()
        {
            return new List<CandidateExperience>()
            {
                new CandidateExperience()
                {
                    IdCandidate = 1
                },
                new CandidateExperience()
                {
                    IdCandidate = 2
                }
            };
        }
    }
}
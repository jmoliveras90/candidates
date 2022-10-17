using Candidates.Application.Commands.CandidateExperiences;
using Candidates.Application.Queries.CandidateExperiences;
using Candidates.Domain.Entities;
using Candidates.Web.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace Candidates.Web.Tests
{
    public class CandidateExperiencesControllerTests
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly CandidateExperiencesController _controller;

        public CandidateExperiencesControllerTests()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new CandidateExperiencesController(_mockMediator.Object);
        }

        [Fact]
        public async void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = await _controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Index_ReturnsAViewResult_WithAListOfExperiences()
        {
            _mockMediator.Setup(x => x.Send(It.IsAny<GetAllCandidateExperiencesQuery>(),
                It.IsAny<CancellationToken>())).ReturnsAsync(GetTestCandidateExperiences());

            var controller = new CandidateExperiencesController(_mockMediator.Object);
            var result = await controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CandidateExperience>>(
                viewResult.ViewData.Model);

            Assert.Equal(3, model.Count());
        }

        [Fact]
        public async void Create_ActionExecutes_ReturnsViewForCreate()
        {
            var result = await _controller.Create();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Create_InvalidModelState_ReturnsView()
        {
            AddModelError();

            var experience = GetIncompleteTestCandidateExperienceCommand();
            var result = await _controller.Create(experience);
            var viewResult = Assert.IsType<ViewResult>(result);
            var testExperience = Assert.IsType<CreateCandidateExperienceCommand>(viewResult.Model);

            Assert.Equal(experience.IdCandidate, testExperience.IdCandidate);
            Assert.Equal(experience.Description, testExperience.Description);
        }

        [Fact]
        public async void Create_InvalidModelState_MediatorSendNeverExecutes()
        {
            AddModelError();

            var experience = GetIncompleteTestCandidateExperienceCommand();

            await _controller.Create(experience);

            _mockMediator.Verify(x => x.Send(experience,
                It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async void Create_ModelStateValid_MediatorSendCalledOnce()
        {
            var experience = GetCompleteTestCandidateExperienceCommand();

            await _controller.Create(experience);

            _mockMediator.Verify(x => x.Send(experience,
                 It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async void Create_ActionExecuted_RedirectsToIndexAction()
        {
            var experience = GetCompleteTestCandidateExperienceCommand();
            var result = await _controller.Create(experience);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        private List<CandidateExperience> GetTestCandidateExperiences()
        {
            return new List<CandidateExperience>()
            {
               new CandidateExperience
                {
                    Company = "Test",
                    Description = "Test",
                    Job = "Testing",
                },
                new CandidateExperience
                {
                    Company = "Test",
                    Description = "Test",
                    Job = "Testing",
                },
                new CandidateExperience
                {
                    Company = "Test",
                    Description = "Test",
                    Job = "Testing",
                }
            };
        }

        private CreateCandidateExperienceCommand GetCompleteTestCandidateExperienceCommand()
        {
            return new CreateCandidateExperienceCommand
            {
                BeginDate = DateTime.Now,
                Company = "Test",
                Description = "Test",
                EndDate = new DateTime(2025, 12, 31),
                IdCandidate = 1,
                Job = "Testing",
                Salary = 2000
            };
        }

        private CreateCandidateExperienceCommand GetIncompleteTestCandidateExperienceCommand()
        {
            return new CreateCandidateExperienceCommand
            {
                IdCandidate = 1,
                Description = "Testing"
            };
        }

        private void AddModelError()
        {
            _controller.ModelState.AddModelError("Job", "Job is required");
        }
    }
}

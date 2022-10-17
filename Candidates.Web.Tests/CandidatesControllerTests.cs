using Candidates.Application.Commands.Candidates;
using Candidates.Application.Queries;
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
    public class CandidatesControllerTests
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly CandidatesController _controller;

        public CandidatesControllerTests()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new CandidatesController(_mockMediator.Object);
        }

        [Fact]
        public async void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = await _controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Index_ReturnsAViewResult_WithAListOfCandidates()
        {
            _mockMediator.Setup(x => x.Send(It.IsAny<GetAllCandidatesQuery>(),
                It.IsAny<CancellationToken>())).ReturnsAsync(GetTestCandidates());

            var controller = new CandidatesController(_mockMediator.Object);
            var result = await controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Candidate>>(
                viewResult.ViewData.Model);

            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Create_ActionExecutes_ReturnsViewForCreate()
        {
            var result = _controller.Create();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Create_InvalidModelState_ReturnsView()
        {
            AddModelError();

            var candidate = GetIncompleteTestCandidateCommand();
            var result = await _controller.Create(candidate);
            var viewResult = Assert.IsType<ViewResult>(result);
            var testCandidate= Assert.IsType<CreateCandidateCommand>(viewResult.Model);

            Assert.Equal(candidate.Surname, testCandidate.Surname);
            Assert.Equal(candidate.Email, testCandidate.Email);
        }

        [Fact]
        public async void Create_InvalidModelState_MediatorSendNeverExecutes()
        {
            AddModelError();

            var candidate = GetIncompleteTestCandidateCommand();

            await _controller.Create(candidate);

            _mockMediator.Verify(x => x.Send(candidate,
                It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async void Create_ModelStateValid_MediatorSendCalledOnce()
        {
            var candidate = GetCompleteTestCandidateCommand();

            await _controller.Create(candidate);

            _mockMediator.Verify(x => x.Send(candidate,
                 It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async void Create_ActionExecuted_RedirectsToIndexAction()
        {
            var candidate = GetCompleteTestCandidateCommand();
            var result = await _controller.Create(candidate);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("Index", redirectToActionResult.ActionName);
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

        private CreateCandidateCommand GetCompleteTestCandidateCommand()
        {
            return new CreateCandidateCommand
            {
                Name = "Prueba",
                Surname = "Pruebas",
                Email = "prueba@pruebas.com",
                Birthdate = new DateTime(1994, 7, 2)
            };
        }

        private CreateCandidateCommand GetIncompleteTestCandidateCommand()
        {
            return new CreateCandidateCommand
            {
                Surname = "Pruebas",
                Email = "prueba@pruebas.com"
            };
        }

        private void AddModelError()
        {
            _controller.ModelState.AddModelError("Name", "Name is required");
        }
    }
}

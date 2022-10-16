using Candidates.Application.Commands.Candidates;
using Candidates.Application.Queries;
using Candidates.Domain.Entities;
using Candidates.Domain.Interfaces.Candidates;
using Candidates.Web.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
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
        public async void Create_InvalidModelState_ReturnsView()
        {
            _controller.ModelState.AddModelError("Name", "Name is required");

            var candidate = new CreateCandidateCommand { Surname = "Pruebas", Email = "prueba@pruebas.com" };
            var result = await _controller.Create(candidate);
            var viewResult = Assert.IsType<ViewResult>(result);
            var testCandidate= Assert.IsType<CreateCandidateCommand>(viewResult.Model);

            Assert.Equal(candidate.Surname, testCandidate.Surname);
            Assert.Equal(candidate.Email, testCandidate.Email);
        }

        [Fact]
        public async void Create_InvalidModelState_MediatorSendNeverExecutes()
        {
            _controller.ModelState.AddModelError("Name", "Name is required");

            var candidate = new CreateCandidateCommand { Surname = "Pruebas", Email = "prueba@pruebas.com" };

            await _controller.Create(candidate);

            _mockMediator.Verify(x => x.Send(candidate,
                It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async void Create_ModelStateValid_CreateEmployeeCalledOnce()
        {
            //CreateCandidateCommand? cand = null;
            //_mockMediator.Setup(r => r.Send(It.IsAny<CreateCandidateCommand>(), It.IsAny<CancellationToken>()))
            //    .Callback<CreateCandidateCommand>(c => cand = c);

            var candidate = new CreateCandidateCommand { Name = "Prueba", Surname = "Pruebas", Email = "prueba@pruebas.com", Birthdate = new System.DateTime(1994, 7, 2) };

            await _controller.Create(candidate);

            _mockMediator.Verify(x => x.Send(candidate,
                 It.IsAny<CancellationToken>()), Times.Once);
            //Assert.Equal(cand.Name, candidate.Name);
            //Assert.Equal(cand.Surname, candidate.Surname);
            //Assert.Equal(cand.Email, candidate.Email);
            //Assert.Equal(cand.Birthdate, candidate.Birthdate);
        }

        //[Fact]
        //public async void Index_ReturnsAViewResult_WithAListOfCandidates()
        //{
        //    var mockMediator = new Mock<IMediator>();

        //    mockMediator.Setup(x => x.Send(new GetAllCandidatesQuery(),
        //        It.IsAny<CancellationToken>())).ReturnsAsync(GetTestCandidates());

        //    var controller = new CandidatesController(mockMediator.Object);
        //    var result = await controller.Index();
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    var model = Assert.IsAssignableFrom<Candidate[]>(
        //        viewResult.ViewData.Model);

        //    Assert.Equal(2, model.Count());
        //}

        //private List<Candidate> GetTestCandidates()
        //{
        //    return new List<Candidate>()
        //    {
        //        new Candidate()
        //        {
        //            IdCandidate = 1,
        //            Name = "Antonio"
        //        },
        //        new Candidate()
        //        {
        //            IdCandidate = 2,
        //            Name = "Juan"
        //        }
        //    };
        //}
    }
}

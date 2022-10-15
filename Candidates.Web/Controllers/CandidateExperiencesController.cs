using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Candidates.Application.Queries.CandidateExperiences;
using Candidates.Application.Commands.CandidateExperiences;
using Candidates.Application.Queries.Candidates;
using Microsoft.AspNetCore.Mvc.Rendering;
using Candidates.Application.Queries;

namespace Candidates.Web.Controllers
{
    public class CandidateExperiencesController : Controller
    {
        private readonly IMediator _mediator;

        public CandidateExperiencesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: CandidateExperiences
        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllCandidateExperiencesQuery()));
        }

        // GET: CandidateExperiences/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var experience = await _mediator.Send(new GetCandidateExperienceQuery(id));

            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        // GET: CandidateExperiences/Create
        public async Task<IActionResult> Create()
        {
            ViewData["IdCandidate"] = new SelectList(await _mediator.Send(new GetAllCandidatesQuery()), 
                "IdCandidate", "Email");

            return View();
        }

        // POST: CandidateExperiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCandidateExperienceCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            return View(command);
        }

        // GET: CandidateExperiences/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["IdCandidate"] = new SelectList(await _mediator.Send(new GetAllCandidatesQuery()),
               "IdCandidate", "Email");

            var experience = await _mediator.Send(new GetCandidateExperienceQuery(id));

            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        // POST: CandidateExperiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateCandidateExperienceCommand command)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.Send(command);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!CandidateExists(candidate.IdCandidate))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        // GET: CandidateExperiences/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var experience = await _mediator.Send(new GetCandidateExperienceQuery(id));

            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        // POST: CandidateExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidate = await _mediator.Send(new GetCandidateExperienceQuery(id));

            if (candidate != null)
            {
                await _mediator.Send(new DeleteCandidateExperienceCommand(id));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Candidates.Application.Queries.Candidates;
using Candidates.Application.Commands.Candidates;
using Candidates.Application.Queries;

namespace Candidates.Web.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly IMediator _mediator;

        public CandidatesController(IMediator mediator)
        {
            _mediator = mediator;
        }     

        // GET: Candidates
        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllCandidatesQuery()));
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var candidate = await _mediator.Send(new GetCandidateQuery(id));

            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCandidateCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            return View(command);
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var candidate = await _mediator.Send(new GetCandidateQuery(id));

            if (candidate == null)
            {
                return NotFound();
            }           
          
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateCandidateCommand command)
        {            
            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.Send(command);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CandidateExists(command.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var candidate = await _mediator.Send(new GetCandidateQuery(id));

            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidate = await _mediator.Send(new GetCandidateQuery(id));

            if (candidate != null)
            {
                await _mediator.Send(new DeleteCandidateCommand(id));
            }
            
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CandidateExists(int id)
        {
            var candidate = await _mediator.Send(new GetCandidateQuery(id));

            return candidate != null;
        }
    }
}

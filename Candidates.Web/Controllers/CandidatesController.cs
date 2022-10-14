using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Candidates.Domain.Entities;
using Candidates.Application.Services.Interfaces;

namespace Candidates.Web.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ICandidatesService candidatesService;

        public CandidatesController(ICandidatesService candidatesService)
        {
            this.candidatesService = candidatesService;
        }     

        // GET: Candidates
        public async Task<IActionResult> Index()
        {
            return View(await candidatesService.GetAllCandidates());
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var candidate = await candidatesService.GetCandidate(id);
                
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
        public async Task<IActionResult> Create([Bind("IdCandidate,Name,Surname,Birthdate,Email,InsertDate,ModifyDate")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                await candidatesService.CreateCandidate(candidate);
                return RedirectToAction(nameof(Index));
            }
            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var candidate = await candidatesService.GetCandidate(id);

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
        public async Task<IActionResult> Edit(int id, [Bind("IdCandidate,Name,Surname,Birthdate,Email,InsertDate,ModifyDate")] Candidate candidate)
        {
            if (id != candidate.IdCandidate)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await candidatesService.UpdateCandidate(candidate);
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
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var candidate = await candidatesService.GetCandidate(id);

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
            var candidate = await candidatesService.GetCandidate(id);

            if (candidate != null)
            {
                await candidatesService.DeleteCandidate(candidate);
            }
            
            return RedirectToAction(nameof(Index));
        }        
    }
}

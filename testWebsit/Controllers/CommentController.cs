using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testWebsit.Data;
using testWebsit.Models;

namespace testWebsit.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentDbContext _context;
        public CommentController(CommentDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comments.ToListAsync());
        }

        public async Task<IActionResult> Replay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Comment = await _context.Comments.FirstOrDefaultAsync(r => r.Id == id);
            if (Comment == null)
            {
                return NotFound();
            }
            return View(Comment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Replay(int? id,string ReplayText)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Comment = await _context.Comments.FirstOrDefaultAsync(r => r.Id == id);
            Comment.ReplayText = ReplayText;

            if (ModelState.IsValid)
            {

                    
                try
                {
                    _context.Update(Comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!CommentsExists(Comment.Id))
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
            return View(Comment);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Comment = await _context.Comments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Comment == null)
            {
                return NotFound();
            }
            return View(Comment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tittel,Text,Status,Rating,ReplayText")] Comments comments)
        {
            if (id != comments.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!CommentsExists(comments.Id))
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
            return View(comments);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tittel,Text,Status,Rating")] Comments comments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comments);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Comment = await _context.Comments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Comment == null)
            {
                return NotFound();
            }
            return View(Comment);
        }
        public async Task<IActionResult> Deleted(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var comments = await _context.Comments.FirstOrDefaultAsync(d => d.Id == id);
            if (comments == null)
            {
                return NotFound();
            }
            return View(comments);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deleted(int id)
        {
            var Comments = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(Comments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool CommentsExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}

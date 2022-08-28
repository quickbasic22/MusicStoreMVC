using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStoreMVC.Data;
using MusicStoreMVC.Models;
using MusicStoreMVC.ViewModels;

namespace MusicStoreMVC.Controllers
{
    public class AlbumArtistViewModelsController : Controller
    {
        private readonly MusicStoreMVCContext _context;

        public AlbumArtistViewModelsController(MusicStoreMVCContext context)
        {
            _context = context;
        }

        // GET: AlbumArtistViewModels
        public async Task<IActionResult> Index()
        {
            List<Artist> artist = _context.Artist.ToList();
            List<Album> albums = _context.Album.ToList();
            List<Genre> genres = _context.Genre.ToList();
            AlbumArtistViewModel[] vm = new AlbumArtistViewModel[albums.Count];
            int itemNumber = 0;
            foreach (Album album in albums)
            {
                vm[itemNumber] = new AlbumArtistViewModel();
                itemNumber++;
            }
          
              return _context.AlbumArtistViewModel != null ? 
                          View(await _context.AlbumArtistViewModel.ToListAsync()) :
                          Problem("Entity set 'MusicStoreMVCContext.AlbumArtistViewModel'  is null.");
        }

        // GET: AlbumArtistViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AlbumArtistViewModel == null)
            {
                return NotFound();
            }

            var albumArtistViewModel = await _context.AlbumArtistViewModel
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (albumArtistViewModel == null)
            {
                return NotFound();
            }

            return View(albumArtistViewModel);
        }

        // GET: AlbumArtistViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlbumArtistViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl,ArtistName,GenreName,GenreDescription")] AlbumArtistViewModel albumArtistViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(albumArtistViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(albumArtistViewModel);
        }

        // GET: AlbumArtistViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AlbumArtistViewModel == null)
            {
                return NotFound();
            }

            var albumArtistViewModel = await _context.AlbumArtistViewModel.FindAsync(id);
            if (albumArtistViewModel == null)
            {
                return NotFound();
            }
            return View(albumArtistViewModel);
        }

        // POST: AlbumArtistViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl,ArtistName,GenreName,GenreDescription")] AlbumArtistViewModel albumArtistViewModel)
        {
            if (id != albumArtistViewModel.AlbumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(albumArtistViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumArtistViewModelExists(albumArtistViewModel.AlbumId))
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
            return View(albumArtistViewModel);
        }

        // GET: AlbumArtistViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AlbumArtistViewModel == null)
            {
                return NotFound();
            }

            var albumArtistViewModel = await _context.AlbumArtistViewModel
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (albumArtistViewModel == null)
            {
                return NotFound();
            }

            return View(albumArtistViewModel);
        }

        // POST: AlbumArtistViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AlbumArtistViewModel == null)
            {
                return Problem("Entity set 'MusicStoreMVCContext.AlbumArtistViewModel'  is null.");
            }
            var albumArtistViewModel = await _context.AlbumArtistViewModel.FindAsync(id);
            if (albumArtistViewModel != null)
            {
                _context.AlbumArtistViewModel.Remove(albumArtistViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumArtistViewModelExists(int id)
        {
          return (_context.AlbumArtistViewModel?.Any(e => e.AlbumId == id)).GetValueOrDefault();
        }
    }
}

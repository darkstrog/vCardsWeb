using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using vCardsWeb.Models;
using vCardsWeb.Models.Repository;
using System.Security.Claims;

namespace vCardsWeb.Controllers
{
    public class vCardAlbumsController : Controller
    {
        IvCardAlbumRepository AlbumRepository;
        IvCardsRepository CardsRepository;
        public vCardAlbumsController(IvCardAlbumRepository _album, IvCardsRepository _cards)
        {
            AlbumRepository = _album;
            CardsRepository = _cards;
        }
        // GET: vCardAlbumsController
        [Authorize]
        public async Task<IEnumerable<vCardsAlbum>> GetvCardsAlbums()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);/// получаем id авторизованного пользователя
            var albums = await AlbumRepository.GetAlbums(userId);
            return albums.ToList();
        }

        // GET: vCardAlbumsController/Details/5
        [Authorize]
        public async Task<IEnumerable<vCardContainer>> GetCardsFromAlbum(int id)
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var cards = await CardsRepository.GetCards(id);
            return null;
        }

        // GET: vCardAlbumsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vCardAlbumsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(GetvCardsAlbums));
            }
            catch
            {
                return View();
            }
        }

        // GET: vCardAlbumsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: vCardAlbumsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(GetvCardsAlbums));
            }
            catch
            {
                return View();
            }
        }

        // GET: vCardAlbumsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: vCardAlbumsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(GetvCardsAlbums));
            }
            catch
            {
                return View();
            }
        }
    }
}

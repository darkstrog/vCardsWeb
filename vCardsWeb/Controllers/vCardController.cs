using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using vCardsWeb.Models;
using vCardsWeb.Models.Repository;

namespace vCardsWeb.Controllers
{
    public class vCardController : Controller
    {
        IvCardsRepository vCardsRepo;
        public vCardController(IvCardsRepository _vCardsRepo)
        {
            vCardsRepo = _vCardsRepo;
        }
        // GET: vCardController
        [Authorize]
        public async Task<ActionResult>GetCardsList()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);/// получаем id авторизованного пользователя
            var CardsList = await vCardsRepo.GetCards(userId);
            return View(CardsList);
        }

        // GET: vCardController/Details/5
        [Authorize]
        public async Task<ActionResult> CardDetails(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var CardDetail = await vCardsRepo.GetCardDetail(userId,id);
            //здесь надо конвертануть в vcard и отдать во фронт
            return View(CardDetail);
        }

        // GET: vCardController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vCardController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: vCardController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: vCardController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: vCardController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: vCardController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

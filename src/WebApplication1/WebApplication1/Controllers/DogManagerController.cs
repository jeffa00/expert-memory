using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class DogManagerController : Controller
    {
        private readonly IDogRepository _dogRepo;

        public DogManagerController(IDogRepository dogRepo)
        {
            _dogRepo = dogRepo;
        }

        // GET: DogManager
        public IActionResult Index()
        {
            return View(_dogRepo.ListAll());
        }

        // GET: DogManager/Details/5
        public IActionResult Details(int id)
        {
            return View(_dogRepo.GetById(id));
        }

        // GET: DogManager/Create
        public IActionResult Create()
        {
            return View(new Dog());
        }

        // POST: DogManager/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Dog newDog)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dogRepo.Add(newDog);

                    return RedirectToAction(nameof(Index));
                } 

                return View(newDog);
            }
            catch
            {
                return View(newDog);
            }
        }

        // GET: DogManager/Edit/5
        public IActionResult Edit(int id)
        {
            return View(_dogRepo.GetById(id));
        }

        // POST: DogManager/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Dog editedDog)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dogRepo.Edit(editedDog);

                    return RedirectToAction(nameof(Index));
                }

                return View(editedDog);
            }
            catch
            {
                return View(editedDog);
            }
        }

        // GET: DogManager/Delete/5
        public IActionResult Delete(int id)
        {
            return View(_dogRepo.GetById(id));
        }

        // POST: DogManager/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Dog dogToDelete)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dogRepo.Delete(dogToDelete);

                    return RedirectToAction(nameof(Index));
                }

                return View(dogToDelete);
            }
            catch
            {
                return View(dogToDelete);
            }
        }
    }
}
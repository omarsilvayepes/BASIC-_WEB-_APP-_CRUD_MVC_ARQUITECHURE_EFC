﻿using Microsoft.AspNetCore.Mvc;
using WebApp.DataAcces.Repository.IRepository;
using WebAppMVCArquitecture.Models;

namespace WebAppMVCArquitecture.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public  IActionResult Index()
        {
            List<Category> listCategories =_categoryRepository.GetAll().Result.ToList();
            return View(listCategories);
        }

        public IActionResult Create() // for show the view to the user 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category) // for save changes in DB
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Name Can Not exactly match with the Display Order Field");
            }
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(category);
                _categoryRepository.Save();
                TempData["Success"] = "Create Succesfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Edit(int? id) // for show the view to the user
        {
            if (id == null || id == 0) return NotFound();

            Category? categoryDb = _categoryRepository.Get(c=> c.Id == id).Result;
            if (categoryDb == null) return NotFound();

            return View(categoryDb);
        }

        [HttpPost]
        public IActionResult Edit(Category category) // for save changes in DB
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(category);
                _categoryRepository.Save();
                TempData["Success"] = "Updated Succesfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Delete(int? id) // for show the view to the user
        {
            if (id == null || id == 0) return NotFound();

            Category? categoryDb = _categoryRepository.Get(c => c.Id == id).Result;
            if (categoryDb == null) return NotFound();

            return View(categoryDb);
        }

        [HttpPost]
        public IActionResult Delete(Category category) // for save changes in DB
        {
            _categoryRepository.Remove(category);
            _categoryRepository.Save();
            TempData["Success"] = "Deleted Succesfully";
            return RedirectToAction("Index", "Category");
        }

    }
}

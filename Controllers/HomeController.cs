using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Crud.Models;

namespace Crud.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context { get; set; }
    
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish> Dishes = _context.Dishs.OrderByDescending( l => l.CreatedAt).ToList();
            return View(Dishes);
        }

        [HttpGet("add")]
        public IActionResult Add()
        {;
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Dish newD)
        {
            if(ModelState.IsValid)
            {
                _context.Dishs.Add(newD);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Add");
            }
        }
        
        [HttpGet("{DishId}")]
        public IActionResult ShowDish(int DishId)
        {
            Dish show = _context.Dishs.FirstOrDefault( l => l.DishID == DishId );
            return View(show);
        }
        

        [HttpGet("edit/{DishId}")]
        public IActionResult Edit(int DishId)
        {
            Dish edit = _context.Dishs.FirstOrDefault( l => l.DishID == DishId );
            return View(edit);
        }

        [HttpPost("update/{DishId}")]
        public IActionResult Update(int DishId, Dish update)
        {
            Dish retrieved = _context.Dishs.FirstOrDefault( l => l.DishID == DishId );
            
            if(ModelState.IsValid)
            {
                retrieved.Name = update.Name;
                retrieved.Chef = update.Chef;
                retrieved.Calories = update.Calories;
                retrieved.Tastiness = update.Tastiness;
                retrieved.Description = update.Description;
                retrieved.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return Redirect($"/{@DishId}");
            }
            else
            {
                return View("Edit", update);
            }
        }

        [HttpGet("delete/{DishId}")]
        public IActionResult Delete(int DishId)
        {
            Dish distroy = _context.Dishs.FirstOrDefault( l => l.DishID == DishId );
            _context.Dishs.Remove(distroy);
            _context.SaveChanges();
            return Redirect("/");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

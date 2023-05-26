using LaMiaPizzeria.Database;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Composition;

namespace LaMiaPizzeria.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> ourPizza = db.Pizzas.ToList();
                return View(ourPizza);
            }
        }


        public IActionResult Details(int id)
        {
            using (PizzaContext db = new PizzaContext())

            {
                Pizza? pizzaDetails = db.Pizzas.Where(Pizza => Pizza.Id == id).Include(Pizza => Pizza.Category).FirstOrDefault(); 



                if (pizzaDetails != null)
                {
                    return View("Details", pizzaDetails);
                }
                else
                {
                    return NotFound($"L'articolo con id {id} non è stato trovato!");
                }



            }

        }


        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult Create()
        {
           using (PizzaContext db = new PizzaContext())
            {
                List<PizzaCategory> pizzaCategory = db.PizzaCategories.ToList();

                PizzaModelForViews model = new PizzaModelForViews();
                model.Pizzaa = new Pizza();
                model.PizzaCategories = pizzaCategory;


               return View("Create", model);
            }
        }



        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaModelForViews data)
        {
            if (!ModelState.IsValid)
            {
                using (PizzaContext db = new PizzaContext())
                {
                    List<PizzaCategory> pizzaCategories = db.PizzaCategories.ToList();
                    data.PizzaCategories = pizzaCategories;

                    return View("Create", data);
                }



            }

            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizzaToCreate = new Pizza();
                pizzaToCreate.Name = data.Pizzaa.Name;
                pizzaToCreate.Description = data.Pizzaa.Description;
                pizzaToCreate.Image = data.Pizzaa.Image;
                pizzaToCreate.Price = data.Pizzaa.Price;

                pizzaToCreate.PizzaCategoryId = data.Pizzaa.PizzaCategoryId;

                // impostiamo lo sport preferito dell'utente

                db.Pizzas.Add(pizzaToCreate);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

        }


        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizzaToUpdate = db.Pizzas.Where(Pizza => Pizza.Id == id).FirstOrDefault();
                if (pizzaToUpdate == null)
                {
                    return NotFound();
                }
                else
                {
                    List<PizzaCategory> pizzeCategorie = db.PizzaCategories.ToList();
                    PizzaModelForViews model = new PizzaModelForViews();
                    model.Pizzaa = pizzaToUpdate;
                    model.PizzaCategories = pizzeCategorie;
                    return View(model);
                }
            }
        }


        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaModelForViews data)
        {
            if (!ModelState.IsValid)
            {
                using (PizzaContext db = new PizzaContext())
                {
                    List<PizzaCategory> sports = db.PizzaCategories.ToList();
                    data.PizzaCategories = sports;
                    return View("Update", data);
                }
            }
            using (PizzaContext context = new PizzaContext())
            {
                Pizza? pizzaToEdit = context.Pizzas.Where(pizzas => pizzas.Id == id).FirstOrDefault();
                if (pizzaToEdit != null)
                {
                    pizzaToEdit.Name = data.Pizzaa.Name;
                    pizzaToEdit.Description = data.Pizzaa.Description;
                    pizzaToEdit.Image = data.Pizzaa.Image;
                    pizzaToEdit.PizzaCategoryId = data.Pizzaa.PizzaCategoryId;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
        }


        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using(PizzaContext db = new PizzaContext())
            {
                Pizza? pizzaToDelete = db.Pizzas.Where(Pizza =>  Pizza.Id == id).FirstOrDefault();
                if(pizzaToDelete != null)
                {
                    db.Remove(pizzaToDelete);
                    db.SaveChanges();   

                    return RedirectToAction("Index");
                }else 
                { 
                    return NotFound("non ho trovato la pizza da eliminare");
                } 
               }
            }
        }
        
        
        
        
        
                                         
    }




















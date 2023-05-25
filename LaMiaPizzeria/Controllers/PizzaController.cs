using LaMiaPizzeria.Database;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;




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
                Pizza? pizzaDetails = db.Pizzas.Where(article => article.Id == id).FirstOrDefault();


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

            using (PizzaContext context = new PizzaContext())
            {
                Pizza pizzaToCreate = new Pizza();
                pizzaToCreate.Name = data.Pizzaa.Name;
                pizzaToCreate.Description = data.Pizzaa.Description;
                pizzaToCreate.Image = data.Pizzaa.Image;
                pizzaToCreate.Price = data.Pizzaa.Price;

                pizzaToCreate.Id = data.Pizzaa.Id;

                // impostiamo lo sport preferito dell'utente

                context.Pizzas.Add(pizzaToCreate);
                context.SaveChanges();
                return RedirectToAction("Index");

            }

        }

      
        [HttpGet]

        public IActionResult Update(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza? pizzaToModify = db.Pizzas.Where(Pizza => Pizza.Id == id).FirstOrDefault();
                if (pizzaToModify != null)
                {

                    return View("Update", pizzaToModify);

                }
                else
                {
                    return NotFound($"L'articolo con id {id} non è stato trovato!");


                }





            }
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Pizza newPizza)
        {
            if (ModelState.IsValid)
            {
                return View("Update", newPizza);
            }

            using (PizzaContext db = new PizzaContext())
            {
                Pizza? pizzaToModify = db.Pizzas.Where(Pizza => Pizza.Id == id).FirstOrDefault();

                if (pizzaToModify != null)
                {
                    pizzaToModify.Name = newPizza.Name;
                    pizzaToModify.Image = newPizza.Image;
                    pizzaToModify.Price = newPizza.Price;
                    pizzaToModify.Description = newPizza.Description;

                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound(" La pizza da modificare non esiste!");
                }


            }

        }
      
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




















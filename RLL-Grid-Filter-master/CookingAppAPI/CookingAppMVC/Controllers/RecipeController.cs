using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using CookingAppMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace CookingAppMVC.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class RecipeController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5006/api");
        HttpClient client;

        public RecipeController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public ActionResult Index()
        {
            List<Recipe> recipes = new List<Recipe>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Recipes").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                recipes = JsonConvert.DeserializeObject<List<Recipe>>(data);
            }
            return View(recipes);
        }
        [HttpGet("IndexFiltered")]
        public ActionResult Index(string searchString)
        {
            List<Recipe> recipes = new List<Recipe>();
            HttpResponseMessage response;

            if (!string.IsNullOrEmpty(searchString))
            {
                response = client.GetAsync(client.BaseAddress + $"/Recipes?searchString={searchString}").Result;
            }
            else
            {
                response = client.GetAsync(client.BaseAddress + "/Recipes").Result;
            }

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                recipes = JsonConvert.DeserializeObject<List<Recipe>>(data);
            }
            return View(recipes);
        }


        public ActionResult Create()
        {
            Recipe recipe = new Recipe();
            return View(recipe);
        }


        [HttpPost]
        public ActionResult Create(Recipe recipes)
        {
            string data = JsonConvert.SerializeObject(recipes);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responce = client.PostAsync(client.BaseAddress + "/Recipes", content).Result;
            if (responce.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Recipe recipes = new Recipe();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Recipes/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                recipes = JsonConvert.DeserializeObject<Recipe>(data);
            }
            return View(recipes);
        }

        [HttpPost]
        public ActionResult Edit(Recipe recipe)
        {
            try
            {
                string data = JsonConvert.SerializeObject(recipe);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/Recipes/" + recipe.Id, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error updating Recipe.");
                    return View(recipe);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred: " + ex.Message);
                return View(recipe);
            }
        }
        public ActionResult Details(int id)
        {
            Recipe recipe = new Recipe();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Recipes/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                recipe = JsonConvert.DeserializeObject<Recipe>(data);

                ViewBag.Category = recipe.Category;
                ViewBag.SubmissionDate = recipe.SubmissionDate.ToShortDateString();
            }
            else
            {

                ViewBag.ErrorMessage = "Failed to retrieve recipe details. Please try again later.";

            }
            ViewBag.ImageURL = recipe.ImageUrl;

            return View(recipe);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            Recipe recipes = new Recipe();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Recipes/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                recipes = JsonConvert.DeserializeObject<Recipe>(data);
            }
            return View(recipes);
        }

        [HttpPost]
        public ActionResult Delete(Recipe recipes)
        {
            string data = JsonConvert.SerializeObject(recipes);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Recipes/" + recipes.Id).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet("Sort")]
        public IActionResult Sort(string sortOrder)
        {
            List<Recipe> recipes = new List<Recipe>();
            IActionResult indexActionResult = Index();
            if (indexActionResult is ViewResult indexViewResult)
            {
                if (indexViewResult.Model is List<Recipe> allRecipes)
                { 
                    switch (sortOrder)
                    {
                        case "A to Z":
                            recipes = allRecipes.OrderBy(r => r.Name).ToList();
                            break;
                        case "Z to A":
                            recipes = allRecipes.OrderByDescending(r => r.Name).ToList();
                            break;
                        case "Featured":
                            recipes = allRecipes.OrderBy(r => r.Id).ToList();
                            break;
                        default:
                            recipes = allRecipes.OrderBy(r => r.Id).ToList();
                            break;
                    }
                }
            }

            return PartialView("Sort", recipes);
        }

    }
}




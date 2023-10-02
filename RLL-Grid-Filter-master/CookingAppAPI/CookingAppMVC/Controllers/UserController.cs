using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using CookingAppMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace CookingAppMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5006/api");
        HttpClient client;

        public UserController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public ActionResult Index()
        {
            List<User> users = new List<User>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Users").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<User>>(data);
            }
            return View(users);
        }

        public ActionResult Create()
        {
            User user = new User();
            return View(user);
        }


        [HttpPost]
        public ActionResult Create(User users)
        {
            string data = JsonConvert.SerializeObject(users);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responce = client.PostAsync(client.BaseAddress + "/Users", content).Result;
            if (responce.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            User users = new User();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Users/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<User>(data);
            }
            return View(users);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                string data = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/Users/" + user.UserId, content).Result;

                // Log the response status code for debugging
                Console.WriteLine("Response Status Code: " + response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    // Handle errors or log them
                    ModelState.AddModelError(string.Empty, "Error updating User. Status Code: " + response.StatusCode);
                    return View(user);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred: " + ex.Message);
                return View(user);
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            User user = new User();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Users/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(data);
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            User users = new User();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Users/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<User>(data);
            }
            return View(users);
        }

        [HttpPost]
        public ActionResult Delete(User users)
        {
            string data = JsonConvert.SerializeObject(users);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Users/" + users.UserId).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

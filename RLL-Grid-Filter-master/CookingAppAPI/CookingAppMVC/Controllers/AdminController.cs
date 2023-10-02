using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CookingAppMVC.Models;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CookingAppMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5006/api");
        HttpClient client;

        public AdminController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public ActionResult Index()
        {
            List<Admin> admins = new List<Admin>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Admins").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                admins = JsonConvert.DeserializeObject<List<Admin>>(data);
            }
            return View(admins);
        }

        public ActionResult Create()
        {
            Admin admin = new Admin();
            return View(admin);
        }


        [HttpPost]
        public ActionResult Create(Admin admins)
        {
            string data = JsonConvert.SerializeObject(admins);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responce = client.PostAsync(client.BaseAddress + "/Admins", content).Result;
            if (responce.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Admin admins = new Admin();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Admins/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                admins = JsonConvert.DeserializeObject<Admin>(data);
            }
            return View(admins);
        }

        [HttpPost]
        public ActionResult Edit(Admin admin)
        {
            try
            {
                string data = JsonConvert.SerializeObject(admin);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/Admins/" + admin.AdminId, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error updating admin.");
                    return View(admin);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred: " + ex.Message);
                return View(admin);
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Admin admin = new Admin();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Admins/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                admin = JsonConvert.DeserializeObject<Admin>(data);
            }
            return View(admin);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Admin admins = new Admin();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Admins/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                admins = JsonConvert.DeserializeObject<Admin>(data);
            }
            return View(admins);
        }

        [HttpPost]
        public ActionResult Delete(Admin admins)
        {
            string data = JsonConvert.SerializeObject(admins);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Admins/" + admins.AdminId).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

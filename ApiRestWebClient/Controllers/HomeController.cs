using ApiRestWebClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Web;

//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.Extensions;

namespace ApiRestWebClient.Controllers
{
    public class HomeController : Controller
    {

        private readonly IConfiguration _conf_json;

        public HomeController (IConfiguration configuration) {
            _conf_json = configuration;
        }

        // GET: HomeController
        public ActionResult Listar(string sort, string search, int page)
      //public async Task<List<Employee>> Listar()
        {


            //var JWT = (GenerateJWT(login)).ToString().Replace("\"", "");

            /*
            var Task = GenerateJWT(login);
            var result = await Task;
            var JWT = result;
            */

            var JWT = GenerateJWT().Result.ToString().Replace("\"", "");

            HttpClient client = new HttpClient();
            string path_base = _conf_json["ApiUrlBase"];
            string path_api = "Listar";
            client.BaseAddress = new Uri(path_base);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWT);
            var response = client.GetAsync(path_api).Result;
            var response_str = client.GetStringAsync(path_api).Result;
            var employee = JsonConvert.DeserializeObject<List<Employee>>(response_str);

            if (!String.IsNullOrEmpty(search))
            {
                employee = employee.Where(e => e.Nombre.ToUpper().Contains(search.ToUpper())).ToList();
            }

            switch (sort)  
             {
                case "Id":       employee = employee.OrderBy(e => e.Id).ToList();       break;
                case "Nombre":   employee = employee.OrderBy(e => e.Nombre).ToList();   break;
                case "DNI":      employee = employee.OrderBy(e => e.DNI).ToList();      break;
                case "Edad":     employee = employee.OrderBy(e => e.Edad).ToList();     break;
                case "Telefono": employee = employee.OrderBy(e => e.Telefono).ToList(); break;
                case "Correo":   employee = employee.OrderBy(e => e.Correo).ToList();   break;
                case "Basico":   employee = employee.OrderBy(e => e.Basico).ToList();   break;
                case "Ingreso":  employee = employee.OrderBy(e => e.Ingreso).ToList();  break;
                case "Activo":   employee = employee.OrderBy(e => e.Activo).ToList();   break;
                default:         employee = employee.OrderBy(e => e.Id).ToList();       break;
            }


            /*
            List <Employee> employee = new();
            employee.Add(new Employee { Id = 41, Nombre = "AMBAR 1", DNI = "123456", Edad = 12, Activo = true, Basico = 1200, Correo = "ambar@gmail.com", Ingreso = new DateTime(2023, 03, 20, 15, 12, 52), Telefono = "98765431" });
            employee.Add(new Employee { Id = 42, Nombre = "AMBAR 2", DNI = "123456", Edad = 12, Activo = true, Basico = 1200, Correo = "ambar@gmail.com", Ingreso = new DateTime(2023, 03, 21, 15, 12, 52), Telefono = "98765431" });
            employee.Add(new Employee { Id = 43, Nombre = "AMBAR 3", DNI = "123456", Edad = 12, Activo = true, Basico = 1200, Correo = "ambar@gmail.com", Ingreso = new DateTime(2023, 03, 22, 15, 12, 52), Telefono = "98765431" });
            employee.Add(new Employee { Id = 44, Nombre = "AMBAR 4", DNI = "123456", Edad = 12, Activo = true, Basico = 1200, Correo = "ambar@gmail.com", Ingreso = new DateTime(2023, 03, 23, 15, 12, 52), Telefono = "98765431" });
            employee.Add(new Employee { Nombre = JWT });
            */

            return View(employee);


        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create(string returnUrl)
        {

            Employee employee = new() { Nombre = "", DNI = "", Edad = 0, Activo = null, Basico = 0, Correo = "", Ingreso = DateTime.Now, Telefono = "" } ;

            //returnUrl = "Listar" + "/"; // + Context.Request.QueryString;
            //ViewBag.ReturnUrl = returnUrl;

            ViewBag.ReturnUrl = returnUrl;

            return View(employee);

        }

        // POST: HomeController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Employee empleado, string returnUrl)
        {

            var JWT = GenerateJWT().Result.ToString().Replace("\"", "");

            HttpClient client = new HttpClient();
            string path_base = _conf_json["ApiUrlBase"];
            string path_api = "Adicionar";
            client.BaseAddress = new Uri(path_base);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWT);

            string jsonString = System.Text.Json.JsonSerializer.Serialize(empleado);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = client.PostAsync(path_api, content).Result;
            var response_str = response.Content.ReadAsStringAsync().Result;

            try
            {
                //ViewBag.ReturnUrl = returnUrl;
                //return RedirectToAction("Listar");

                return Redirect(returnUrl);
            }
            catch
            {
                return View(empleado);
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id, string returnUrl)
        {
            var JWT = GenerateJWT().Result.ToString().Replace("\"", "");

            HttpClient client = new HttpClient();
            string path_base = _conf_json["ApiUrlBase"];
            string path_api = "Leer";
            client.BaseAddress = new Uri(path_base);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWT);
            var response = client.GetAsync(path_api+"?Id="+id.ToString()).Result;
            var response_str = client.GetStringAsync(path_api + "?Id=" + id.ToString()).Result;
            var employee = JsonConvert.DeserializeObject<Employee>(response_str);

            /*
            Employee employee = new() { Id = 43, Nombre = "AMBAR 3", DNI = "123456", Edad = 12, Activo = true, Basico = 1200, Correo = "ambar@gmail.com", Ingreso = new DateTime(2023, 03, 22, 15, 12, 52), Telefono = "98765431" } ;
            */

            ViewBag.ReturnUrl = returnUrl;

            return View(employee);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        // [ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection empleado)
        public ActionResult Edit(Employee empleado, string returnUrl)
        {

            var JWT = GenerateJWT().Result.ToString().Replace("\"", "");

            HttpClient client = new HttpClient();
            string path_base = _conf_json["ApiUrlBase"];
            string path_api = "Editar";
            client.BaseAddress = new Uri(path_base);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWT);

            string jsonString = System.Text.Json.JsonSerializer.Serialize(empleado);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = client.PutAsync(path_api, content).Result;
            var response_str = response.Content.ReadAsStringAsync().Result;
            

            try
            {
                //return RedirectToAction("Listar");
                //return RedirectToAction(Uri.UnescapeDataString(returnUrl));

                //string decodedUrl = HttpUtility.UrlDecode(returnUrl);
                //return Redirect(decodedUrl);

                return Redirect(returnUrl);

            }
            catch
            {
                return View(empleado);
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id, string returnUrl)
        {
            var JWT = GenerateJWT().Result.ToString().Replace("\"", "");

            HttpClient client = new HttpClient();
            string path_base = _conf_json["ApiUrlBase"];
            string path_api = "Leer";
            client.BaseAddress = new Uri(path_base);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWT);
            var response = client.GetAsync(path_api + "?Id=" + id.ToString()).Result;
            var response_str = client.GetStringAsync(path_api + "?Id=" + id.ToString()).Result;
            var employee = JsonConvert.DeserializeObject<Employee>(response_str);

            ViewBag.ReturnUrl = returnUrl;

            return View(employee);

        }

        // POST: HomeController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(Employee empleado, string returnUrl)
        {
            var JWT = GenerateJWT().Result.ToString().Replace("\"", "");

            HttpClient client = new HttpClient();
            string path_base = _conf_json["ApiUrlBase"];
            string path_api = "Remover";
            client.BaseAddress = new Uri(path_base);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWT);

            var response = client.DeleteAsync(path_api+"?id="+empleado.Id.ToString()).Result;
            var response_str = response.Content.ReadAsStringAsync().Result;

            try
            {
                //return RedirectToAction("Listar");
                return Redirect(returnUrl);
            }
            catch
            {
                return View(empleado);
            }

        }

      //async Task<string> GenerateJWT(Login login)
        async Task<string> GenerateJWT()
        {
            Login login = new();
            login.Username = "Elmer";
            login.Password = "Pass123";

            HttpClient client = new HttpClient();
            string path_base = _conf_json["ApiUrlSecure"];
            string path_api = "AuthToken";
            var payload = "{\"username\": \"" + login.Username + "\",\"password\": \"" + login.Password + "\"}";
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri(path_base);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsync(path_api, content);
            var response_str = await response.Content.ReadAsStringAsync();
            return response_str;
        }

    }

}

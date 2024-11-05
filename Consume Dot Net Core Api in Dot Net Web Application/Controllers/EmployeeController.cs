using Consume_Dot_Net_Core_Api_in_Dot_Net_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Consume_Dot_Net_Core_Api_in_Dot_Net_Web_Application.Controllers
{
    public class EmployeeController : Controller
    {
       private string url = "https://localhost:7056/api/Student";
       private HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode) 
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Employee>>(result);
                if (data != null) 
                {
                    employees = data;
                }
            }
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            string data = JsonConvert.SerializeObject(emp);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode) 
            {
                TempData["insert_message"] = "Employee Added Successfully...";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

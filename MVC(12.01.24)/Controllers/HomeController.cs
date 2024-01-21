using Microsoft.AspNetCore.Mvc;
using MVC_12._01._24_.Models;
using System.Diagnostics;

namespace MVC_12._01._24_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task Index()
        {
            string content = @"
                <form method='post' action='/Home/Index/Page2'>
                
                <label> Страница 1 </label> <br><br>
                <label> Введите длину массива </label> <br>
                <input type='number' name='size' :/> <br>
                <input type='submit' value='Send' :/>
                    
                </form>
            ";

            Response.ContentType = "text/html; charset=utf-8";
            await Response.WriteAsync(content);
        }

        [HttpPost("/Home/Index/Page2")]
        public async Task Index(int size)
        {
            string content = @$"
                <form method='post' action='/Home/Index/Page3'>
                
                <label> Страница 2 </label> <br><br>
                <label> Заполните массив </label> <br>
                <input type='text' maxlength='{size}' name='array' :/> <br>
                <input type='submit' value='Send' :/>
                    
                </form>
            ";

            Response.ContentType = "text/html; charset=utf-8";
            await Response.WriteAsync(content);
        }

        [HttpPost("/Home/Index/Page3")]
        public string Index(string[] array)
        {
            string result = "";
            foreach (var item in array)
            {
                result = result + $" {item}";
            }
            return $"Страница 3\nМассив: {result}";
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

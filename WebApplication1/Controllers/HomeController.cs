using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Numerics;
using WebApplication1.Models;
using YamlDotNet.Serialization;
using WebApplication1.DBContext;
using System.Reflection.PortableExecutable;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HuniContext _context;

        public HomeController(ILogger<HomeController> logger, HuniContext context)
        {
            _logger = logger;
            _context = context; 
        }

        [HttpGet]
        public IActionResult Index()
        {
            var deserializer = new DeserializerBuilder().Build();
            using (var reader = new StreamReader($@"D:\개인프로젝트\Yaml\YamlCRUD\YamlCRUD\myfile91.yaml"))
            {
                var yamldata = deserializer.Deserialize<Dictionary<string, object>>(reader);
                return View(yamldata);
            }
        }

        [HttpGet]
        public IActionResult Submit() { return View(); }
        [HttpPost]
        public IActionResult Submit(PersonViewModel person)
        {
            var serializer = new SerializerBuilder().Build(); 
            var models= new PersonViewModel 
            { 
                Name = person.Name,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Phone = person.Phone,
                Address = person.Address,
                City = person.City
            };
            var yamlData = serializer.Serialize(models);

            var random = new Random();
            int randomNumber = random.Next(100);

            var filePath = $@"D:\개인프로젝트\Yaml\YamlCRUD\YamlCRUD\yamlfile{randomNumber}.yaml"; //경로

            System.IO.File.WriteAllText(filePath, yamlData); //쓰기

            //_context.Add(models);
            //_context.SaveChanges();
            return View(models);
        }

    }
}
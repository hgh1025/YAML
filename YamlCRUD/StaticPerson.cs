using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace YamlCRUD
{
    public class StaticPerson
    {
        public static void Read()
        {
            var deserializer = new DeserializerBuilder().Build();
            using (var reader = new StreamReader(@"D:\개인프로젝트\Yaml\YamlCRUD\YamlCRUD\myfile91.yaml"))
            {
                var yamlobj = deserializer.Deserialize<Person>(reader);
                Console.WriteLine($"Name: {yamlobj.Name}");
                Console.WriteLine($"FirstName: {yamlobj.FirstName}");

                for (int i = 0; i < yamlobj.City.Length; i++)
                    Console.WriteLine($"City: {yamlobj.City[i]}");

                
            }
           // deserializer.Deserialize<Person>(File.ReadAllText(@"D:\개인프로젝트\Yaml\YamlCRUD\YamlCRUD\myfile91.yaml"));
        }
        public static void Write()
        {

            var serializer = new SerializerBuilder().Build();
            var random = new Random();
            int randomNumber = random.Next(100);
            using (var writer = new StreamWriter($@"D:\개인프로젝트\Yaml\YamlCRUD\YamlCRUD\myfile{randomNumber}.yaml"))
            {
                var objs = new Person()
                {
                    Name = "홍길동",
                    FirstName = "길동",
                    LastName = "홍",
                    Email = "honggildong@email.com",
                    Phone = "010-1234-5678",
                    Address = "서울시 중구",
                    City = new[] { "서울", "부산" }
                };

                serializer.Serialize(writer, objs);
            }
        }
    }
}
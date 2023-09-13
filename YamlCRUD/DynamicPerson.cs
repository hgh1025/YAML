using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace YamlCRUD
{
    public class DynamicPerson
    {
        public static void Read()
        {
            var deserializer2 = new DeserializerBuilder().Build();


            using (var reader = new StreamReader(@"D:\개인프로젝트\Yaml\YamlCRUD\YamlCRUD\myfile12.yaml"))
            {
                dynamic obj = deserializer2.Deserialize<ExpandoObject>(reader);
                Console.WriteLine(obj.Name);  // 예: "값" 출력
                Console.WriteLine(obj.FirstName);  // 예: "값" 출력
            }
        }
        public static void Write()
        {
            dynamic obj2 = new ExpandoObject();
            obj2.Name = "홍길동";
            obj2.FirstName = "길동";

            var serializer2 = new SerializerBuilder().Build();
            using (var writer = new StreamWriter(@"D:\개인프로젝트\Yaml\YamlCRUD\YamlCRUD\myfile12.yaml"))
            {
                serializer2.Serialize(writer, obj2);
            }
        }
    }
}

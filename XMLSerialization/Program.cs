using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLSerialization
{
    public class Student
    {
        public string name;
        public string sname;
        public double gpa;
    }

    class Program
    {
        static void Main(string[] args)
        {
            F1();
            F2();
           
        }

        private static void F2()
        {
            Student s = new Student();
            s.name = "John";
            s.sname = "Smith" + Environment.NewLine + "Smitovich";

            Console.WriteLine(s.sname);
            s.gpa = 4.0;

            JsonSerializer js = new JsonSerializer();
            string res = JsonConvert.SerializeObject(s);
            FileStream fs = new FileStream("student.json", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(res);

            sw.Close();
            fs.Close();
        }

        private static void F1()
        {
            FileStream fs = new FileStream("student.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Student s = new Student();
            XmlSerializer xs = new XmlSerializer(typeof(Student));
            s.name = "John";
            s.sname = "Smith" + Environment.NewLine + "Smitovich";
            s.gpa = 4.0;

            xs.Serialize(fs, s);
            fs.Close();

            /*FileStream fs2 = new FileStream("student.xml", FileMode.Open, FileAccess.Read);
            Student s2 = xs.Deserialize(fs2) as Student;

            Console.WriteLine(s2.gpa);
            Console.WriteLine(s2.name);
            Console.WriteLine(s2.sname);
            fs2.Close();*/
        }
    }
}

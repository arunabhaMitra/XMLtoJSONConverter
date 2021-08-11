using System;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;


namespace XMLtoJSONConverter.Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(workingDirectory + "/SourceFiles/XMLSample.xml");
            Console.WriteLine("XML ==> " + xmlDoc.InnerXml);

            string empJSON = XMLtoJSON(xmlDoc.InnerXml);
            Console.WriteLine("\nJSON ==> " + empJSON);
        }

        public static string XMLtoJSON(string xmlData)
        {
            Employee emp;
            XmlSerializer xmlserializer = new XmlSerializer(typeof(Employee));

            using (StringReader textReader = new StringReader(xmlData))
            {
                emp = (Employee)xmlserializer.Deserialize(textReader);
            }
            return EmployeeToJson(emp);
        }
        public static string EmployeeToJson(Employee emp)
        {
            return JsonSerializer.Serialize(emp);
        }
    }
}

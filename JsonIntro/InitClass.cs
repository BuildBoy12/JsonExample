namespace JsonIntro
{
    using Classes;
    using Newtonsoft.Json;
    using System;
    using System.IO;

    public class MainClass
    {
        private const int Age = 2;
        private const string FileName = "MyFile";
        private const string Name = "Error!Sans";

        public static void Main() => WriteToFile(Name, Age, FileName);

        private static void WriteToFile(string name, int age, string directory)
        {
            var myClass = new MyClass
            {
                MyName = name,
                MyAge = age
            };

            string serialized = JsonConvert.SerializeObject(myClass);
            File.WriteAllText(directory, serialized);
            Console.WriteLine("Writing complete.");
            ReadFromFile(directory);
        }

        private static void ReadFromFile(string directory)
        {
            string lines = File.ReadAllText(directory);
            MyClass deserialized = JsonConvert.DeserializeObject<MyClass>(lines);
            Console.WriteLine("Deserialized object:" +
                              $"\nName: {deserialized.MyName}" +
                              $"\nAge: {deserialized.MyAge}");
        }
    }
}
using System;
using lab2task6;
namespace lab2task6
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var deserializer = new DeserializeJson("Assets/data.json");
            
            // deserializer.SomeStats();
            // SerializeJson.run(deserializer, "Assets/data_mod.json");

            // new ConvertJsonToYaml(deserializer).Run("Assets/data.yaml");
            new ConvertJsonToYaml("Assets/data.json").Run("Assets/data.yaml");
        }
    }
}
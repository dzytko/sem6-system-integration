using System.IO;
using Newtonsoft.Json;

namespace lab2task6
{
    public class ConvertJsonToYaml
    {
        private readonly dynamic _deserializedData;
        public ConvertJsonToYaml(string jsonFileDir)
        {
            using var reader = new StreamReader(jsonFileDir);
            var json = reader.ReadToEnd();
            _deserializedData = JsonConvert.DeserializeObject(json);
        }

        public ConvertJsonToYaml(DeserializeJson deserializer)
        {
            _deserializedData = deserializer.Data;
        }

        public void Run(string destinationDir)
        {
            var serializer = new YamlDotNet.Serialization.Serializer();
            var yaml = serializer.Serialize(_deserializedData);
            
            File.WriteAllText(destinationDir, yaml);
        }
    }
}
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace lab2task6
{
    public class ConvertJsonToYaml
    {
        private readonly  List<Dictionary<string, object?>> _deserializedData;
        public ConvertJsonToYaml(string jsonFileDir)
        {
            using var reader = new StreamReader(jsonFileDir);
            var json = reader.ReadToEnd();
            _deserializedData = JsonConvert.DeserializeObject<List<Dictionary<string, object?>>>(json);
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
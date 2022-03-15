using System;
using System.IO;
using lab2task6;
using YamlDotNet.Serialization;


namespace lab2task6
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var file = new StreamReader("Assets/basic_config.yaml");
            var config =  new DeserializerBuilder().Build().Deserialize<dynamic>(file);
            string sourceDir = config["paths"]["source_dir"];
            
            var deserializer = new DeserializeJson(sourceDir + config["paths"]["json_source_file"]);

            deserializer.SomeStats();
            SerializeJson.run(deserializer,  sourceDir + config["paths"]["json_destination_file"]);

            // new ConvertJsonToYaml(deserializer).Run(sourceDir + config["paths"]["yaml_destination_file"]);
            new ConvertJsonToYaml(sourceDir + config["paths"]["json_source_file"]).Run(sourceDir + config["paths"]["yaml_destination_file"]);
        }
    }
}
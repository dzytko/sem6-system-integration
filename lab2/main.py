from deserialize_json import DeserializeJson
from serialize_json import SerializeJson
from convert_json_to_yaml import ConvertJsonToYaml
from convert_xml_to_json import ConvertXmlToJson
from convert_json_to_xml import ConvertJsonToXml
import yaml

with open('Assets/basic_config.yaml', encoding="utf8") as f:
    config = yaml.load(f, Loader=yaml.FullLoader)

source_dir = config['paths']['source_dir']

newDeserializer = DeserializeJson(source_dir + config['paths']['json_source_file'])

newDeserializer.somestats()
SerializeJson.run(newDeserializer, source_dir + config['paths']['json_destination_file'])

ConvertJsonToYaml(newDeserializer.data).run(source_dir + config["paths"]["yaml_destination_file"])
# ConvertJsonToYaml(source_dir + config["paths"]["json_source_file"]).run(source_dir + config["paths"]["yaml_destination_file"])


ConvertJsonToXml.run("Assets/data.json", "Assets/data.xml")
ConvertXmlToJson.run("Assets/data.xml", "Assets/data2.json")

from deserialize_json import DeserializeJson
from serialize_json import SerializeJson
from convert_json_to_yaml import ConvertJsonToYaml
import yaml

# newDeserializator = DeserializeJson("Assets/data.json")
# newDeserializator.somestats()
#
# SerializeJson.run(newDeserializator, "Assets/data_mod.json")
#
# ConvertJsonToYaml(newDeserializator.data).run("Assets/data.yaml")
# # ConvertJsonToYaml("Assets/data.json").run("Assets/data.yaml")
#

# temp_conf_file = open('Assets/basic_config.yaml', encoding="utf8")
# conf_data = yaml.load(temp_conf_file, Loader=yaml.FullLoader)
# newDeserializator = DeserializeJson(conf_data['paths']['source_folder']+conf_data['paths']['json_source_file'])
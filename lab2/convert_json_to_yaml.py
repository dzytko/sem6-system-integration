from multipledispatch import dispatch
import yaml
import json


class ConvertJsonToYaml:
    @dispatch(str)
    def __init__(self, json_file):
        with open(json_file, 'r', encoding='utf8') as f:
            self.deserialized_data = json.load(f)

    @dispatch(list)
    def __init__(self, json_data):
        self.deserialized_data = json_data

    def run(self, destination_file_locaiton):
        print("let's convert something")
        with open(destination_file_locaiton, 'w', encoding='utf8') as f:
            yaml.dump(self.deserialized_data, f, allow_unicode=True)
        print("it is done")

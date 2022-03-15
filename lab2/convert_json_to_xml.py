from dicttoxml import dicttoxml
import json


class ConvertJsonToXml:
    @staticmethod
    def run(source_path, dest_path):
        with open(source_path) as f:
            json_data = json.load(f)

        with open(dest_path, "wb") as f:
            f.write(dicttoxml(json_data))

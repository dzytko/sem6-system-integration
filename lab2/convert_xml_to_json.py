import json
import xmltodict


class ConvertXmlToJson:
    @staticmethod
    def run(source_path, dest_path):
        with open(source_path) as fd:
            doc = xmltodict.parse(fd.read())

        with open(dest_path, "w") as f:
            json.dump(doc, f, ensure_ascii=False)


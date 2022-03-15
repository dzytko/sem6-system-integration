import json


class DeserializeJson:
    def __init__(self, filename):
        print("let's deserialize something")
        with open(filename, encoding="utf8") as f:
            self.data = json.load(f)

    def somestats(self):
        example_stat = 0

        departments_in_voivodeship_count = {}

        for department in self.data:
            if department["typ_JST"] == "GM" and department["Województwo"] == "dolnośląskie":
                example_stat += 1

            if department["Województwo"] not in departments_in_voivodeship_count:
                departments_in_voivodeship_count[department["Województwo"]] = 1
            else:
                departments_in_voivodeship_count[department["Województwo"]] += 1

        print(f"liczba urzędów miejskich w województwie dolnośląskim: {example_stat}")
        print("Liczba urzędów w wojewodztwach: ")
        for voivodeship, count in departments_in_voivodeship_count.items():
            print(f"\t{voivodeship}: {count}")


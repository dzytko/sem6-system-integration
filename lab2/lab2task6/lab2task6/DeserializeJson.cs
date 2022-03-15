using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace lab2task6
{
    public class DeserializeJson
    {
        public dynamic Data { get; }

        public DeserializeJson(string sourcePath)
        {
            using var reader = new StreamReader(sourcePath);
            var json = reader.ReadToEnd();
            Data = JsonConvert.DeserializeObject(json);
        }

        public void SomeStats()
        {
            var exampleStat = 0;
            var departmentsInVoivodeshipCount = new Dictionary<string, int>();
            foreach (var department in Data)
            {
                string voivodeship = department["Województwo"];
                
                if (department["typ_JST"] == "GM" && voivodeship == "dolnośląskie")
                    exampleStat++;

                if (!departmentsInVoivodeshipCount.ContainsKey(voivodeship))
                    departmentsInVoivodeshipCount[voivodeship] = 1;
                else
                    departmentsInVoivodeshipCount[voivodeship]++;
            }

            Console.WriteLine($"liczba urzędów miejskich w województwie dolnośląskim: {exampleStat}");
            Console.WriteLine("Liczba urzędów w wojewodztwach: ");
            foreach (var (voivodeship, count) in departmentsInVoivodeshipCount)
                Console.WriteLine($"\t{voivodeship}: {count}");
        }
    }
}
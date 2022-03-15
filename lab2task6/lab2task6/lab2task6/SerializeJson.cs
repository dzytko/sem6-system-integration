using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace lab2task6
{
    public class SerializeJson
    {
        public static void run(DeserializeJson deserializer, string destinationDir)
        {
            var newData = new List<dynamic>();
            foreach (var department in deserializer.Data)
            {
                newData.Add(new
                {
                    Kod_TERYT = department["Kod_TERYT"],
                    Województwo = department["Województwo"],
                    Powiat = department["Powiat"],
                    typ_JST = department["typ_JST"],
                    nazwa_urzędu_JST = department["nazwa_urzędu_JST"],
                    miejscowość = department["miejscowość"],
                    telefon_z_numerem_kierunkowym = $"{(int)department["telefon kierunkowy"]}{department["telefon"]}",
                });
            }
            var json = JsonConvert.SerializeObject(newData);
            File.WriteAllText(destinationDir, json);
        }
    }
}
using GenerateLargeFiles.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace GenerateLargeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MainData> mainData = new List<MainData>();

            for (int i = 1; i <= 10000; i++)
            {
                mainData.Add(GenerateData());
            }

            string result = args[0].ToString() switch
            {
                "json" => JsonSerializer.Serialize(mainData),
                "xml" => SerialiseHelper.Serialize<List<MainData>>(mainData),
                _ => throw new Exception($"Unsupported type {args[0]}")
            };

            File.WriteAllText($"LargeFileOutput.{args[0]}", result);
        }

        static Random _rnd = new Random();

        static MainData GenerateData()
        {
            int rnd = _rnd.Next(3);

            var data = rnd switch
            {
                0 => new MainData()
                {
                    PropertyOne = $"Did you exchange",
                    PropertyTwo = $"A walk on part in the war",
                    PropertyThree = $"For a lead role in a cage?",
                    SubDataProperty = GenerateSubData(rnd, "Pink Floyd, Wish You Were Here")
                },
                1 => new MainData()
                {
                    PropertyOne = $"Scream a thousand miles",
                    PropertyTwo = $"Hear the black death rising moan",
                    PropertyThree = $"Firestorm coming closer",
                    SubDataProperty = GenerateSubData(rnd, "Motorhead, Bomber")
                },
                2 => new MainData()
                {
                    PropertyOne = $"We've known each other for so long",
                    PropertyTwo = $"Your heart's been aching but you're too shy to say it",
                    PropertyThree = $"Inside we both know what's been going on",
                    SubDataProperty = GenerateSubData(rnd, "Rick Astley, Never Gonna Give You Up")
                }
            };

            return data;

            SubData GenerateSubData(int num, string value) =>
                new SubData()
                {
                    Description = value,
                    ImportantValue = num,
                    Timestamp = DateTime.Now
                };
        }
    }    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace E_Commerce_Shopping_Cart_System.Utils
{
    public static class JsonHelper
    {
        public static List<T> LoadData<T>(string filePath)
        {
            // თუ ფაილი არ არსებობს — აბრუნებს ცარიელ სიას
            if (!File.Exists(filePath))
                return new List<T>();

            try
            {
                string json = File.ReadAllText(filePath);
                var data = JsonSerializer.Deserialize<List<T>>(json);
                return data ?? new List<T>();
            }
            catch
            {
                return new List<T>();
            }
        }

        public static void SaveData<T>(string filePath, List<T> data)
        {
            try
            {
                string? folder = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(data, options);

                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data storage error: " + ex.Message);
            }
        }
    }
}

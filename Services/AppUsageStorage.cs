using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using ProductivityQuest.Models;

namespace ProductivityQuest.Services
{
    public static class AppUsageStorage
    {
        private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usages.json");

        public static void Save(List<AppUsage> usages)
        {
            string json = JsonConvert.SerializeObject(usages, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        public static List<AppUsage> Load()
        {
            if (!File.Exists(FilePath))
                return new List<AppUsage>();

            try
            {
                string json = File.ReadAllText(FilePath);
                var usages = JsonConvert.DeserializeObject<List<AppUsage>>(json);

                return usages?
                    .Where(u => u.CreatedDate.Date == DateTime.Today)
                    .ToList() ?? new List<AppUsage>();
            }
            catch
            {
                return new List<AppUsage>(); // JSON 오류 시 빈 리스트 반환
            }
        }
    }
}

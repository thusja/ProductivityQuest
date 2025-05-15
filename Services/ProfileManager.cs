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
    public static class ProfileManager
    {
        private static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "profile.json");

        public static UserProfile Load()
        {
            if (!File.Exists(filePath))
                return new UserProfile();

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<UserProfile>(json) ?? new UserProfile();
        }

        public static void Save(UserProfile profile)
        {
            string json = JsonConvert.SerializeObject(profile, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}

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
    public static class ReportExporter
    {
        public static void SaveDailyReport(List<AppUsage> apps, int level, int exp)
        {
            var log = new
            {
                timestamp = DateTime.Now.ToString("yyyy-MM-dd\\THH:mm:ss"),
                level = level,
                exp = exp,
                apps = apps.Select(app => new
                {
                    name = app.AppName,
                    usage = app.UsageTime.ToString(@"hh\:mm\:ss"),
                    goal = app.GoalTime.ToString(@"hh\:mm\:ss"),
                    status = app.Status,
                    penalty = app.IsPenalty
                }).ToList()
            };

            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
            Directory.CreateDirectory(dir); // reports dir이 없으면 생성
            string filePath = Path.Combine(dir, $"{DateTime.Now:yyyy-MM-dd}.json");

            List<object> logs = new List<object>();

            // 기존 파일이 있다면 읽어서 이어붙임
            if (File.Exists(filePath))
            {
                string existingJson = File.ReadAllText(filePath);
                logs = JsonConvert.DeserializeObject<List<object>>(existingJson) ?? new List<object>();
            }

            logs.Add(log);

            string json = JsonConvert.SerializeObject(logs, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}

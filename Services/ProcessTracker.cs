using ProductivityQuest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityQuest.Services
{
    class ProcessTracker
    {
        private Dictionary<string, AppUsage> appUsages = new Dictionary<string, AppUsage>();
        private TimeSpan tickInterval;

        // 감시 중인지 여부를 나타내는 플래그 추가
        private bool isTracking = false;
        // 외부에서 읽기만 가능하도록 public 속성 추가
        public bool IsTracking => isTracking;
        // 패널티 앱 리스트 저장용
        private readonly HashSet<string> penalizedApps;

        public ProcessTracker(TimeSpan interval, HashSet<string> penalizedApps = null)
        {
            tickInterval = interval; // 감시 주기 (예: 5초마다 5초 추가)
            this.penalizedApps = penalizedApps ?? new HashSet<string>(StringComparer.OrdinalIgnoreCase); // 기본 빈 목록
        }

        // 감시 시작 메서드
        public void StartTracking()
        {
            isTracking = true;
        }

        // 감시 중지 메서드
        public void StopTracking()
        {
            isTracking = false;
        }

        // 현재 감시되고 있는 앱 리스트 반환
        public List<AppUsage> GetCurrentAppUsages()
        {
            return new List<AppUsage>(appUsages.Values);
        }

        // 외부에서 강제로 AppUsage 추가 (목표만 먼저 지정할 때 사용)
        public void ForceAddApp(AppUsage app)
        {
            if (app == null || string.IsNullOrWhiteSpace(app.AppName)) // 방어 코드
                return;

            if (!appUsages.ContainsKey(app.AppName))
            {
                appUsages[app.AppName] = app;
            }
        }

        // 현재 실행 중인 모든 앱 이름 확인 후, AppUsage에 누적
        public void UpdateAppUsages()
        {
            // 감시 시작 전이면 아무 것도 하지 않음
            if (!isTracking) return;

            Process[] processes = Process.GetProcesses();

            foreach (var process in processes)
            {
                try
                {
                    string name = process.ProcessName + ".exe"; // ex : chrome.exe

                    // 앱이 등록되지 않은 경우
                    if (!appUsages.ContainsKey(name))
                    {
                        // 패널티 앱이면 자동 등록
                        if (penalizedApps.Contains(name))
                        {
                            appUsages[name] = new AppUsage(name);
                        }
                        else
                        {
                            continue; // 등록되지 않았고 패널티 앱도 아님
                        }
                    }

                    // 누적 시간 증가
                    appUsages[name].UsageTime += tickInterval;
                }
                catch
                {
                     // 액세스 거부 예외 등 무시
                }
            }
        }
    }
}

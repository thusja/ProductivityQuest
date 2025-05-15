using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityQuest.Models
{
    public class AppUsage
    {
        public string AppName { get; set; } // ex : chrome.exe
        public TimeSpan UsageTime { get; set; } // 누적 사용 시간 
        public TimeSpan GoalTime { get; set; } // 설정된 목표 시간
        public bool IsRewarded { get; set; } = false; // 중복 보상 방지
        public bool IsDeadlinePassed { get; set; } = false; // 마감 여부 표시
        public bool IsPenaltyApplied { get; set; } = false; // 중복 감점 방지
        public bool IsPenalty
        {
            // 내부 계산용, 저장 시 penalty 필드 출력
            get
            {
                // 목표 없음 + 실행된 시간 있음 에서만 true
                return GoalTime == TimeSpan.Zero && UsageTime > TimeSpan.Zero;
            }
        }
        public DateTime CreatedDate { get; set; } = DateTime.Today; // 기본값은 오늘
        public string Status
        {
            get
            {
                if (IsPenalty)
                    return "패널티";

                if (GoalTime == TimeSpan.Zero)
                    return UsageTime == TimeSpan.Zero ? "미진행" : "목표 없음";

                if (UsageTime == TimeSpan.Zero)
                    return "미진행";

                if (IsDeadlinePassed && UsageTime < GoalTime)
                    return "미달성";

                if (UsageTime >= GoalTime)
                    return "달성";

                return "진행중";
            }
        }

        // report data grid view status
        public string SummaryStatus
        {
            get
            {
                if (IsPenalty)
                    return "패널티";

                if (GoalTime == TimeSpan.Zero)
                    return "미달성";

                return UsageTime >= GoalTime ? "달성" : "미달성";
            }
        }

        public AppUsage(string appName)
        {
            AppName = appName;
            UsageTime = TimeSpan.Zero;
            GoalTime = TimeSpan.Zero;
        }

        public AppUsage() { }
    }
}
